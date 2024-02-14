using ECommerceAPI.Application.Repositories.ProductImage;
using ECommerceAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p = ECommerceAPI.Domain.Entities;


namespace ECommerceAPI.Persistence.Repositories.ProductImage
{
    public class ProductImageWriteRepository :WriteRepository<p.ProductImage>, IProductImageWriteRepository
    {
        public ProductImageWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
