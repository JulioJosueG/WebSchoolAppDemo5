using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebSchoolAppUI.Controllers
{
    public class ConfiguracionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
