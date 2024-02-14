using ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.ProductImage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        IProductReadRepository _productReadRepository;
        private readonly IProductImageWriteRepository _productImageWriteRepository;
        private readonly IProductImageReadRepository _productImageReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImagesController(IMediator mediator,
                                       IProductImageWriteRepository productImageWriteRepository,
                                       IProductImageReadRepository productImageReadRepository,
                                       IWebHostEnvironment webHostEnvironment,
                                       IProductReadRepository productReadRepository)
        {
            _mediator = mediator;
            _productImageWriteRepository = productImageWriteRepository;
            _productImageReadRepository = productImageReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _productReadRepository = productReadRepository;
        }
        // UploadImage metodunda ürün ID'sinin alınması ve isteğe atanması
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromQuery] string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest("Ürün ID'si belirtilmemiş.");
            }

            var request = new UploadProductImageCommandRequest
            {
                File = file,
                Id = productId 
            };

            var response = await _mediator.Send(request);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Resim yüklenirken bir hata oluştu.");
            }
        }


    }
}
