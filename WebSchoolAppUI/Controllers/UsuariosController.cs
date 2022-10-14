using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSchoolAppUI.Models;
using WebSchoolAppUI.ViewModels;

namespace WebSchoolAppUI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public UsuariosController(DWDistrito0503Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.Include(p => p.PerfilNavigation).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public IActionResult Create()
        {
            ViewData["Perfil"] = new SelectList(_context.Perfiles, "IdPerfil", "Nombre");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,Apellido,Contrasena,Perfil,NombreUsuario,Correo")] Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                usuario.FechaCreado = DateTime.Now;
                _context.Add(usuario) ;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Perfil"] = new SelectList(_context.Perfiles, "IdPerfil", "Nombre", usuario.Perfil);

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
            ViewData["Perfil"] = new SelectList(_context.Perfiles, "IdPerfil", "Nombre", usuario.Perfil);

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nombre,Apellido,Contrasena,Perfil,NombreUsuario,Correo")] Usuario usuario)
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
                    oldUsuario.Nombre = usuario.Nombre;
                    oldUsuario.Apellido = usuario.Apellido;
                    oldUsuario.NombreUsuario = usuario.NombreUsuario;
                    oldUsuario.Perfil = usuario.Perfil;
                    oldUsuario.Correo = usuario.Correo;
                    oldUsuario.FechaModificado = usuario.FechaModificado;
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
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
