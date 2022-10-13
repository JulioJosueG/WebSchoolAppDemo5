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
    public class FactInscripcionsController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public FactInscripcionsController(DWDistrito0503Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CentroSortParm = sortOrder == "Centro" ? "centro_desc" : "Centro";
            ViewBag.AnioSortParm = sortOrder == "Anio" ? "anio_desc" : "Anio";
            ViewBag.CondicionSortParm = sortOrder == "Condicion" ? "condicion_desc" : "Condicion";
            ViewBag.CursoSortParm = sortOrder == "Curso" ? "curso_desc" : "Curso";
            ViewBag.EdadSortParm = sortOrder == "Edad" ? "edad_desc" : "Edad";
            ViewBag.TipoSortParm = sortOrder == "Tipo" ? "tipo_desc" : "Tipo";
            ViewBag.ModalidadSortParm = sortOrder == "Modalidad" ? "modalidad_desc" : "Modalidad";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var inscripcion = from s in _context.FactInscripcions.Include(f => f.CreadoPorNavigation)
                .Include(f => f.IdAnioEscolarNavigation)
                .Include(f => f.IdCentroNavigation)
                .Include(f => f.IdCondicionNavigation)
                .Include(f => f.IdCursoNavigation)
                .Include(f => f.IdEdadNavigation)
                .Include(f => f.IdEstudianteNavigation)
                .Include(f => f.IdEstudianteTipoNavigation)
                .Include(f => f.IdFechaNavigation)
                .Include(f => f.IdModalidadTipoNavigation)
                .Include(f => f.IdProfesorNavigation)
                .Include(f => f.ModificadoPorNavigation)
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                inscripcion = inscripcion.Where(s =>s.IdEstudianteNavigation.Nombre.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    inscripcion = inscripcion.OrderByDescending(s => s.IdEstudianteNavigation.Nombre);
                    break;
                
                case "Centro":
                    inscripcion = inscripcion.OrderBy(s => s.IdCentro);
                    break;
                case "centro_desc":
                    inscripcion = inscripcion.OrderByDescending(s => s.IdCentro);
                    break;

                case "Anio":
                    inscripcion = inscripcion.OrderBy(s => s.IdAnioEscolar);
                    break;
                case "anio_desc":
                    inscripcion = inscripcion.OrderByDescending(s => s.IdAnioEscolar);
                    break;
                case "Condicion":
                    inscripcion = inscripcion.OrderBy(s => s.IdCondicion);
                    break;
                case "condicion_desc":
                    inscripcion = inscripcion.OrderByDescending(s => s.IdCondicion);
                    break;
                case "Curso":
                    inscripcion = inscripcion.OrderBy(s => s.IdCurso);
                    break;
                case "curso_desc":
                    inscripcion = inscripcion.OrderByDescending(s => s.IdCurso);
                    break;
                case "Edad":
                    inscripcion = inscripcion.OrderBy(s => s.IdEdad);
                    break;
                case "edad_desc":
                    inscripcion = inscripcion.OrderByDescending(s => s.IdEdad);
                    break;
                case "Tipo":
                    inscripcion = inscripcion.OrderBy(s => s.IdEstudianteTipo);
                    break;
                case "tipo_desc":
                    inscripcion = inscripcion.OrderByDescending(s => s.IdEstudianteTipo);
                    break;
                case "Modalidad":
                    inscripcion = inscripcion.OrderBy(s => s.IdModalidadTipo);
                    break;
                case "modalidad_desc":
                    inscripcion = inscripcion.OrderByDescending(s => s.IdModalidadTipo);
                    break;
                default:
                    inscripcion = inscripcion.OrderBy(s => s.IdEstudianteNavigation.Nombre);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(await inscripcion.ToPagedListAsync(pageNumber, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factInscripcion = await _context.FactInscripcions
                .Include(f => f.CreadoPorNavigation)
                .Include(f => f.IdAnioEscolarNavigation)
                .Include(f => f.IdCentroNavigation)
                .Include(f => f.IdCondicionNavigation)
                .Include(f => f.IdCursoNavigation)
                .Include(f => f.IdEdadNavigation)
                .Include(f => f.IdEstudianteNavigation)
                .Include(f => f.IdEstudianteTipoNavigation)
                .Include(f => f.IdFechaNavigation)
                .Include(f => f.IdModalidadTipoNavigation)
                .Include(f => f.IdProfesorNavigation)
                .Include(f => f.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdFactInscripcion == id);
            if (factInscripcion == null)
            {
                return NotFound();
            }

            return View(factInscripcion);
        }

        // GET: FactInscripcions/Create
        public IActionResult Create()
        {
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            ViewData["IdAnioEscolar"] = new SelectList(_context.AnioEscolars, "IdAnioEscolar", "Anio");
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "Nombre");
            ViewData["IdCondicion"] = new SelectList(_context.Condiciones, "IdCondicion", "Nombre");
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Nombre");
            ViewData["IdEdad"] = new SelectList(_context.Edades, "IdEdad", "Edad");
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Nombre");
            ViewData["IdEstudianteTipo"] = new SelectList(_context.EstudiantesTipos, "IdEstudianteTipo", "Nombre");
            ViewData["IdFecha"] = new SelectList(_context.Tiempos, "IdFecha", "Fecha");
            ViewData["IdModalidadTipo"] = new SelectList(_context.ModalidadesTipos, "IdModalidadTipo", "Nombre");
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "IdProfesor", "Nombre");
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            return View();
        }

        // POST: FactInscripcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactInscripcion,IdEstudiante,IdEstudianteTipo,IdModalidadTipo,IdFecha,IdAnioEscolar,IdCurso,IdProfesor,IdEdad,IdCondicion,IdCentro,ImporteInscripcion,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] FactInscripcion factInscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factInscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", factInscripcion.CreadoPor);
            ViewData["IdAnioEscolar"] = new SelectList(_context.AnioEscolars, "IdAnioEscolar", "IdAnioEscolar", factInscripcion.IdAnioEscolar);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", factInscripcion.IdCentro);
            ViewData["IdCondicion"] = new SelectList(_context.Condiciones, "IdCondicion", "IdCondicion", factInscripcion.IdCondicion);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", factInscripcion.IdCurso);
            ViewData["IdEdad"] = new SelectList(_context.Edades, "IdEdad", "IdEdad", factInscripcion.IdEdad);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", factInscripcion.IdEstudiante);
            ViewData["IdEstudianteTipo"] = new SelectList(_context.EstudiantesTipos, "IdEstudianteTipo", "IdEstudianteTipo", factInscripcion.IdEstudianteTipo);
            ViewData["IdFecha"] = new SelectList(_context.Tiempos, "IdFecha", "IdFecha", factInscripcion.IdFecha);
            ViewData["IdModalidadTipo"] = new SelectList(_context.ModalidadesTipos, "IdModalidadTipo", "IdModalidadTipo", factInscripcion.IdModalidadTipo);
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "IdProfesor", "IdProfesor", factInscripcion.IdProfesor);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", factInscripcion.ModificadoPor);
            return View(factInscripcion);
        }

        // GET: FactInscripcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factInscripcion = await _context.FactInscripcions.FindAsync(id);
            if (factInscripcion == null)
            {
                return NotFound();
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", factInscripcion.CreadoPor);
            ViewData["IdAnioEscolar"] = new SelectList(_context.AnioEscolars, "IdAnioEscolar", "IdAnioEscolar", factInscripcion.IdAnioEscolar);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", factInscripcion.IdCentro);
            ViewData["IdCondicion"] = new SelectList(_context.Condiciones, "IdCondicion", "IdCondicion", factInscripcion.IdCondicion);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", factInscripcion.IdCurso);
            ViewData["IdEdad"] = new SelectList(_context.Edades, "IdEdad", "IdEdad", factInscripcion.IdEdad);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", factInscripcion.IdEstudiante);
            ViewData["IdEstudianteTipo"] = new SelectList(_context.EstudiantesTipos, "IdEstudianteTipo", "IdEstudianteTipo", factInscripcion.IdEstudianteTipo);
            ViewData["IdFecha"] = new SelectList(_context.Tiempos, "IdFecha", "IdFecha", factInscripcion.IdFecha);
            ViewData["IdModalidadTipo"] = new SelectList(_context.ModalidadesTipos, "IdModalidadTipo", "IdModalidadTipo", factInscripcion.IdModalidadTipo);
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "IdProfesor", "IdProfesor", factInscripcion.IdProfesor);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", factInscripcion.ModificadoPor);
            return View(factInscripcion);
        }

        // POST: FactInscripcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactInscripcion,IdEstudiante,IdEstudianteTipo,IdModalidadTipo,IdFecha,IdAnioEscolar,IdCurso,IdProfesor,IdEdad,IdCondicion,IdCentro,ImporteInscripcion,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] FactInscripcion factInscripcion)
        {
            if (id != factInscripcion.IdFactInscripcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factInscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactInscripcionExists(factInscripcion.IdFactInscripcion))
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
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", factInscripcion.CreadoPor);
            ViewData["IdAnioEscolar"] = new SelectList(_context.AnioEscolars, "IdAnioEscolar", "IdAnioEscolar", factInscripcion.IdAnioEscolar);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", factInscripcion.IdCentro);
            ViewData["IdCondicion"] = new SelectList(_context.Condiciones, "IdCondicion", "IdCondicion", factInscripcion.IdCondicion);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", factInscripcion.IdCurso);
            ViewData["IdEdad"] = new SelectList(_context.Edades, "IdEdad", "IdEdad", factInscripcion.IdEdad);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", factInscripcion.IdEstudiante);
            ViewData["IdEstudianteTipo"] = new SelectList(_context.EstudiantesTipos, "IdEstudianteTipo", "IdEstudianteTipo", factInscripcion.IdEstudianteTipo);
            ViewData["IdFecha"] = new SelectList(_context.Tiempos, "IdFecha", "IdFecha", factInscripcion.IdFecha);
            ViewData["IdModalidadTipo"] = new SelectList(_context.ModalidadesTipos, "IdModalidadTipo", "IdModalidadTipo", factInscripcion.IdModalidadTipo);
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "IdProfesor", "IdProfesor", factInscripcion.IdProfesor);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", factInscripcion.ModificadoPor);
            return View(factInscripcion);
        }

        // GET: FactInscripcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factInscripcion = await _context.FactInscripcions
                .Include(f => f.CreadoPorNavigation)
                .Include(f => f.IdAnioEscolarNavigation)
                .Include(f => f.IdCentroNavigation)
                .Include(f => f.IdCondicionNavigation)
                .Include(f => f.IdCursoNavigation)
                .Include(f => f.IdEdadNavigation)
                .Include(f => f.IdEstudianteNavigation)
                .Include(f => f.IdEstudianteTipoNavigation)
                .Include(f => f.IdFechaNavigation)
                .Include(f => f.IdModalidadTipoNavigation)
                .Include(f => f.IdProfesorNavigation)
                .Include(f => f.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdFactInscripcion == id);
            if (factInscripcion == null)
            {
                return NotFound();
            }

            return View(factInscripcion);
        }

        // POST: FactInscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factInscripcion = await _context.FactInscripcions.FindAsync(id);
            _context.FactInscripcions.Remove(factInscripcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactInscripcionExists(int id)
        {
            return _context.FactInscripcions.Any(e => e.IdFactInscripcion == id);
        }
    }
}
