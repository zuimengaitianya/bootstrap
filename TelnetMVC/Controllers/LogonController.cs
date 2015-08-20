using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelnetMVC.Entities;
using TelnetMVC.BLL;
using TelnetMVC.Common;

namespace TelnetMVC.Controllers
{
    public class LogonController : Controller
    {
        UserBLL userBll = new UserBLL();
        //
        // GET: /Logon/

        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 登录密码验证
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Logon(User user)
        {
            User loginUser = userBll.getSearchList(m => m.UserName == user.UserName && m.PassWord == user.PassWord).FirstOrDefault();
            if (loginUser == null)
            {
                return Content("用户名密码错误！");
            }
            else
            {
                Guid sessionId = Guid.NewGuid();//申请了一个模拟的GUID：SessionId

                //把sessionid写到客户端浏览器里面去
                Response.Cookies["sessionId"].Value = sessionId.ToString();

                UserSession userSession = new UserSession();
                userSession.user = loginUser;

                MemcacheHelper.Set(sessionId.ToString(), userSession, DateTime.Now.AddMinutes(20));//模拟sessionId

                //用户登录成功之后要保存用户的登录的数据：
                //Session["loginUser"] = loginUser;
                return Content("OK");
            }
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            string sessionId = Request.Cookies["sessionId"].Value;
            MemcacheHelper.Remove(sessionId);
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            ValidateCodeHelper helper = new ValidateCodeHelper();
            string strCode = helper.CreateValidateCode(4);
            //MemcacheHelper.Set(
            Session["validateCode"] = strCode;

            var byteData = helper.CreateValidateGraphic(strCode);
            return File(byteData, "image/jpeg");
        }
        /// <summary>
        /// 登录后角色选择
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleSelect()
        {
            UserSession userSession = (UserSession)MemcacheHelper.Get(Request.Cookies["sessionId"].Value);
            List<UserRoleAllot> allUserRoleAllot = BllFactory.userRoleAllotBll.getSearchList(o => o.UserId == userSession.user.Id).ToList<UserRoleAllot>();
            if (allUserRoleAllot.Count < 0)
            {
                //跳转到错误页
                return View("");
            }
            else if (allUserRoleAllot.Count == 1)
            {
                //重新设置session缓存内容
                //先移除原来的登录信息 保持单点登录
                var OldsessionId = (string)MemcacheHelper.Get(userSession.user.Id);//查询上次登录sessionId
                if (!string.IsNullOrEmpty(OldsessionId))
                {
                    MemcacheHelper.Remove(OldsessionId);
                }
                //重新设置登录信息
                userSession = BllFactory.userBll.GetUserSession(userSession.user, allUserRoleAllot[0]);
                MemcacheHelper.Set(Request.Cookies["sessionId"].Value, userSession);
                MemcacheHelper.Set(userSession.user.Id, Request.Cookies["sessionId"].Value);//保存用户登录sessionId
                LogHelper.WriteLog(typeof(LogonController), "userId=" + userSession.user.Id + ":sessionId=" + Request.Cookies["sessionId"].Value);
                return RedirectToAction("Index", "OrgDict", new { });
            }
            else
            {
                //跳转到选择页面
                ViewData["Dept"] = BllFactory.userRoleAllotBll.GetUserDeptDict(allUserRoleAllot);
                return View(allUserRoleAllot);
            }
        }
    }
}
