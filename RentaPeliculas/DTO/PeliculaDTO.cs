using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentaPeliculas.DTO
{
    public class PeliculaDTO
    {
        public int PeliculaID { get; set; }
        [Required(ErrorMessage = "El campo nombre no puede estar vacio")]
        [Display(Name = "Nombre de Pelicula")]
        public string NombrePelicula { get; set; }
        [Required(ErrorMessage = "El campo Año no puede estar vacio")]
        [Display(Name = "Año de Pelicula")]
        public int Año { get; set; }
        [Required(ErrorMessage = "El campo Duracion no puede estar vacio")]
        [Display(Name = "Duracion de Pelicula")]
        public string Duracion { get; set; }
    }
}
