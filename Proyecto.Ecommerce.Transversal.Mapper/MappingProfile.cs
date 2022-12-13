using System;
using AutoMapper;
using Proyecto.Ecommerce.Application.DTO;
using Proyecto.Ecommerce.Domain.Entity;

namespace Proyecto.Ecommerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customers, CustomersDTO>().ReverseMap();

            // Para realizar un mapeo campo a campo usamos esta sintaxis
            //CreateMap<Customers, CustomersDTO>().ReverseMap().ForMember(d => d.CustomerId, source => source.MapFrom(src => src.CustomerId));
        }
    }
}
