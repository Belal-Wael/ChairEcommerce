using ChairEcommerce.Service.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChairEcommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> checkOut()
        {
             var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
             await _orderRepository.CheckOut(userID);
            return View("PaymentPage");
        }
        public IActionResult PaymentPage()
        {
            return View();
        }
    }
}
