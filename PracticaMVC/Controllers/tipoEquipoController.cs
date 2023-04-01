using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class tipoEquipoController : Controller
    {
        private readonly equiposDbContext _context;

        public tipoEquipoController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: tipoEquipo
        public async Task<IActionResult> Index()
        {
              return _context.tipoEquipo != null ? 
                          View(await _context.tipoEquipo.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.tipoEquipo'  is null.");
        }

        // GET: tipoEquipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tipoEquipo == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.tipoEquipo
                .FirstOrDefaultAsync(m => m.id_tipo_equipo == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // GET: tipoEquipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tipoEquipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tipo_equipo,descripcion,estado")] tipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEquipo);
        }

        // GET: tipoEquipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tipoEquipo == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.tipoEquipo.FindAsync(id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }
            return View(tipoEquipo);
        }

        // POST: tipoEquipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tipo_equipo,descripcion,estado")] tipoEquipo tipoEquipo)
        {
            if (id != tipoEquipo.id_tipo_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tipoEquipoExists(tipoEquipo.id_tipo_equipo))
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
            return View(tipoEquipo);
        }

        // GET: tipoEquipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tipoEquipo == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.tipoEquipo
                .FirstOrDefaultAsync(m => m.id_tipo_equipo == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // POST: tipoEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tipoEquipo == null)
            {
                return Problem("Entity set 'equiposDbContext.tipoEquipo'  is null.");
            }
            var tipoEquipo = await _context.tipoEquipo.FindAsync(id);
            if (tipoEquipo != null)
            {
                _context.tipoEquipo.Remove(tipoEquipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tipoEquipoExists(int id)
        {
          return (_context.tipoEquipo?.Any(e => e.id_tipo_equipo == id)).GetValueOrDefault();
        }
    }
}
