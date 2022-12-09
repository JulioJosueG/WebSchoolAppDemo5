using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSchoolAppUI.Models;
using X.PagedList;

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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            string distrito = User.Claims.FirstOrDefault(x => x.Type == "DistritoId").Value;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var centros = from s in _context.CentrosEducativos.Where(x => x.Estado == 1 && x.IdDistrito.ToString() == distrito).Include(a => a.IdDistritoNavigation)
                          .Include(d => d.IdTipoCentroNavigation)
                          .Where(d => d.Estado == 1)
                          select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                centros = centros.Where(s => s.Nombre.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    centros = centros.OrderByDescending(s => s.IdDistritoNavigation);
                    break;
                default:
                    centros = centros.OrderBy(s => s.IdDistritoNavigation);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(await centros.ToPagedListAsync(pageNumber, pageSize));

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
            
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo");
            ViewData["IdTipoCentro"] = new SelectList(_context.TipoCentros, "IdTipoCentro", "Nombre");
            
            return View();
        }

        // POST: CentrosEducativoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCentroEducativo,Nombre,IdTipoCentro,IdDistrito")] CentrosEducativo centrosEducativo)
        {
            string distrito = User.Claims.FirstOrDefault(x => x.Type == "DistritoId").Value;

            if (ModelState.IsValid)
            {
                _context.Add(new CentrosEducativo { 
                Nombre = centrosEducativo.Nombre,
                IdTipoCentro = centrosEducativo.IdTipoCentro,
                IdDistrito = Convert.ToInt32(distrito),
                CreadoPor = centrosEducativo.CreadoPor = 1,
                Estado = 1,
                FechaCreado = DateTime.Now
                
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo", centrosEducativo.IdDistrito);
            ViewData["IdTipoCentro"] = new SelectList(_context.TipoCentros, "IdTipoCentro", "IdTipoCentro", centrosEducativo.IdTipoCentro);
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
            ViewData["IdDistrito"] = new SelectList(_context.Distritos, "IdDistrito", "Codigo", centrosEducativo.IdDistrito);
            ViewData["IdTipoCentro"] = new SelectList(_context.TipoCentros, "IdTipoCentro", "Nombre", centrosEducativo.IdTipoCentro);
            return View(centrosEducativo);
        }

        // POST: CentrosEducativoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCentroEducativo,Nombre,IdTipoCentro,IdDistrito,ModificadoPor,FechaModificado")] CentrosEducativo centrosEducativo)
        {
            if (id != centrosEducativo.IdCentroEducativo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldcentro = await _context.CentrosEducativos.FindAsync(centrosEducativo.IdCentroEducativo);
                    oldcentro.Nombre = centrosEducativo.Nombre;
                    oldcentro.IdTipoCentro = centrosEducativo.IdTipoCentro ;
                    oldcentro.CreadoPor = 1;
                    oldcentro.ModificadoPor = 1;
                    oldcentro.FechaModificado = DateTime.UtcNow.Date;
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
            ViewData["IdTipoCentro"] = new SelectList(_context.TipoCentros, "IdTipoCentro", "Nombre", centrosEducativo.IdTipoCentro);
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
            var centros = await _context.CentrosEducativos.FindAsync(id);
            if (ModelState.IsValid)
            {
                try
                {
                    centros.Estado = 9;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentrosEducativoExists(centros.IdCentroEducativo))
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

        private bool CentrosEducativoExists(int id)
        {
            return _context.CentrosEducativos.Any(e => e.IdCentroEducativo == id);
        }
    }
}
