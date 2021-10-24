using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest_Product._2.Application.DTOs;
using ApiRest_Product._3.Persistence;
using AutoMapper;

namespace ApiRest_Product._4.Infrastructure.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDOM, ProductDTO>().ReverseMap();
        }
    }
}
