using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSchoolAppUI.Models;
using X.PagedList;

namespace WebSchoolAppUI.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public ProfesoresController(DWDistrito0503Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AsignaturaSortParm = sortOrder == "Asignatura" ? "asign_desc" : "Asignatura";
            ViewBag.CentroSortParm = sortOrder == "Centro" ? "centro_desc" : "Centro";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            string centro = User.Claims.FirstOrDefault(x => x.Type == "CentroId").Value;

            var profesores = from s in _context.Profesores.Where(x=> x.Estado == 1  && x.IdCentro.ToString() == centro).Include(a => a.IdAsignaturaNavigation).Include(b=> b.IdCentroNavigation)
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                profesores = profesores.Where(s => s.Apellido.Contains(searchString)
                                       || s.Nombre.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    profesores = profesores.OrderByDescending(s => s.Apellido);
                    break;
                case "Asignatura":
                    profesores = profesores.OrderBy(s => s.IdAsignatura);
                    break;

                case "asign_desc":
                    profesores = profesores.OrderByDescending(s => s.IdAsignatura);
                    break;
                case "Centro":
                    profesores = profesores.OrderBy(s => s.IdCentro);
                    break;
                case "centro_desc":
                    profesores = profesores.OrderByDescending(s => s.IdCentro);
                    break;
                default:
                    profesores = profesores.OrderBy(s => s.Apellido);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(await profesores.ToPagedListAsync(pageNumber, pageSize));
        }

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

        public IActionResult Create()
        {
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "Nombre");
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesor,Nombre,Apellido,Cedula,IdAsignatura,IdCentro,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] Profesore profesore)
        {
            string centro = User.Claims.FirstOrDefault(x => x.Type == "CentroId").Value;

            var oldprofesor = _context.Profesores.Where(x => x.Estado == 1 && x.Cedula == profesore.Cedula);
            if(oldprofesor != null)
            {
                return BadRequest("Cedula ya registrada");
            }
            if (ModelState.IsValid)
            {
                profesore.CreadoPor = 1;
                profesore.Estado = 1;
                profesore.IdCentro = Convert.ToInt32(centro);
                profesore.FechaCreado = DateTime.Now;
                _context.Add(profesore);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "Nombre");
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "Nombre");
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

            profesore.FechaModificado = DateTime.Now;
            if (profesore == null)
            {
                return NotFound();
            }

            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "Nombre");
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "Nombre");

            return View(profesore);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfesor,Nombre,Apellido,Cedula,IdAsignatura,IdCentro,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] Profesore profesore)
        {
            if (id != profesore.IdProfesor)
            {
                return NotFound();
            }
            var oldprofesors = _context.Profesores.Where(x => x.Estado == 1 && x.Cedula == profesore.Cedula);
            if (oldprofesors != null)
            {
                return BadRequest("Cedula ya registrada");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldprofesore = await _context.Profesores.FindAsync(profesore.IdProfesor);
                    oldprofesore.Nombre = profesore.Nombre;
                    oldprofesore.Apellido = profesore.Apellido;
                    oldprofesore.Cedula = profesore.Cedula;
                    oldprofesore.IdAsignatura = profesore.IdAsignatura;
                    oldprofesore.IdCentro = profesore.IdCentro;
                    oldprofesore.ModificadoPor = 1;
                    profesore.FechaModificado = DateTime.Now;
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

            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "IdAsignatura", "Nombre");
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "Nombre");

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
            profesore.Estado = 9;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesoreExists(int id)
        {
            return _context.Profesores.Any(e => e.IdProfesor == id);
        }
    }
}
