using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentaPeliculas.Data;
using RentaPeliculas.Data.Entities;

namespace RentaPeliculas.Controllers
{
    public class PrestamoesController : Controller
    {
        private readonly RentaPeli _context;

        public PrestamoesController(RentaPeli context)
        {
            _context = context;
        }

        // GET: Prestamoes
        public async Task<IActionResult> Index()
        {
            var rentaPeli = _context.Prestamos.Include(p => p.Client).Include(p => p.Pelicula);
            return View(await rentaPeli.ToListAsync());
        }

        // GET: Prestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Client)
                .Include(p => p.Pelicula)
                .FirstOrDefaultAsync(m => m.PrestamoID == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clientes, "ID", "ID");
            ViewData["PeliculaID"] = new SelectList(_context.Peliculas, "PeliculaID", "PeliculaID");
            return View();
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestamoID,FechaPrestamo,FechaDevolucion,ClientID,PeliculaID")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clientes, "ID", "ID", prestamo.ClientID);
            ViewData["PeliculaID"] = new SelectList(_context.Peliculas, "PeliculaID", "PeliculaID", prestamo.PeliculaID);
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clientes, "ID", "ID", prestamo.ClientID);
            ViewData["PeliculaID"] = new SelectList(_context.Peliculas, "PeliculaID", "PeliculaID", prestamo.PeliculaID);
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrestamoID,FechaPrestamo,FechaDevolucion,ClientID,PeliculaID")] Prestamo prestamo)
        {
            if (id != prestamo.PrestamoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.PrestamoID))
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
            ViewData["ClientID"] = new SelectList(_context.Clientes, "ID", "ID", prestamo.ClientID);
            ViewData["PeliculaID"] = new SelectList(_context.Peliculas, "PeliculaID", "PeliculaID", prestamo.PeliculaID);
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Client)
                .Include(p => p.Pelicula)
                .FirstOrDefaultAsync(m => m.PrestamoID == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.PrestamoID == id);
        }
    }
}
