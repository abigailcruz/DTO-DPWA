using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentaPeliculas.DTO;
using RentaPeliculas.Models;
using RentaPeliculas.Data.Entities;

namespace RentaPeliculas.DTO
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ClienteDTO, Client>();
            CreateMap<Client, ClienteDTO>();

            CreateMap<PeliculaDTO, Pelicula>();
            CreateMap<Pelicula, PeliculaDTO>();

            CreateMap<PrestamoDTO, Prestamo>();
            CreateMap<Prestamo, PrestamoDTO>();
        }
    }
}
