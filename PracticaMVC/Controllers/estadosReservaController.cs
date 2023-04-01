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
    public class estadosReservaController : Controller
    {
        private readonly equiposDbContext _context;

        public estadosReservaController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: estadosReserva
        public async Task<IActionResult> Index()
        {
              return _context.estadosReservas != null ? 
                          View(await _context.estadosReservas.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.estadosReservas'  is null.");
        }

        // GET: estadosReserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estadosReservas == null)
            {
                return NotFound();
            }

            var estadosReserva = await _context.estadosReservas
                .FirstOrDefaultAsync(m => m.estados_res_id == id);
            if (estadosReserva == null)
            {
                return NotFound();
            }

            return View(estadosReserva);
        }

        // GET: estadosReserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estadosReserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("estados_res_id,estado")] estadosReserva estadosReserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosReserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosReserva);
        }

        // GET: estadosReserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.estadosReservas == null)
            {
                return NotFound();
            }

            var estadosReserva = await _context.estadosReservas.FindAsync(id);
            if (estadosReserva == null)
            {
                return NotFound();
            }
            return View(estadosReserva);
        }

        // POST: estadosReserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("estados_res_id,estado")] estadosReserva estadosReserva)
        {
            if (id != estadosReserva.estados_res_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosReserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estadosReservaExists(estadosReserva.estados_res_id))
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
            return View(estadosReserva);
        }

        // GET: estadosReserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estadosReservas == null)
            {
                return NotFound();
            }

            var estadosReserva = await _context.estadosReservas
                .FirstOrDefaultAsync(m => m.estados_res_id == id);
            if (estadosReserva == null)
            {
                return NotFound();
            }

            return View(estadosReserva);
        }

        // POST: estadosReserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estadosReservas == null)
            {
                return Problem("Entity set 'equiposDbContext.estadosReservas'  is null.");
            }
            var estadosReserva = await _context.estadosReservas.FindAsync(id);
            if (estadosReserva != null)
            {
                _context.estadosReservas.Remove(estadosReserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estadosReservaExists(int id)
        {
          return (_context.estadosReservas?.Any(e => e.estados_res_id == id)).GetValueOrDefault();
        }
    }
}
