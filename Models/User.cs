using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChairEcommerce.Models
{
    public class User:IdentityUser
    {


        public ICollection<Order> Orders { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
