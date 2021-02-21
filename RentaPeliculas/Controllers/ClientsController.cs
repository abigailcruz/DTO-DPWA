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
    public class ClientsController : Controller
    {
        //INYECCION DE DEPENDENCIAS
        private readonly RentaPeli _context;

        private readonly IMapper mapper;

        public ClientsController(RentaPeli context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var data = await _context.Clientes.ToListAsync();
            var listClientes = data.Select(x => mapper.Map<ClienteDTO>(x)).ToList();
            return View(listClientes);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }
            var clienteDTO = mapper.Map<ClienteDTO>(client);
            return View(clienteDTO);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,Telephone,Direction")] ClienteDTO clienteDTO)
        {
            var client = mapper.Map<Client>(clienteDTO);

            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDTO);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clientes.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var clienteDTO = mapper.Map<ClienteDTO>(client);
            return View(clienteDTO);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,Telephone,Direction")] ClienteDTO clienteDTO)
        {
            var client = mapper.Map<Client>(clienteDTO);

            if (id != client.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ID))
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
            return View(clienteDTO);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clientes.Any(e => e.ID == id);
        }
    }
}
