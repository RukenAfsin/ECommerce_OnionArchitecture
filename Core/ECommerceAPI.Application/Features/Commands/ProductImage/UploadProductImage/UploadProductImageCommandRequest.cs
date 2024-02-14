using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage
{
    public class UploadProductImageCommandRequest:IRequest<UploadProductImageCommandResponse>
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
    }
}
