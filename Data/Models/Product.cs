using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopOfManyThings.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        public string Category { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
