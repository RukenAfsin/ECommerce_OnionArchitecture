using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.SomeFeatures.Rules
{
    public class ProductBusinessRules
    {
        IProductWriteRepository _productWriteRepository;
        IProductReadRepository _productReadRepository;

        public ProductBusinessRules(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task ProductNameCanNotBeDuplicated(string name)
        {
            Product result = await _productReadRepository.GetAll(tracking: true).FirstOrDefaultAsync(x => x.Name == name);
            if (result != null)
            {
                throw new ArgumentException(nameof(name), "is  already exists.");
            }

        }

    }
}
