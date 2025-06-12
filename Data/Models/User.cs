using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOfManyThings.Data.Models
{
    public class User : IdentityUser
    {
        public Cart Cart { get; set; }
    }
}
