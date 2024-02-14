using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p= ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Repositories.ProductImage
{
    public interface IProductImageReadRepository:IReadRepository<p.ProductImage>
    {
    }
}
