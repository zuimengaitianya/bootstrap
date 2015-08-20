using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using TelnetMVC.Common;

namespace TelnetMVC.Controllers
{
    public class PubAttachmentController : Controller
    {
        //
        // GET: /PubAttachment/
        private HttpRequest m_request;
        private HttpResponse m_response;
        private HttpContext m_context;

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 下载查看附件
        /// </summary>
        private void Download()
        {
            try
            {
                string data = "";
                
                data = m_request.Form["Id"];
                string filePath = ""; //路径
                string fileName = "";//文件名称

                //以字符流的形式下载文件
                FileStream fs = new FileStream(filePath, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                m_response.ContentType = "application/octet-stream";
                //通知浏览器下载文件而不是打开
                m_response.AddHeader("Content-Disposition",
                    "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8).Replace("+", "%20"));
                m_response.BinaryWrite(bytes);
                m_response.Flush();
            }
            catch (Exception ex)
            {
                
                m_response.Redirect("/Common/Error.aspx", false);
            }
            finally
            {
                m_response.End();
            }
        }
        /// <summary>
        /// 上传附件
        /// </summary>
        private void AddAttachment()
        {
            try
            {
                //上传执行
                HttpPostedFile file = m_request.Files["Filedata"];

                //else
                //{
                //    context.Response.Write("0");
                //}
                string formId = m_request["formid"];
                bool isSameFile = true;
                if (!isSameFile)
                {
                    string fileGuid = Guid.NewGuid().ToString("D");
                    //HttpContext.Server.MapPath
                    string uploadPath = HttpContext.Server.MapPath(@m_request["folder"]) + "\\" +
                                        DateTime.Now.ToString("yyyyMMdd") + "\\";

                    if (file != null)
                    {
                        if (!System.IO.Directory.Exists(uploadPath))
                        {
                            System.IO.Directory.CreateDirectory(uploadPath);
                        }
                        file.SaveAs(uploadPath + fileGuid + "_" + file.FileName);
                        //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失       
                        //context.Response.Write("1");
                    }
                    string fileType = file.FileName.Substring(file.FileName.LastIndexOf('.'));

                    
                }
                if (!isSameFile)
                {
                    m_response.Write("1");
                }
                else
                {
                    m_response.Write("0");
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(typeof(PubAttachmentHandler), ex);
                m_response.Redirect("/Common/Error.aspx", false);
            }
        }
    }
}
