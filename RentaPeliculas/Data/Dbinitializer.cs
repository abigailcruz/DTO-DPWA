using RentaPeliculas.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaPeliculas.Data
{
    public static class Dbinitializer
    {
        public static void Initialize(RentaPeli context)
        {
            context.Database.EnsureCreated();

            //Look for clientes
            if (context.Clientes.Any())
            {
                return; //DB has been seeded
            }

            var clients = new Client[]
            {
                new Client{LastName="Marquez",FirstName="Jhojaira",Telephone="75757364",Direction = "Col. Santa Julia"},
                new Client{LastName="Cruz",FirstName="Fatima",Telephone="65482547",Direction = "Col. Santa Lucia"},
                new Client{LastName="Fernandez",FirstName="Karla",Telephone="75897356",Direction = "Col. San Juan"},
                new Client{LastName = "Morales", FirstName = "Jeronimo", Telephone="78557964", Direction = "Barrio La Cruz"},
                new Client{LastName = "Perez", FirstName = "Jennifer", Telephone="74527364", Direction = "Col. El Molino" },
            };
            foreach (Client c in clients)
            {
                context.Clientes.Add(c);
            }
            context.SaveChanges();

            //Look for peliculas
           /* if (context.Peliculas.Any())
            {
                return; //DB has been seeded
            }*/

            var peliculas = new Pelicula[]
            {
                new Pelicula{NombrePelicula = "Milagro en la celda 7",Año=2019,Duracion="2h 12min"},
                new Pelicula{NombrePelicula = "Avengers: Endgame",Año=2019,Duracion="3h 2min"},
                new Pelicula{NombrePelicula = "La Cabaña",Año=2017,Duracion="2h 13min"},
                new Pelicula{NombrePelicula = "La Viuda",Año = 2018,Duracion="1h 38min"},
                new Pelicula{NombrePelicula = "Mentes Poderosas",Año = 2018,Duracion ="1h 43min"}
            };
            foreach (Pelicula p in peliculas)
            {
                context.Peliculas.Add(p);
            };

            context.SaveChanges();

            //Look for prestamos
           /*if (context.Prestamos.Any())
            {
                return; //DB has been seeded
            }*/

            var prestamos = new Prestamo[]
            {
                new Prestamo{FechaPrestamo = DateTime.Parse("2021-01-08"),FechaDevolucion = DateTime.Parse("2021-01-11"),ClientID = 1,PeliculaID = 10 },
                new Prestamo{FechaPrestamo = DateTime.Parse("2021-01-09"),FechaDevolucion = DateTime.Parse("2021-01-11"),ClientID = 2,PeliculaID = 13 },
                new Prestamo{FechaPrestamo = DateTime.Parse("2021-01-15"),FechaDevolucion = DateTime.Parse("2021-01-17"),ClientID = 3,PeliculaID = 15 },
                new Prestamo{FechaPrestamo = DateTime.Parse("2021-01-28"),FechaDevolucion = DateTime.Parse("2021-01-30"),ClientID = 4,PeliculaID = 17 },
                new Prestamo{FechaPrestamo = DateTime.Parse("2021-01-28"),FechaDevolucion = DateTime.Parse("2021-01-31"),ClientID = 5,PeliculaID = 18 }
            };
            foreach (Prestamo r in prestamos)
            {
                context.Prestamos.Add(r);
            };

            context.SaveChanges();
        }
        
    }
};
