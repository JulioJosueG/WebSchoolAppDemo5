using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolAppUI.Controllers
{
    public class ConfiguracionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult UploadFile()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult UploadFile(HttpPostedFileBase file)
        //{
        //    try
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //            string _FileName = Path.GetFileName(file.FileName);
        //            string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
        //            file.SaveAs(_path);
        //        }
        //        ViewBag.Message = "File Uploaded Successfully!!";
        //        return View();
        //    }
        //    catch
        //    {
        //        ViewBag.Message = "File upload failed!!";
        //        return View();
        //    }
        //}
    }
}
