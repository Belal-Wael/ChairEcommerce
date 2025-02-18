using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ChairEcommerce.Service.Repository
{
    public class CartRepository:ICartRepository
    {
        private readonly AppDbContext _appDbContext;
        public CartRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Cart cart)
        {
            await _appDbContext.Cart.AddAsync(cart);
            await Save();
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
    }
}
