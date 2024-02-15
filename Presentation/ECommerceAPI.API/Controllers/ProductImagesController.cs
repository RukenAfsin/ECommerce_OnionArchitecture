using ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.ProductImage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage.UploadProductImageCommandResponse;

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
        [HttpPost("upload")]
        public async Task<UploadProductImageCommandResponse> UploadImage([FromForm] IFormFile file, [FromQuery] string productId)
        {
            var response = new UploadProductImageCommandResponse();

            if (file != null)
            {
                response.Status = UploadProductImageCommandResponse.UploadStatus.Success;
            }
            else
            {
                response.Status = UploadProductImageCommandResponse.UploadStatus.Failure;
            }

            response.SetMessage();

            return response;
        }


    }






}

