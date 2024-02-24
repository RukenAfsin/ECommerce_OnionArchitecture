using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Exceptions.Product
{
    public class ProductExceptions : Exception
    {
        public ProductExceptions(string? message) : base(message)
        {
        }
    }
}
