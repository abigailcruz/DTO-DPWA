using Microsoft.EntityFrameworkCore;
using RentaPeliculas.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaPeliculas.Data
{
    public class RentaPeli : DbContext
    {
        public RentaPeli(DbContextOptions<RentaPeli> options) : base(options)
        {

        }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Prestamo> Prestamos{ get; set; }
        public DbSet<Client> Clientes { get; set; }
    }
}
