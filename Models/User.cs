using Microsoft.AspNetCore.Identity;

namespace ChairEcommerce.Models
{
    public class User : IdentityUser
    {


        public ICollection<Order> Orders { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Payment> Payments { get; set; }

        public static implicit operator string?(User? v)
        {
            throw new NotImplementedException();
        }
    }
}
