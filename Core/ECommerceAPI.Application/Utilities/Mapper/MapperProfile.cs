using AutoMapper;
using ECommerceAPI.Application.Abstractions.DTOs.Product;
using ECommerceAPI.Application.Abstractions.DTOs.ProductImage;
using ECommerceAPI.Application.Abstractions.DTOs.User;
using ECommerceAPI.Application.Features.Commands.AppUser.CreateUser;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Commands.Product.UpdateProduct;
using ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProduct;
using ECommerceAPI.Application.Features.Queries.Product.GetByIdProduct;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;
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
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDTO>();
            CreateMap<ProductImage, UploadProductImageCommandRequest>();
            //CreateMap<AppUser, CreateUserDTO>().ReverseMap();
            //CreateMap<AppUser, CreateUserCommandRequest>().ReverseMap();
            CreateMap<Product, GetByIdProductQueryResponse>().ReverseMap();
            CreateMap<Product, GetAllProductDTO>().ReverseMap();
        }
    }
}
