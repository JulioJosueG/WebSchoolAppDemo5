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

        public async Task<IActionResult> Index()
        {
            var dWDistrito0503Context = _context.PersonalCentros.Where(x => x.Estado == 1).Include(p => p.CreadoPorNavigation).Include(p => p.IdCentroNavigation).Include(p => p.IdDepartamentoNavigation).Include(p => p.ModificadoPorNavigation);
            return View(await dWDistrito0503Context.ToListAsync());
        }

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

        public IActionResult Create()
        {
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos.Where(x => x.Estado == 1), "IdCentroEducativo", "Nombre");
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos.Where(x=> x.Estado ==1), "IdDepartamento", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonalCentro,Nombre,Apellido,Cedula,IdDepartamento,IdCentro,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] PersonalCentro personalCentro)
        {
            var oldPersonal = _context.PersonalCentros.Where(x => x.Cedula == personalCentro.Cedula && x.Estado == 1).FirstOrDefault();
            if (oldPersonal != null)
            {
                return BadRequest("Cedula ya utilizada");
            }
            if (ModelState.IsValid)
            {
                _context.Add(personalCentro);
                personalCentro.Estado = 1;
                personalCentro.CreadoPor = 1;
                personalCentro.FechaCreado = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos.Where(x => x.Estado == 1), "IdCentroEducativo", "IdCentroEducativo", personalCentro.IdCentroNavigation.Nombre);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos.Where(x => x.Estado == 1), "IdDepartamento", "IdDepartamento", personalCentro.IdDepartamentoNavigation.Nombre);
            return View(personalCentro);
        }

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
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos.Where(x => x.Estado == 1), "IdCentroEducativo", "Nombre");
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos.Where(x => x.Estado == 1), "IdDepartamento", "Nombre");
            return View(personalCentro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersonalCentro,Nombre,Apellido,Cedula,IdDepartamento,IdCentro,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] PersonalCentro personalCentro)
        {
            if (id != personalCentro.IdPersonalCentro)
            {
                return NotFound();
            }
            var oldPersonal = _context.PersonalCentros.Where(x => x.Cedula == personalCentro.Cedula && x.Estado==1 && id != x.IdPersonalCentro).FirstOrDefault();
            if (oldPersonal != null)
            {
                return BadRequest("Cedula ya utilizada");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var oldpersonal = await _context.PersonalCentros.FindAsync(personalCentro.IdPersonalCentro);
                    oldpersonal.Apellido = personalCentro.Apellido;
                    oldpersonal.Cedula = personalCentro.Cedula;
                    oldpersonal.IdDepartamento = personalCentro.IdDepartamento;
                    oldpersonal.ModificadoPor = 1;
                    oldpersonal.Nombre = personalCentro.Nombre;
                    personalCentro.FechaModificado = DateTime.Now;
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
            ViewData["IdCentro"] = new SelectList(_context.CentrosEducativos.Where(x => x.Estado == 1), "IdCentroEducativo", "IdCentroEducativo", personalCentro.IdCentroNavigation.Nombre);
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos.Where(x => x.Estado == 1), "IdDepartamento", "IdDepartamento", personalCentro.IdDepartamentoNavigation.Nombre);
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
            personalCentro.Estado = 9;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalCentroExists(int id)
        {
            return _context.PersonalCentros.Any(e => e.IdPersonalCentro == id);
        }
    }
}
