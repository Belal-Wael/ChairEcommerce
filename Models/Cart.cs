using System.ComponentModel.DataAnnotations.Schema;

namespace ChairEcommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }

        // UserID as FK
        [ForeignKey("User")]
        public string userId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> Items { get; set; }

    }
}
