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
            string centro = User.Claims.FirstOrDefault(x => x.Type == "CentroId").Value;

            var students = from s in _context.Estudiantes.Where(x => x.Estado == 1 && x.Centro.ToString() == centro).Include(a => a.SexoNavigation)
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
            string centro = User.Claims.FirstOrDefault(x => x.Type == "CentroId").Value;
            var sigerdval = from s in _context.Estudiantes.Where(x => x.Idsigerd == estudiante.Idsigerd).ToList()
                           select s;
            if (ModelState.IsValid && !sigerdval.Any())
            {
                _context.Add(estudiante);
                estudiante.Centro = Convert.ToInt32(centro);
                estudiante.Estado = 1;
                estudiante.CreadoPor = 1;
                estudiante.FechaCreado = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            { 
                return BadRequest("El Sigerd debe ser Unico!");
            }
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
            ViewData["Sexo"] = new SelectList(_context.Sexos, "IdSexo", "Nombre", estudiante.Sexo);
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
                    var oldEstudiante = await _context.Estudiantes.FindAsync(estudiante.IdEstudiante);
                    oldEstudiante.Nombre = estudiante.Nombre;
                    oldEstudiante.Apellido = estudiante.Apellido;
                    oldEstudiante.Idsigerd = estudiante.Idsigerd;
                    oldEstudiante.FechaNacimiento = estudiante.FechaNacimiento;
                    oldEstudiante.Sexo = estudiante.Sexo;

                    oldEstudiante.ModificadoPor = 1;
                    estudiante.FechaModificado = DateTime.Now;
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
            ViewData["Sexo"] = new SelectList(_context.Sexos, "IdSexo", "Nombre", estudiante.Sexo);
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
            estudiante.Estado = 9;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.IdEstudiante == id);
        }
    }
}
