using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSchoolAppUI.Models;

namespace WebSchoolAppUI.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public ProfesoresController(DWDistrito0503Context context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            var dWDistrito0503Context = _context.Profesores.Include(p => p.CreadoPorNavigation).Include(p => p.IdAsignaturaNavigation).Include(p => p.IdCentroNavigation).Include(p => p.ModificadoPorNavigation);
            return View(await dWDistrito0503Context.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .Include(p => p.CreadoPorNavigation)
                .Include(p => p.IdAsignaturaNavigation)
                .Include(p => p.IdCentroNavigation)
                .Include(p => p.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura");
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo");
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesor,Nombre,Apellido,Cedula,IdAsignatura,IdCentro,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] Profesore profesore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", profesore.CreadoPor);
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura", profesore.IdAsignatura);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", profesore.IdCentro);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", profesore.ModificadoPor);
            return View(profesore);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores.FindAsync(id);
            if (profesore == null)
            {
                return NotFound();
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", profesore.CreadoPor);
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura", profesore.IdAsignatura);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", profesore.IdCentro);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", profesore.ModificadoPor);
            return View(profesore);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfesor,Nombre,Apellido,Cedula,IdAsignatura,IdCentro,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] Profesore profesore)
        {
            if (id != profesore.IdProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesoreExists(profesore.IdProfesor))
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
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", profesore.CreadoPor);
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "IdAsignatura", profesore.IdAsignatura);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", profesore.IdCentro);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", profesore.ModificadoPor);
            return View(profesore);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesore = await _context.Profesores
                .Include(p => p.CreadoPorNavigation)
                .Include(p => p.IdAsignaturaNavigation)
                .Include(p => p.IdCentroNavigation)
                .Include(p => p.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesore == null)
            {
                return NotFound();
            }

            return View(profesore);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesore = await _context.Profesores.FindAsync(id);
            _context.Profesores.Remove(profesore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesoreExists(int id)
        {
            return _context.Profesores.Any(e => e.IdProfesor == id);
        }
    }
}
