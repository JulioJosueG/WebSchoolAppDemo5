using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSchoolAppUI.Models;

namespace WebSchoolAppUI.Controllers
{
    public class CentrosController : Controller
    {
        private readonly DWDistrito0503Context _context;

        public CentrosController(DWDistrito0503Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public async Task<ActionResult> ListarCentro()
        {
            var centros = _context.CentrosEducativos;

            return View( await centros.ToListAsync());

        }

        public async Task<ActionResult> EditarCentros(int? id)
        {
            var centro = await _context.CentrosEducativos
                .FirstOrDefaultAsync(m => m.IdCentroEducativo == id);
            return View(centro);
        }

        public async Task<ActionResult> Borrar(int? id)
        {
            var centro = await _context.CentrosEducativos
                .FirstOrDefaultAsync(m => m.IdCentroEducativo == id);
            return View(centro);
        }

        public async Task<ActionResult> Detalles(int? id)
        {
            var centro = await _context.CentrosEducativos
                .FirstOrDefaultAsync(m => m.IdCentroEducativo == id);
            return View(centro);
        }

        public IActionResult CrearCentro()
        {
            return View("CrearCentro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCentroEducativo,Nombre,IdTipoCentro,IdDistrito,CreadoPor,FechaCreado,ModificadoPor,FechaModificado")] CentrosEducativo centros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
          
            return View(centros);
        }
    }
}
