using ChairEcommerce.Service.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ChairEcommerce.Controllers
{
    public class cartItemController : Controller
    {
        private readonly IcartItem _icartItem;
        public cartItemController(IcartItem icartItem)
        {
            _icartItem = icartItem;
        }
        public void removeFromCart(int itemid)
        {
           _icartItem.DeleteAsync(itemid); 
            //return RedirectToAction("ShowCart","Cart");
        }
    }
}
