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
    public class PersonalCentroesController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public PersonalCentroesController(DWDistrito0503Context context)
        {
            _context = context;
        }

        // GET: PersonalCentroes
        public async Task<IActionResult> Index()
        {
            var dWDistrito0503Context = _context.PersonalCentros.Include(p => p.CreadoPorNavigation).Include(p => p.IdCentroNavigation).Include(p => p.IdDepartamentoNavigation).Include(p => p.ModificadoPorNavigation);
            return View(await dWDistrito0503Context.ToListAsync());
        }

        // GET: PersonalCentroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalCentro = await _context.PersonalCentros
                .Include(p => p.CreadoPorNavigation)
                .Include(p => p.IdCentroNavigation)
                .Include(p => p.IdDepartamentoNavigation)
                .Include(p => p.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonalCentro == id);
            if (personalCentro == null)
            {
                return NotFound();
            }

            return View(personalCentro);
        }

        // GET: PersonalCentroes/Create
        public IActionResult Create()
        {
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo");
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento");
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            return View();
        }

        // POST: PersonalCentroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonalCentro,Nombre,Apellido,Cedula,IdDepartamento,IdCentro,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] PersonalCentro personalCentro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalCentro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalCentro.CreadoPor);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", personalCentro.IdCentro);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", personalCentro.IdDepartamento);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalCentro.ModificadoPor);
            return View(personalCentro);
        }

        // GET: PersonalCentroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalCentro = await _context.PersonalCentros.FindAsync(id);
            if (personalCentro == null)
            {
                return NotFound();
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalCentro.CreadoPor);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", personalCentro.IdCentro);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", personalCentro.IdDepartamento);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalCentro.ModificadoPor);
            return View(personalCentro);
        }

        // POST: PersonalCentroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersonalCentro,Nombre,Apellido,Cedula,IdDepartamento,IdCentro,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] PersonalCentro personalCentro)
        {
            if (id != personalCentro.IdPersonalCentro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalCentro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalCentroExists(personalCentro.IdPersonalCentro))
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
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalCentro.CreadoPor);
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos, "IdCentroEducativo", "IdCentroEducativo", personalCentro.IdCentro);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", personalCentro.IdDepartamento);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", personalCentro.ModificadoPor);
            return View(personalCentro);
        }

        // GET: PersonalCentroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalCentro = await _context.PersonalCentros
                .Include(p => p.CreadoPorNavigation)
                .Include(p => p.IdCentroNavigation)
                .Include(p => p.IdDepartamentoNavigation)
                .Include(p => p.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonalCentro == id);
            if (personalCentro == null)
            {
                return NotFound();
            }

            return View(personalCentro);
        }

        // POST: PersonalCentroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalCentro = await _context.PersonalCentros.FindAsync(id);
            _context.PersonalCentros.Remove(personalCentro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalCentroExists(int id)
        {
            return _context.PersonalCentros.Any(e => e.IdPersonalCentro == id);
        }
    }
}
