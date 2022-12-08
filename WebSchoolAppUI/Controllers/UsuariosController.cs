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
    [Authorize(Roles = "Personal Distrito,Administrador")]
    public class UsuariosController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public UsuariosController(DWDistrito0503Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var context = _context.Usuarios.Where(x=> x.TipoUsuario == 1 && x.Estado==1).Select(x => new UsuarioDistritoVM
            {
                IdUsuario = x.IdUsuario,
                Perfil = x.PerfilNavigation.Nombre,
                NombreUsuario = x.NombreUsuario,
                Correo = x.Correo,
                Estado = x.Estado,
                Personal = _context.PersonalDistritos.Where(u => u.IdPersonalDistrito == x.Personal).Select(x => x.Nombre + " " + x.Apellido).FirstOrDefault(),
                TipoUsuario = x.TipoUsuarioNavigation.Nombre,
                Distrito = _context.Distritos.Where(z => z.IdDistrito == _context.PersonalDistritos.Where(u => u.IdPersonalDistrito == x.Personal).Select(t => t.IdDistrito).FirstOrDefault()).Select(x => x.Codigo).FirstOrDefault()
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
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public IActionResult Create(int? id)
        {
            ViewData["Perfil"] = new SelectList(_context.Perfiles.Where(i => i.Nombre.Contains("Distrito") || i.Nombre =="Administrador"), "IdPerfil", "Nombre");
            ViewData["Personal"] = new SelectList(_context.PersonalDistritos.Where(x=> x.IdDistrito == id), "IdPersonalDistrito", "Nombre");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Personal,Contrasena,Perfil,NombreUsuario,Correo")] Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                usuario.FechaCreado = DateTime.Now;
                usuario.TipoUsuario = 1;
                usuario.Estado = 1;
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
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Personal,Contrasena,Perfil,NombreUsuario,Correo")] Usuario usuario)
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
                    oldUsuario.Personal = usuario.Personal;
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
