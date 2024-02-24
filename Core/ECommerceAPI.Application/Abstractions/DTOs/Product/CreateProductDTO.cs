using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.DTOs.Product
{
    public class CreateProductDTO
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }
    }
}
