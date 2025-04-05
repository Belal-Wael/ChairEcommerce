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
        public async Task<IActionResult> ShowCart()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null) { 
            
                string userId = user.Id;
                var carts = await _cartRepository.GetByUserIdAsync(userId);
                //var items = carts[0];
                //ViewBag.Cart = carts;
          
                return Json(carts);
            }
            return NotFound();
        }



        public IActionResult UpdateCart()
        {
            return View();
        }
    }
}
