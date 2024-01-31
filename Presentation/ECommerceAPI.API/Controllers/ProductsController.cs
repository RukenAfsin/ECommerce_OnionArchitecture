using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.ViewModels.Products;
using ECommerceAPI.Domain.Entities;
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
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;


        public ProductsController(IProductWriteRepository productWriteRepository, 
            IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
<<<<<<< HEAD

        }

   

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll(false));
=======
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll(false));
        }

       [HttpGet]
       public async Task<IActionResult>Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]

        public async Task<IActionResult> Post(VM_Create_Product model)
        {
           await  _productWriteRepository.AddAsync(new()
            {
                Name=model.Name,
                Price=model.Price,
                Stock=model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Updated_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
;        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
>>>>>>> 8a36b842f0fdc8602cc66fe9d13783769cb0762b
        }

        [HttpGet("getid")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id,false));
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(VM_Create_Product model )
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name=model.Name,
                Price=model.Price,
                Stock=model.Stock,
            });
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("post")]
        public async Task<IActionResult>Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult>Delete (string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }



    }
}
