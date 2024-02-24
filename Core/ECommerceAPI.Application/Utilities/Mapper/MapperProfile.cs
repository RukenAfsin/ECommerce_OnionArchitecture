using AutoMapper;
using ECommerceAPI.Application.Abstractions.DTOs.Product;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Utilities.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
        }
    }
}
