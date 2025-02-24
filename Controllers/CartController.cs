using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChairEcommerce.Controllers  
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<User> _userManager;
        public CartController(ICartRepository cartRepository, UserManager<User> userManager)
        {
            _cartRepository = cartRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult>  ShowCart()
        {
            var user = await _userManager.GetUserAsync(User);
            string userId = user.Id;
            var carts = await _cartRepository.GetByUserIdAsync(userId);
            var products = carts.SelectMany(c => c.Items.Select(i => i.Product)).ToList();

            return PartialView("userCart", products);
        }
        public IActionResult UpdateCart()
        {
            return View();
        }
    }
}
