using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChairEcommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }

        // UserID as FK
        [ForeignKey("User")]
        [JsonIgnore]
        public string userId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> Items { get; set; }

    }
}
