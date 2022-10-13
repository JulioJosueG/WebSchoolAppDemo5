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
    public class EstudiantesController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public EstudiantesController(DWDistrito0503Context context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.SexSortParm = sortOrder == "Sex" ? "sex_desc" : "Sex";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in _context.Estudiantes.Include(a => a.SexoNavigation)
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Apellido.Contains(searchString)
                                       || s.Nombre.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Apellido);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.FechaNacimiento);
                    break;
               
                case "date_desc":
                    students = students.OrderByDescending(s => s.FechaNacimiento);
                    break;
                case "Sex":
                    students = students.OrderBy(s => s.Sexo);
                    break;
                case "sex_desc":
                    students = students.OrderByDescending(s => s.Sexo);
                    break;
                default:
                    students = students.OrderBy(s => s.Apellido);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(await students.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.CreadoPorNavigation)
                .Include(e => e.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            ViewData["Sexo"] = new SelectList(_context.Sexos, "IdSexo", "Nombre");

            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudiante,Nombre,Apellido,Idsigerd,FechaNacimiento,Sexo,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", estudiante.CreadoPor);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", estudiante.ModificadoPor);
            ViewData["Sexo"] = new SelectList(_context.Sexos, "IdSexo", "Nombre", estudiante.Sexo);

            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", estudiante.CreadoPor);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", estudiante.ModificadoPor);
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstudiante,Nombre,Apellido,Idsigerd,FechaNacimiento,Sexo,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] Estudiante estudiante)
        {
            if (id != estudiante.IdEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.IdEstudiante))
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
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", estudiante.CreadoPor);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", estudiante.ModificadoPor);
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.CreadoPorNavigation)
                .Include(e => e.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.IdEstudiante == id);
        }
    }
}
