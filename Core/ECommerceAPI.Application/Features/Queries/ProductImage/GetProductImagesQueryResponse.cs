using ECommerceAPI.Application.Abstractions.DTOs.Product;
using ECommerceAPI.Application.Abstractions.DTOs.ProductImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductImage
{
    public class GetProductImagesQueryResponse
    {
        public List<GetAllProductImageDTO> ProductImage { get; set; }
    }
}
