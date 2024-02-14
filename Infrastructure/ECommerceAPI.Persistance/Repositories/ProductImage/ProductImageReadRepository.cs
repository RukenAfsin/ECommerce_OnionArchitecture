using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.ProductImage;
using ECommerceAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p= ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Persistence.Repositories.ProductImage
{
    public class ProductImageReadRepository :ReadRepository<p.ProductImage>, IProductImageReadRepository
    {
        public ProductImageReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
