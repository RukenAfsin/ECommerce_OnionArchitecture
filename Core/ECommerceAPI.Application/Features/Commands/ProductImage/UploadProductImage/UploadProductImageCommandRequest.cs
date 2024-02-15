using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage
{
    public class UploadProductImageCommandRequest : IRequest<UploadProductImageCommandResponse>
    {
        // FromForm özniteliğiyle dosyaları almak için File özelliği ekleniyor
        [FromForm(Name = "file")]
        public IFormFile File { get; set; }

        // FromQuery özniteliğiyle alınan Id özelliği değiştirilmiyor
        public string Id { get; set; }
    }
}
