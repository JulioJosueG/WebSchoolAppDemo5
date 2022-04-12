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
        public IActionResult Configuracion()
        {
            return View();
        }

        /*[HttpPost("Configuracion")]
        public IActionResult Configuracion(IFormFile file)
        {
            return View();
        }*/
        
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
