using ECommerceAPI.Application.Abstractions.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x = ECommerceAPI.Application.Abstractions.DTOs.Product;

namespace ECommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public string ErrorMessage { get; set; }
        public x.CreateProductDTO Product { get; set; }
    }
}
