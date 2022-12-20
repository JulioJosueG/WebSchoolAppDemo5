using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSchoolAppUI.Models;
using WebSchoolAppUI.ViewModels;

namespace WebSchoolAppUI.Controllers
{
    [Authorize(Roles = "Personal Centro,Administrador")]

    public class UsuariosCentroController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public UsuariosCentroController(DWDistrito0503Context context)
        {
            _context = context;
        }

       

        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                var context = _context.Usuarios.Where(x => x.TipoUsuario == 2 && x.Estado == 1).Select(x => new UsuarioCentroVM
                {
                    IdUsuario = x.IdUsuario,
                    Perfil = x.PerfilNavigation.Nombre,
                    NombreUsuario = x.NombreUsuario,
                    Correo = x.Correo,
                    Estado = x.Estado,
                    Personal = _context.PersonalCentros.Where(u => u.IdPersonalCentro == x.Personal).Select(x => x.Nombre + " " + x.Apellido).FirstOrDefault(),
                    TipoUsuario = x.TipoUsuarioNavigation.Nombre,
                    Centro = _context.CentrosEducativos.Where(z => z.IdCentroEducativo == _context.PersonalCentros.Where(u => u.IdPersonalCentro == x.Personal).Select(t => t.IdCentro).FirstOrDefault()).Select(x => x.Nombre).FirstOrDefault()
                });
                return View(await context.ToListAsync());

            }
            else
            {
                var context = _context.Usuarios.Where(x => x.TipoUsuario == 2 && x.Estado == 1 && _context.PersonalCentros.Where(y=>  y.IdPersonalCentro == x.Personal && y.IdCentro == id).FirstOrDefault() != null).Select(x => new UsuarioCentroVM
                {
                    IdUsuario = x.IdUsuario,
                    Perfil = x.PerfilNavigation.Nombre,
                    NombreUsuario = x.NombreUsuario,
                    Correo = x.Correo,
                    Estado = x.Estado,
                    Personal = _context.PersonalCentros.Where(u => u.IdPersonalCentro == x.Personal).Select(x => x.Nombre + " " + x.Apellido).FirstOrDefault(),
                    TipoUsuario = x.TipoUsuarioNavigation.Nombre,
                    Centro = _context.CentrosEducativos.Where(z => z.IdCentroEducativo == _context.PersonalCentros.Where(u => u.IdPersonalCentro == x.Personal).Select(t => t.IdCentro).FirstOrDefault()).Select(x => x.Nombre).FirstOrDefault()
                });
                return View(await context.ToListAsync());

            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.EstadoNavigation)
                .Include(u => u.PerfilNavigation)
                .Include(u => u.TipoUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public IActionResult Create(int? id)
        {
            if(id > 0)
            {
                var personal = _context.PersonalCentros.Where(x => x.IdCentro == id && _context.Usuarios.Where(y => y.TipoUsuario == 2 && y.Personal == x.IdPersonalCentro && y.Estado == 1).FirstOrDefault() == null).Select(s => new
                {
                    IdPersonalCentro = s.IdPersonalCentro,
                    NombreCompleto = s.Nombre + " " + s.Apellido
                });
                ViewData["Personal"] = new SelectList(personal, "IdPersonalCentro", "NombreCompleto");

            }
            else
            {
                var personal = _context.PersonalCentros.Where(x => _context.Usuarios.Where(y => y.TipoUsuario == 2 && y.Personal == x.IdPersonalCentro && y.Estado == 1).FirstOrDefault() == null).Select(s => new
                {
                    IdPersonalCentro = s.IdPersonalCentro,
                    NombreCompleto = s.Nombre + " " + s.Apellido + " - " + _context.CentrosEducativos.Where(x=> x.IdCentroEducativo ==s.IdCentro).Select( x=> x.Nombre).FirstOrDefault()
                });
                ViewData["Personal"] = new SelectList(personal, "IdPersonalCentro", "NombreCompleto");
            }

            ViewData["Perfil"] = new SelectList(_context.Perfiles.Where(x=> !x.Nombre.Contains("Distrito") ), "IdPerfil", "Nombre");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,FechaCreado,FechaModificado,Contrasena,Perfil,NombreUsuario,Correo,Estado,Personal,TipoUsuario")] Usuario usuario)
        {
            var oldusuario = _context.Usuarios.Where(x => (x.Correo.Trim() == usuario.Correo.Trim() || x.NombreUsuario.Trim() == usuario.NombreUsuario.Trim()) && x.TipoUsuario==2 && x.Estado == 1).FirstOrDefault();

            if(oldusuario != null)
            {
                
                return RedirectToAction("create");
            };
            if (ModelState.IsValid)
            {
                usuario.Estado = 1;
                usuario.TipoUsuario = 2;
                usuario.FechaCreado = DateTime.Now;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
            }
            ViewData["Perfil"] = new SelectList(_context.Perfiles, "IdPerfil", "Nombre", usuario.Perfil);

            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["Personal"] = new SelectList(_context.PersonalCentros, "IdPersonal", "Nombre", usuario.Personal);
            ViewData["Perfil"] = new SelectList(_context.Perfiles, "IdPerfil", "Nombre", usuario.Perfil);
            return View(usuario);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,FechaCreado,FechaModificado,Contrasena,Perfil,NombreUsuario,Correo,Estado,Personal,TipoUsuario")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldUsuario = await _context.Usuarios.FindAsync(usuario.IdUsuario);
                    oldUsuario.NombreUsuario = usuario.NombreUsuario;
                    oldUsuario.Perfil = usuario.Perfil;
                    oldUsuario.Correo = usuario.Correo;
                    oldUsuario.FechaModificado = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Personal"] = new SelectList(_context.PersonalCentros, "IdPersonal", "Nombre", usuario.Personal);
            ViewData["Perfil"] = new SelectList(_context.Perfiles, "IdPerfil", "Nombre", usuario.Perfil);
            return View(usuario);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.EstadoNavigation)
                .Include(u => u.PerfilNavigation)
                .Include(u => u.TipoUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            usuario.Estado = 9;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
