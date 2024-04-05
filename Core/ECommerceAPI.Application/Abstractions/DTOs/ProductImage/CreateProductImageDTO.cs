using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.DTOs.ProductImage
{
    public class CreateProductImageDTO
    {
        [FromForm(Name = "file")]
        public IFormFile File { get; set; }
        public Guid Id { get; set; }
    }
}
