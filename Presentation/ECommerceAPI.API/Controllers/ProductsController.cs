using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await   _productWriteRepository.AddRangeAsync(new()
            //  {
            //      new(){Id=Guid.NewGuid(),Name="Product1", Price=100, CreatedDate=DateTime.UtcNow, Stock=10},
            //      new(){Id=Guid.NewGuid(),Name="Product2", Price=200, CreatedDate=DateTime.UtcNow, Stock=20},
            //      new(){Id=Guid.NewGuid(),Name="Product3", Price=300, CreatedDate=DateTime.UtcNow, Stock=30}
            //  });
            //var count= await  _productWriteRepository.SaveAsync();

           Product p= await _productReadRepository.GetByIdAsync("24293129-c391-4412-a7af-244c03da1800");
            p.Name = "Ahmet";
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
             Product product= await  _productReadRepository.GetByIdAsync(id);
             return Ok(product);
        }
    }
}
