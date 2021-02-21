using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentaPeliculas.DTO
{
    public class ClienteDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo apellido no puede estar vacio")]
        [Display(Name = "Apellido de Cliente")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vacio")]
        [Display(Name = "Nombre de Cliente")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo Telefono no puede estar vacio")]
        [Display(Name = "Telefono de Cliente")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "El campo direccion no puede estar vacio")]
        [Display(Name = "Direccion de Cliente")]
        public string Direction { get; set; }
    }
}
