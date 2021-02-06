using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentaPeliculas.Data.Entities
{
    public class Pelicula
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PeliculaID { get; set; }
        public string NombrePelicula { get; set; }
        public int Año { get; set; }
        public string Duracion { get; set; }

        public ICollection<Prestamo> Prestamos { get; set; }
    }
}
