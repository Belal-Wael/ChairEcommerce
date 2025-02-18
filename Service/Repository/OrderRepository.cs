using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ChairEcommerce.Service.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Order order)
        {
            await _appDbContext.Orders.AddAsync(order);
            await Save();
        }

        public async Task DeleteAsync(int id)
        {
            var add = await GetByIdAsync(id);
            if (add != null)
            {
                _appDbContext.Orders.Remove(add);
                await Save();
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _appDbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            if (id != 0)
            {
                return await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            }
            return null;
        }



        public async Task UpdateAsync(Order order)
        {
            _appDbContext.Orders.Update(order);
            await Save();
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
