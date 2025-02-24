using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChairEcommerce.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid price format")]
        public decimal Price { get; set; } = 0;

        public string imageUrl { get; set; }

        [ForeignKey("Category")]
        public int catID { get; set; }
        public Category Category { get; set; }

    }
}
