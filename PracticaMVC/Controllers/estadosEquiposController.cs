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
    public class estadosEquiposController : Controller
    {
        private readonly equiposDbContext _context;

        public estadosEquiposController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: estadosEquipos
        public async Task<IActionResult> Index()
        {
              return _context.estadosEquipo != null ? 
                          View(await _context.estadosEquipo.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.estadosEquipo'  is null.");
        }

        // GET: estadosEquipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estadosEquipo == null)
            {
                return NotFound();
            }

            var estadosEquipo = await _context.estadosEquipo
                .FirstOrDefaultAsync(m => m.id_estados_equipo == id);
            if (estadosEquipo == null)
            {
                return NotFound();
            }

            return View(estadosEquipo);
        }

        // GET: estadosEquipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estadosEquipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_estados_equipo,descripcion,estado")] estadosEquipo estadosEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosEquipo);
        }

        // GET: estadosEquipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.estadosEquipo == null)
            {
                return NotFound();
            }

            var estadosEquipo = await _context.estadosEquipo.FindAsync(id);
            if (estadosEquipo == null)
            {
                return NotFound();
            }
            return View(estadosEquipo);
        }

        // POST: estadosEquipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_estados_equipo,descripcion,estado")] estadosEquipo estadosEquipo)
        {
            if (id != estadosEquipo.id_estados_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estadosEquipoExists(estadosEquipo.id_estados_equipo))
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
            return View(estadosEquipo);
        }

        // GET: estadosEquipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estadosEquipo == null)
            {
                return NotFound();
            }

            var estadosEquipo = await _context.estadosEquipo
                .FirstOrDefaultAsync(m => m.id_estados_equipo == id);
            if (estadosEquipo == null)
            {
                return NotFound();
            }

            return View(estadosEquipo);
        }

        // POST: estadosEquipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estadosEquipo == null)
            {
                return Problem("Entity set 'equiposDbContext.estadosEquipo'  is null.");
            }
            var estadosEquipo = await _context.estadosEquipo.FindAsync(id);
            if (estadosEquipo != null)
            {
                _context.estadosEquipo.Remove(estadosEquipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estadosEquipoExists(int id)
        {
          return (_context.estadosEquipo?.Any(e => e.id_estados_equipo == id)).GetValueOrDefault();
        }
    }
}
