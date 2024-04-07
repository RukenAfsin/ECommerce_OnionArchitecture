using ECommerceAPI.Domain.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceAPI.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImagePath { get; set; }
        public Guid ProductId { get; set; } 

        [ForeignKey("ProductId")] 
        public Product Product { get; set; }
    }
}
