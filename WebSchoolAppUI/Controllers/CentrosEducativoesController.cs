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
    public class CentrosEducativoesController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public CentrosEducativoesController(DWDistrito0503Context context)
        {
            _context = context;
        }

        // GET: CentrosEducativoes
        public async Task<IActionResult> Index()
        {
            var dWDistrito0503Context = _context.CentrosEducativos.Include(c => c.CreadoPorNavigation).Include(c => c.IdDistritoNavigation).Include(c => c.IdTipoCentroNavigation).Include(c => c.ModificadoPorNavigation);
            return View(await dWDistrito0503Context.ToListAsync());
        }

        // GET: CentrosEducativoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centrosEducativo = await _context.CentrosEducativos
                .Include(c => c.CreadoPorNavigation)
                .Include(c => c.IdDistritoNavigation)
                .Include(c => c.IdTipoCentroNavigation)
                .Include(c => c.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdCentroEducativo == id);
            if (centrosEducativo == null)
            {
                return NotFound();
            }

            return View(centrosEducativo);
        }

        // GET: CentrosEducativoes/Create
        public IActionResult Create()
        {
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo");
            ViewData["IdTipoCentro"] = new SelectList(_context.TipoCentros, "IdTipoCentro", "IdTipoCentro");
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido");
            return View();
        }

        // POST: CentrosEducativoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCentroEducativo,Nombre,IdTipoCentro,IdDistrito,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] CentrosEducativo centrosEducativo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centrosEducativo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", centrosEducativo.CreadoPor);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo", centrosEducativo.IdDistrito);
            ViewData["IdTipoCentro"] = new SelectList(_context.TipoCentros, "IdTipoCentro", "IdTipoCentro", centrosEducativo.IdTipoCentro);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", centrosEducativo.ModificadoPor);
            return View(centrosEducativo);
        }

        // GET: CentrosEducativoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centrosEducativo = await _context.CentrosEducativos.FindAsync(id);
            if (centrosEducativo == null)
            {
                return NotFound();
            }
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", centrosEducativo.CreadoPor);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo", centrosEducativo.IdDistrito);
            ViewData["IdTipoCentro"] = new SelectList(_context.TipoCentros, "IdTipoCentro", "IdTipoCentro", centrosEducativo.IdTipoCentro);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", centrosEducativo.ModificadoPor);
            return View(centrosEducativo);
        }

        // POST: CentrosEducativoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCentroEducativo,Nombre,IdTipoCentro,IdDistrito,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] CentrosEducativo centrosEducativo)
        {
            if (id != centrosEducativo.IdCentroEducativo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centrosEducativo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentrosEducativoExists(centrosEducativo.IdCentroEducativo))
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
            ViewData["CreadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", centrosEducativo.CreadoPor);
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo", centrosEducativo.IdDistrito);
            ViewData["IdTipoCentro"] = new SelectList(_context.TipoCentros, "IdTipoCentro", "IdTipoCentro", centrosEducativo.IdTipoCentro);
            ViewData["ModificadoPor"] = new SelectList(_context.Usuarios, "IdUsuario", "Apellido", centrosEducativo.ModificadoPor);
            return View(centrosEducativo);
        }

        // GET: CentrosEducativoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centrosEducativo = await _context.CentrosEducativos
                .Include(c => c.CreadoPorNavigation)
                .Include(c => c.IdDistritoNavigation)
                .Include(c => c.IdTipoCentroNavigation)
                .Include(c => c.ModificadoPorNavigation)
                .FirstOrDefaultAsync(m => m.IdCentroEducativo == id);
            if (centrosEducativo == null)
            {
                return NotFound();
            }

            return View(centrosEducativo);
        }

        // POST: CentrosEducativoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centrosEducativo = await _context.CentrosEducativos.FindAsync(id);
            _context.CentrosEducativos.Remove(centrosEducativo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentrosEducativoExists(int id)
        {
            return _context.CentrosEducativos.Any(e => e.IdCentroEducativo == id);
        }
    }
}
