using ECommerceAPI.Application.Abstractions.DTOs.ProductImage;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Commands.Product.RemoveProduct;
using ECommerceAPI.Application.Features.Commands.Product.UpdateProduct;
using ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProduct;
using ECommerceAPI.Application.Features.Queries.Product.GetByIdProduct;
using ECommerceAPI.Application.Features.Queries.ProductImage;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.ProductImage;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.ViewModels.Products;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories.ProductImage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]

    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductImageWriteRepository _productImageWriteRepository;
        private readonly IProductImageReadRepository _productImageReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;     
        }



        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllProductQueryRequest getAllProductQueryRequest )
        {
          GetAllProductQueryResponse response = await  _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
           GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Add(CreateProductCommandRequest createProductCommandRequest)
        {
           CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return Ok();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Put([FromBody]UpdateProductCommandRequest updateProductCommandRequest)
        {

            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult>Delete ([FromRoute]RemoveProductCommandRequest removeProductCommandRequest)
        {
          RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);       
          return Ok();
        }


        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadProductImageCommandRequest uploadProductImageCommandRequest)
        {
            UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);
            return Ok();
        }

        [HttpGet("GetAllImage")]
        public async Task<IActionResult> GetImage([FromQuery]GetProductImagesQueryRequest getProductImagesQueryRequest)
        {
            GetProductImagesQueryResponse response =await _mediator.Send(getProductImagesQueryRequest);
            return Ok(response);
        }

    }
}
