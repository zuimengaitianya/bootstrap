using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using TelnetMVC.Entities;
using System.IO;


namespace TelnetMVC.Controllers
{
    public class DataValidationController : Controller
    {
        //
        // GET: /DataValidation/

        public ActionResult Index()
        {
            //Session[""]="";
            //HttpCookie con
            return View();
        }
        //[HttpPost]
        public ActionResult DataAnnotationAction(DataAnnotationModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Name = model.Name;
                ViewBag.Email = model.Email;
            }
            return View(model);
        }
        public ActionResult FileUpload()
        {
            HttpPostedFileBase file = Request.Files["file"];
            if (file != null)
            {
                string filePath = Path.Combine(HttpContext.Server.MapPath("C:/temp"), Path.GetFileName(file.FileName));
                file.SaveAs(filePath);
                return RedirectToAction("index", "home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ImagesDownLoad()
        {
            var path = Server.MapPath("~/frog.jpg.jpg");
            return File(path, "iamge/jpeg");
        }
        public ActionResult TxtDownLoad()
        {
            var path = Server.MapPath("~");
            return null;
        }
    }
}
