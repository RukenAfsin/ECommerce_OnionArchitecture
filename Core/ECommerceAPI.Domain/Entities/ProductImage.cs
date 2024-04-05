using ECommerceAPI.Domain.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceAPI.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImagePath { get; set; }
        public Guid ProductId { get; set; } // Product nesnesinin anahtarını tutacak alan

        [ForeignKey("ProductId")] // ProductId özelliğinin Product tablosundaki anahtara bir dış anahtar olduğunu belirtir
        public Product Product { get; set; }
    }
}
