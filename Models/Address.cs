using System.ComponentModel.DataAnnotations.Schema;

namespace ChairEcommerce.Models
{
    public class Address
    {
        public int Id { get; set; } 
        public string Country { get; set; }
        public string City { get; set; }


        // Add User Fk
        [ForeignKey("User")]
        public string userId { get; set; }
        public User User { get; set; }
    }
}
