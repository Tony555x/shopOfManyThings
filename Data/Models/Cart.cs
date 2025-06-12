using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOfManyThings.Data.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId{ get; set; }
        public User User { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
    }
}
