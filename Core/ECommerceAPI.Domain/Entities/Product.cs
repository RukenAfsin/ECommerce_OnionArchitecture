using ECommerceAPI.Domain.Entities.Common;
using System.Collections.Generic;

namespace ECommerceAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        //public ICollection<Order> Orders { get; set; }
        public ICollection<ProductImage> Images { get; set; } 
        public ICollection<BasketItem>BasketItems { get; set; }
    }
}

       
