using System.ComponentModel.DataAnnotations.Schema;

namespace ChairEcommerce.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string userId { get; set; }
        public User User { get; set; }
        public string Method { get; set; }

        public Decimal Amount { get; set; }
    }
}
