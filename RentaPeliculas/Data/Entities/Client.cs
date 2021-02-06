using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaPeliculas.Data.Entities
{
    public class Client
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Telephone { get; set; }
        public string Direction { get; set; }


        public ICollection<Prestamo> Prestamos { get; set; }


    }
}
