﻿using System;
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
            string centro = User.Claims.FirstOrDefault(x => x.Type == "CentroId").Value;

            var inscripcion = from s in _context.FactInscripcions.Where(x=> x.Estado ==1).Include(f => f.CreadoPorNavigation)
                .Include(f => f.IdAnioEscolarNavigation)
                .Include(f => f.IdCentroNavigation)
                .Include(f => f.IdCondicionNavigation)
                .Include(f => f.IdCursoNavigation)
                .Include(f => f.IdEdadNavigation)
                .Include(f => f.IdEstudianteNavigation)
                .Include(f => f.IdEstudianteTipoNavigation)
                .Include(f => f.IdModalidadTipoNavigation)
                .Include(f => f.IdProfesorNavigation)
                .Include(f => f.ModificadoPorNavigation).Where( x=>  x.IdCentro.ToString() == centro)
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

            var factInscripcion = await _context.FactInscripcions.Where(x => x.Estado == 1)
                .Include(f => f.CreadoPorNavigation)
                .Include(f => f.IdAnioEscolarNavigation)
                .Include(f => f.IdCentroNavigation)
                .Include(f => f.IdCondicionNavigation)
                .Include(f => f.IdCursoNavigation)
                .Include(f => f.IdEdadNavigation)
                .Include(f => f.IdEstudianteNavigation)
                .Include(f => f.IdEstudianteTipoNavigation)
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
        public IActionResult Create(int? id)
        {
            var estudiante = _context.Estudiantes.Where(x => x.Centro == id && _context.FactInscripcions.Where(s=> s.IdEstudiante == x.IdEstudiante && s.FechaCreado.Year == DateTime.Now.Year).FirstOrDefault()==null).Select(s => new
            {
                IdEstudiante = s.IdEstudiante,
                NombreCompleto = s.Nombre + " " + s.Apellido + " " + s.Idsigerd
            });

            ViewData["IdAnioEscolar"] = new SelectList(_context.AnioEscolars, "IdAnioEscolar", "Anio");
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "Nombre");
            ViewData["IdCondicion"] = new SelectList(_context.Condiciones, "IdCondicion", "Nombre");
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Nombre");
            ViewData["IdEdad"] = new SelectList(_context.Edades, "IdEdad", "Edad");
            ViewData["IdEstudiante"] = new SelectList(estudiante, "IdEstudiante", "NombreCompleto");
            ViewData["IdEstudianteTipo"] = new SelectList(_context.EstudiantesTipos, "IdEstudianteTipo", "Nombre");
            ViewData["IdModalidadTipo"] = new SelectList(_context.ModalidadesTipos, "IdModalidadTipo", "Nombre");
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "IdProfesor", "Nombre");
            return View();
        }

        // POST: FactInscripcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactInscripcion,IdEstudiante,IdEstudianteTipo,IdModalidadTipo,IdFecha,IdAnioEscolar,IdCurso,IdProfesor,IdEdad,IdCondicion,IdCentro,ImporteInscripcion,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] FactInscripcion factInscripcion)
        {
            string centro = User.Claims.FirstOrDefault(x => x.Type == "CentroId").Value;

            if (ModelState.IsValid)
            {
                factInscripcion.Estado = 1;
                factInscripcion.CreadoPor = 1;
                factInscripcion.IdCentro = Convert.ToInt32(centro);
                factInscripcion.FechaCreado = DateTime.Now;
                _context.Add(factInscripcion);

                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }
            //ViewData["IdAnioEscolar"] = new SelectList(_context.AnioEscolars, "IdAnioEscolar", "IdAnioEscolar", factInscripcion.IdAnioEscolar.Anio);
            //ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", factInscripcion.IdCentroNavigation.Nombre);
            //ViewData["IdCondicion"] = new SelectList(_context.Condiciones, "IdCondicion", "IdCondicion", factInscripcion.IdCondicionNavigation.Nombre);
            //ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", factInscripcion.IdCursoNavigation.Nombre);
            //ViewData["IdEdad"] = new SelectList(_context.Edades, "IdEdad", "IdEdad", factInscripcion.IdEdadNavigation.Edad);
            //ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", factInscripcion.IdEstudianteNavigation.Nombre);
            //ViewData["IdEstudianteTipo"] = new SelectList(_context.EstudiantesTipos, "IdEstudianteTipo", "IdEstudianteTipo", factInscripcion.IdEstudianteTipoNavigation.Nombre);
            //ViewData["IdModalidadTipo"] = new SelectList(_context.ModalidadesTipos, "IdModalidadTipo", "IdModalidadTipo", factInscripcion.IdModalidadTipoNavigation.Nombre);
            //ViewData["IdProfesor"] = new SelectList(_context.Profesores, "IdProfesor", "IdProfesor", factInscripcion.IdProfesorNavigation.Nombre);
            return RedirectToAction("index");
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
            ViewData["IdAnioEscolar"] = new SelectList(_context.AnioEscolars, "IdAnioEscolar", "Anio");
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "Nombre");
            ViewData["IdCondicion"] = new SelectList(_context.Condiciones, "IdCondicion", "Nombre");
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "Nombre");
            ViewData["IdEdad"] = new SelectList(_context.Edades, "IdEdad", "Edad");
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Nombre");
            ViewData["IdEstudianteTipo"] = new SelectList(_context.EstudiantesTipos, "IdEstudianteTipo", "Nombre");
            ViewData["IdModalidadTipo"] = new SelectList(_context.ModalidadesTipos, "IdModalidadTipo", "Nombre");
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "IdProfesor", "Nombre");
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
                    var oldfactInscripcion = await _context.FactInscripcions.FindAsync(factInscripcion.IdFactInscripcion);
                    oldfactInscripcion.IdAnioEscolar = factInscripcion.IdAnioEscolar;
                    oldfactInscripcion.IdEstudiante = factInscripcion.IdEstudiante;
                    oldfactInscripcion.IdModalidadTipo = factInscripcion.IdModalidadTipo;
                    oldfactInscripcion.IdEstudianteTipo = factInscripcion.IdEstudianteTipo;
                    oldfactInscripcion.IdProfesor = factInscripcion.IdProfesor;
                    oldfactInscripcion.IdCurso = factInscripcion.IdCurso;
                    oldfactInscripcion.IdEdad = factInscripcion.IdEdad;
                    oldfactInscripcion.IdCondicion = factInscripcion.IdCondicion;
                    oldfactInscripcion.IdCentro = factInscripcion.IdCentro;
                    oldfactInscripcion.ImporteInscripcion = factInscripcion.ImporteInscripcion;

                    oldfactInscripcion.ModificadoPor = 1;
                    factInscripcion.FechaModificado = DateTime.Now;

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
            ViewData["IdAnioEscolar"] = new SelectList(_context.AnioEscolars, "IdAnioEscolar", "IdAnioEscolar", factInscripcion.IdAnioEscolarNavigation.Anio);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", factInscripcion.IdCentroNavigation.Nombre);
            ViewData["IdCondicion"] = new SelectList(_context.Condiciones, "IdCondicion", "IdCondicion", factInscripcion.IdCondicionNavigation.Nombre);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "IdCurso", factInscripcion.IdCursoNavigation.Nombre);
            ViewData["IdEdad"] = new SelectList(_context.Edades, "IdEdad", "IdEdad", factInscripcion.IdEdadNavigation.Edad);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "IdEstudiante", "IdEstudiante", factInscripcion.IdEstudianteNavigation.Nombre);
            ViewData["IdEstudianteTipo"] = new SelectList(_context.EstudiantesTipos, "IdEstudianteTipo", "IdEstudianteTipo", factInscripcion.IdEstudianteTipoNavigation.Nombre);
            ViewData["IdModalidadTipo"] = new SelectList(_context.ModalidadesTipos, "IdModalidadTipo", "IdModalidadTipo", factInscripcion.IdModalidadTipoNavigation.Nombre);
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "IdProfesor", "IdProfesor", factInscripcion.IdProfesorNavigation.Nombre);


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
            factInscripcion.Estado = 9;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactInscripcionExists(int id)
        {
            return _context.FactInscripcions.Any(e => e.IdFactInscripcion == id);
        }
    }
}
