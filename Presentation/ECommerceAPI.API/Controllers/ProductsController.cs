using ECommerceAPI.Application.Features.Commands.CreateProduct;
using ECommerceAPI.Application.Features.Queries.GetAllProduct;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.RequestParameters;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.ViewModels.Products;
using ECommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        readonly IFileService _fileService;

        public ProductsController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public ProductsController(IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            this._webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllProductQueryRequest getAllProductQueryRequest )
        {
          GetAllProductQueryResponse response = await  _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }


        [HttpGet("getid")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommandRequest createProductCommandRequest)
        {
           CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete (string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult>Upload()
        //{
        //   await  _fileService.UploadAsync("resource/product-images",Request.Form.Files);
        //    return Ok();
           

        //}


    }
}
