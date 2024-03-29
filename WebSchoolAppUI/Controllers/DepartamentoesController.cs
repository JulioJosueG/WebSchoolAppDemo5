﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSchoolAppUI.Models;

namespace WebSchoolAppUI.Views
{
    public class DepartamentoesController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public DepartamentoesController(DWDistrito0503Context context)
        {
            _context = context;
        }

        // GET: Departamentoes
        public async Task<IActionResult> Index()
        {
            string centro = User.Claims.FirstOrDefault(x => x.Type == "CentroId").Value;

            var dWDistrito0503Context = _context.Departamentos.Where(x => x.Estado == 1 && x.IdCentro.ToString() == centro).Include(d => d.CreadoPorNavigation)
                .Include(d => d.IdCentroNavigation)
                .Where(d => d.Estado==1);
            return View(await dWDistrito0503Context.ToListAsync());
        }

        // GET: Departamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .Include(d => d.IdCentroNavigation)
                .FirstOrDefaultAsync(m => m.IdDepartamento == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamentoes/Create
        public IActionResult Create()
        {
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "Nombre");
            return View();
        }

        // POST: Departamentoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDepartamento,Nombre,IdCentro,CreadoPor,FechaCreado")] Departamento departamento)
        {
            string centro = User.Claims.FirstOrDefault(x => x.Type == "CentroId").Value;
            var oldDepartamento = _context.Departamentos.Where(x => x.Nombre.Trim() == departamento.Nombre.Trim() && x.Estado==1).FirstOrDefault();
            if (oldDepartamento != null)
            {
                return BadRequest("Ya existe dicho departamento");
            }
            if (ModelState.IsValid)
            {
                departamento.CreadoPor = 1;
                departamento.FechaCreado = DateTime.Now;
                departamento.Estado = 1;
                departamento.IdCentro = Convert.ToInt32(centro);
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", departamento.CreadoPor);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "Nombre", departamento.IdCentro);
            return View(departamento);
        }

        // GET: Departamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", departamento.CreadoPor);
            return View(departamento);
        }

        // POST: Departamentoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDepartamento,Nombre,IdCentro,ModificadoPor")] Departamento departamento)
        {
            if (id != departamento.IdDepartamento)
            {
                return NotFound();
            }
            var oldDepartamentos = _context.Departamentos.Where(x => x.Nombre.Trim() == departamento.Nombre.Trim() && x.Estado == 1 && id != x.IdDepartamento).FirstOrDefault();
            if (oldDepartamentos != null)
            {
                return BadRequest("Ya existe dicho departamento");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var oldDepartamento = await _context.Departamentos.FindAsync(departamento.IdDepartamento);

                    oldDepartamento.Nombre = departamento.Nombre;
                    departamento.FechaModificado = DateTime.Now;

                    oldDepartamento.ModificadoPor = 1;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.IdDepartamento))
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
            return View(departamento);
        }

        // GET: Departamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.IdDepartamento == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (ModelState.IsValid)
            {
                try
                {
                    departamento.Estado = 9;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.IdDepartamento))
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
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.IdDepartamento == id);
        }
    }
}
