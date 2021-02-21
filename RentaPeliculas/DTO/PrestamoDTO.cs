using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentaPeliculas.DTO
{
    public class PrestamoDTO
    {
        public int PrestamoID { get; set; }
        [Required(ErrorMessage = "El campo fecha de prestamo no puede estar vacio")]
        [Display(Name = "Fecha de Prestamo")]
        public DateTime FechaPrestamo { get; set; }
        [Required(ErrorMessage = "El campo Fecha de devolucion no puede estar vacio")]
        [Display(Name = "Fecha de Devolucion")]
        public DateTime FechaDevolucion { get; set; }
        [Required(ErrorMessage = "El campo IdCliente no puede estar vacio")]
        [Display(Name = "Id Cliente")]
        public int ClientID { get; set; }
        [Required(ErrorMessage = "El campo pelicula no puede estar vacio")]
        [Display(Name = "ID Pelicula")]
        public int PeliculaID { get; set; }

        public ClienteDTO Client { get; set; }
        public PeliculaDTO Pelicula { get; set; }
    }
}
