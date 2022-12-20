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
using WebSchoolAppUI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebSchoolAppUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DWDistrito0503Context _context;

        public HomeController(ILogger<HomeController> logger, DWDistrito0503Context context)
        {
            _context = context;
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
     

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioAuth usuario)
        {
            
            //if (isValid(usuario))
            //{
            //    return RedirectToAction("index","Home");
            //}

            if (!string.IsNullOrEmpty(usuario.NombreUsuario) && string.IsNullOrEmpty(usuario.Contrasena))
            {
                return RedirectToAction("Login");
            }
            var user =  _context.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario).FirstOrDefault();

            if (user == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            if (usuario.Contrasena != user.Contrasena)
            {
                return BadRequest("Contraseña incorrecta");
            }
            var perfil = _context.Perfiles.Where(x => x.IdPerfil == user.Perfil).FirstOrDefault();
            var personalCentro = user.TipoUsuario == 2 ? _context.PersonalCentros.Where(x => x.IdPersonalCentro == user.Personal).FirstOrDefault() : null;
            var personalDistrito = user.TipoUsuario == 1 ? _context.PersonalDistritos.Where(x => x.IdPersonalDistrito == user.Personal).FirstOrDefault() : null;
            var distrito = personalDistrito != null ? _context.Distritos.Where(x => x.IdDistrito == personalDistrito.IdDistrito).FirstOrDefault() : null;
                var centro = personalCentro != null ? _context.CentrosEducativos.Where(x => x.IdCentroEducativo == personalCentro.IdCentro).FirstOrDefault() : null;
            var tipoUsuario = _context.TipoUsuarios.Where(x => x.IdTipoUsuario == user.TipoUsuario).FirstOrDefault();
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;

            if (!(user == null))
            {
                    identity = new ClaimsIdentity(new[]
               {
                    new Claim(ClaimTypes.Name,user.NombreUsuario),
                    new Claim(ClaimTypes.Role,user.PerfilNavigation.Nombre),
                    new Claim("Centro", centro != null ? centro.Nombre : "" ),
                    new Claim("Tipo", tipoUsuario.Nombre),
                    new Claim("Distrito", distrito != null ? distrito.Codigo : ""),
                    new Claim("DistritoId", personalDistrito != null ? personalDistrito.IdDistrito.ToString() : ""),
                    new Claim("CentroId", personalCentro != null ? personalCentro.IdCentro.ToString() : ""),


                }, CookieAuthenticationDefaults.AuthenticationScheme);
               
                isAuthenticate = true;
            }
           
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
       
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            HttpContext.Response.Cookies.Delete("my_app_auth_cookie");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToActionPermanent("Login", "Home", null);
        }
        private bool isValid(UsuarioAuth usuario)
        {
            if (usuario.NombreUsuario == "admin" && usuario.Contrasena == "admin")
            {
                return true;
            }
            return false;
        }

        public IActionResult MenuRegistros()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Configuracion()
        {
            return View();
        }
        [HttpPost]
        public async  Task<ActionResult> Configuracion(List<IFormFile> files ,int idCentro)
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine("UploadedFiles", formFile.FileName);
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count = files.Count, size, filePaths , Centro=idCentro});
         

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
