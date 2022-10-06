using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using WebSchoolAppUI.Models;
using Microsoft.AspNetCore.Http;

namespace WebSchoolAppUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gestion()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Centros()
        {
            return RedirectToAction("CrearCentros","Centros");
        }
        [HttpGet]
        public ActionResult Configuracion()
        {
            return View();
        }
        [HttpPost]
        public async  Task<ActionResult> Configuracion(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            try
            {

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        string _FileName = Path.GetFileName(formFile.FileName);
                        string _path = Path.Combine("~/UploadedFiles", _FileName);
                        using (var stream = System.IO.File.Create(_path))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                    return View();

                }

                   
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }

            return Ok(new { count = files.Count, size });

        }
        public IActionResult Reportes()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
