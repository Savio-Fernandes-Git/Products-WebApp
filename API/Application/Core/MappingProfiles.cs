using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //products
            CreateMap<Product, ProductsReadWriteDto>();
            CreateMap<Product, ProductDetailsReadDto>()
                .ForMember( dest => dest.CategoryName, src => src.MapFrom( x => x.Category.CategoryName));
            CreateMap<ProductsReadWriteDto, Product>();
            //categories
            CreateMap<Category, CategoriesReadWriteDto>();
            CreateMap<CategoriesReadWriteDto, Category>();
        }

    }
}