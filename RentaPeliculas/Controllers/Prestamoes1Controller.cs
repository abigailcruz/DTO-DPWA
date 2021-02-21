using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentaPeliculas.Data;
using RentaPeliculas.Data.Entities;
using RentaPeliculas.DTO;

namespace RentaPeliculas.Controllers
{
    public class Prestamoes1Controller : Controller
    {
        private readonly RentaPeli _context;
        private readonly IMapper mapper;

        public Prestamoes1Controller(RentaPeli context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Prestamoes1
        public async Task<IActionResult> Index()
        {
            var data = await _context.Prestamos.Include(p => p.Client).Include(p => p.Pelicula).ToListAsync();
            var listClientes = data.Select(x => mapper.Map<PrestamoDTO>(x)).ToList();
            return View(listClientes);
        }

        // GET: Prestamoes1/Details/5
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

            var prestamoDTO = mapper.Map<PrestamoDTO>(prestamo);

            return View(prestamoDTO);
        }

        // GET: Prestamoes1/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clientes, "ID", "ID");
            ViewData["PeliculaID"] = new SelectList(_context.Peliculas, "PeliculaID", "PeliculaID");
            return View();
        }

        // POST: Prestamoes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestamoID,FechaPrestamo,FechaDevolucion,ClientID,PeliculaID")] PrestamoDTO prestamoDTO)
        {
            var prestamo = mapper.Map<Prestamo>(prestamoDTO);
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clientes, "ID", "ID", prestamoDTO.ClientID);
            ViewData["PeliculaID"] = new SelectList(_context.Peliculas, "PeliculaID", "PeliculaID", prestamoDTO.PeliculaID);

            return View(prestamoDTO);
        }

        // GET: Prestamoes1/Edit/5
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

            var prestamoDTO = mapper.Map<PrestamoDTO>(prestamo);
            return View(prestamoDTO);
        }

        // POST: Prestamoes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrestamoID,FechaPrestamo,FechaDevolucion,ClientID,PeliculaID")] PrestamoDTO prestamoDTO)
        {
            var prestamo = mapper.Map<Prestamo>(prestamoDTO);

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
            return View(prestamoDTO);
        }

        // GET: Prestamoes1/Delete/5
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

        // POST: Prestamoes1/Delete/5
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
