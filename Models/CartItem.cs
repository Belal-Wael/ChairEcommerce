using System.ComponentModel.DataAnnotations.Schema;

namespace ChairEcommerce.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [ForeignKey("cart")]
        public int CartId {  get; set; }
        public Cart cart { get; set; }

        [ForeignKey("Product")]
        public int productId {  get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
