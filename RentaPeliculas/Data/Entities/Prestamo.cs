using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaPeliculas.Data.Entities
{
    public class Prestamo
    {
        public int PrestamoID { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int ClientID { get; set; }
        public int PeliculaID { get; set; }

        public Client Client { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
