using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public int? ProductId { get; set; } 
        public Product Product { get; set; }

      
    }
}
