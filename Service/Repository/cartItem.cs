using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;

namespace ChairEcommerce.Service.Repository
{
    public class cartItem : IcartItem
    {
        private readonly AppDbContext _appDbContext;
        public cartItem(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task  DeleteAsync(int id)
        {
           var cartitem= _appDbContext.CartItems.FirstOrDefault(c => c.Id == id);
           _appDbContext.CartItems.Remove(cartitem);
           await  _appDbContext.SaveChangesAsync();
        }
    }
}
