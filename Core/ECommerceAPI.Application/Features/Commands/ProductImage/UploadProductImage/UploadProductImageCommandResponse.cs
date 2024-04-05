using System;
using ECommerceAPI.Application.Abstractions.DTOs.ProductImage;
using ECommerceAPI.Application.Constants;
using p = ECommerceAPI.Application.Constants;

namespace ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage
{
    public class UploadProductImageCommandResponse
    {

        public string ErrorMessage { get; set; }
        public CreateProductImageDTO ProductImage { get; set; }

    }
}




