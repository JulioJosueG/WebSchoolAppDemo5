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
    public class PersonalDistritoesController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public PersonalDistritoesController(DWDistrito0503Context context)
        {
            _context = context;
        }

        // GET: PersonalDistritoes
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DepartamentoSortParm = String.IsNullOrEmpty(sortOrder) ? "dept_desc" : "Departamento";
            ViewBag.DistritoSortParm = String.IsNullOrEmpty(sortOrder) ? "distr_desc" : "Distrito";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var personalD = from s in _context.PersonalDistritos.Include(a => a.IdDepartamentoNavigation).Include(b => b.IdDistritoNavigation)
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                personalD = personalD.Where(s => s.Apellido.Contains(searchString)
                                       || s.Nombre.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    personalD = personalD.OrderByDescending(s => s.Apellido);
                    break;
                case "Departamento":
                    personalD = personalD.OrderBy(s => s.IdDepartamento);
                    break;

                case "dept_desc":
                    personalD = personalD.OrderByDescending(s => s.IdDepartamento);
                    break;
                case "Distrito":
                    personalD = personalD.OrderBy(s => s.IdDistrito);
                    break;
                case "distr_desc":
                    personalD = personalD.OrderByDescending(s => s.IdDistrito);
                    break;
                default:
                    personalD = personalD.OrderBy(s => s.Apellido);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(await personalD.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: PersonalDistritoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDistrito = await _context.PersonalDistritos
                .Include(p => p.CreadoPorNavigation)
                .Include(p => p.IdDepartamentoNavigation)
                .Include(p => p.IdDistritoNavigation)
                .Include(p => p.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonalDistrito == id);
            if (personalDistrito == null)
            {
                return NotFound();
            }

            return View(personalDistrito);
        }

        // GET: PersonalDistritoes/Create
        public IActionResult Create()
        {
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "Nombre");
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo");
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            return View();
        }

        // POST: PersonalDistritoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonalDistrito,Nombre,Apellido,Cedula,IdDepartamento,IdDistrito,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] PersonalDistrito personalDistrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalDistrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalDistrito.CreadoPor);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "Nombre", personalDistrito.IdDepartamento);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo", personalDistrito.IdDistrito);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalDistrito.ModificadoPor);
            return View(personalDistrito);
        }

        // GET: PersonalDistritoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDistrito = await _context.PersonalDistritos.FindAsync(id);
            if (personalDistrito == null)
            {
                return NotFound();
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalDistrito.CreadoPor);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", personalDistrito.IdDepartamento);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo", personalDistrito.IdDistrito);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalDistrito.ModificadoPor);
            return View(personalDistrito);
        }

        // POST: PersonalDistritoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersonalDistrito,Nombre,Apellido,Cedula,IdDepartamento,IdDistrito,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] PersonalDistrito personalDistrito)
        {
            if (id != personalDistrito.IdPersonalDistrito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalDistrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalDistritoExists(personalDistrito.IdPersonalDistrito))
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
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalDistrito.CreadoPor);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", personalDistrito.IdDepartamento);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo", personalDistrito.IdDistrito);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalDistrito.ModificadoPor);
            return View(personalDistrito);
        }

        // GET: PersonalDistritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalDistrito = await _context.PersonalDistritos
                .Include(p => p.CreadoPorNavigation)
                .Include(p => p.IdDepartamentoNavigation)
                .Include(p => p.IdDistritoNavigation)
                .Include(p => p.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonalDistrito == id);
            if (personalDistrito == null)
            {
                return NotFound();
            }

            return View(personalDistrito);
        }

        // POST: PersonalDistritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalDistrito = await _context.PersonalDistritos.FindAsync(id);
            _context.PersonalDistritos.Remove(personalDistrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalDistritoExists(int id)
        {
            return _context.PersonalDistritos.Any(e => e.IdPersonalDistrito == id);
        }
    }
}
