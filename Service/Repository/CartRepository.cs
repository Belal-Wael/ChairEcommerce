using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ChairEcommerce.Service.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _appDbContext;
        public CartRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
      
        public async Task DeleteAsync(int id)
        {
            var cart = await GetByIdAsync(id);
            if (cart != null)
            {
                _appDbContext.Cart.Remove(cart);
                await Save();
            }
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _appDbContext.Cart.ToListAsync();
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            if (id != 0)
            {
                return await _appDbContext.Cart.FirstOrDefaultAsync(x => x.Id == id);
            }
            return null;
        }



        public async Task UpdateAsync(Cart cart)
        {
            _appDbContext.Cart.Update(cart);
            await Save();
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task AddProductAsync(string userId, int productId, int quantity = 1)
        {
            var user=await _appDbContext.users.Include(u=>u.Cart)
                           .ThenInclude(c=>c.Items)
                           .FirstOrDefaultAsync(u=>u.Id==userId);

            if (user != null) {

                var cart = user.Cart ?? new Cart{ userId = userId, Items = new List<CartItem>() };
                var cartItems=cart.Items.FirstOrDefault(c=>c.productId==productId);

                if (cartItems != null) { 
                
                  cartItems.Quantity += quantity;
                }
                else
                {
                    var cartItem = new CartItem
                    {
                        productId = productId,
                        Quantity = quantity
                    };
                    cart.Items.Add(cartItem);
                    await _appDbContext.CartItems.AddAsync(cartItem);
                }
                _appDbContext.Cart.Update(cart);
               await Save();

            }
        }

        public async Task<List<Cart>> GetByUserIdAsync(string userId)
        {
            return await _appDbContext.Cart.Where(c=>c.userId==userId)
                .Include(c=>c.Items)
                .ThenInclude(it=>it.Product)
                .ToListAsync();
                 
        }

       
    }
}
