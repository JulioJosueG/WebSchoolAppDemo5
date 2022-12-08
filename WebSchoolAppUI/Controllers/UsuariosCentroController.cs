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

       

        public async Task<IActionResult> Index()
        {
            var context = _context.Usuarios.Where(x=> x.TipoUsuario==2 && x.Estado == 1).Select(x => new UsuarioCentroVM
            {
                IdUsuario = x.IdUsuario,
                Perfil = x.PerfilNavigation.Nombre,
                NombreUsuario = x.NombreUsuario,
                Correo = x.Correo,
                Estado = x.Estado,
                Personal = _context.PersonalCentros.Where(u => u.IdPersonalCentro == x.Personal).Select(x => x.Nombre + " " + x.Apellido).FirstOrDefault(),
                TipoUsuario = x.TipoUsuarioNavigation.Nombre,
                Centro = _context.CentrosEducativos.Where(z=> z.IdCentroEducativo == _context.PersonalCentros.Where(u => u.IdPersonalCentro == x.Personal).Select(t=> t.IdCentro).FirstOrDefault()).Select(x=> x.Nombre).FirstOrDefault()
            });
            return View(await context.ToListAsync());
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
            var personal = _context.PersonalCentros.Where(x => x.IdCentro == id).Select(s => new
            {
                IdPersonalCentro = s.IdPersonalCentro,
                NombreCompleto = s.Nombre + " " + s.Apellido
            });

            ViewData["Perfil"] = new SelectList(_context.Perfiles.Where(x=> !x.Nombre.Contains("Distrito") ), "IdPerfil", "Nombre");
            ViewData["Personal"] = new SelectList(personal, "IdPersonalCentro", "NombreCompleto");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,FechaCreado,FechaModificado,Contrasena,Perfil,NombreUsuario,Correo,Estado,Personal,TipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                usuario.Estado = 1;
                usuario.TipoUsuario = 2;
                usuario.FechaCreado = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", usuario.Estado);
            ViewData["Perfil"] = new SelectList(_context.Perfiles, "IdPerfil", "Nombre", usuario.Perfil);
            ViewData["TipoUsuario"] = new SelectList(_context.TipoUsuarios, "IdTipoUsuario", "IdTipoUsuario", usuario.TipoUsuario);
            return View(usuario);
        }

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
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", usuario.Estado);
            ViewData["Perfil"] = new SelectList(_context.Perfiles, "IdPerfil", "Nombre", usuario.Perfil);
            ViewData["TipoUsuario"] = new SelectList(_context.TipoUsuarios, "IdTipoUsuario", "IdTipoUsuario", usuario.TipoUsuario);
            return View(usuario);
        }

        [ValidateAntiForgeryToken]
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
                    _context.Update(usuario);
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
            ViewData["Estado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", usuario.Estado);
            ViewData["Perfil"] = new SelectList(_context.Perfiles, "IdPerfil", "Nombre", usuario.Perfil);
            ViewData["TipoUsuario"] = new SelectList(_context.TipoUsuarios, "IdTipoUsuario", "IdTipoUsuario", usuario.TipoUsuario);
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
