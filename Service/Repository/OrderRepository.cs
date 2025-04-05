using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ChairEcommerce.Service.Repository
{
    public class OrderRepository : IOrderRepository
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

        public async Task CheckOut(string userId)
        {
            if (!string.IsNullOrEmpty(userId)) {

                var cartItems = await _appDbContext.CartItems.Include(p => p.Product)
                               .Where(c => c.cart.userId == userId)
                               .ToListAsync();
                if (!cartItems.Any()) { 
                   return;
                }


                    var totalAmount = cartItems.Sum(item => item.Product.Price * item.Quantity);
                var order = new Order
                {
                    UserID = userId,
                    TotalAmount = totalAmount,
                    DateTime = DateTime.Now,
                    Items = cartItems.Select(item => new OrderItem
                    {
                        ProductId = item.productId,
                        Quantity = item.Quantity,
                        Price = item.Product.Price,
                    }).ToList()
                };

                _appDbContext.Orders.Add(order);
                _appDbContext.CartItems.RemoveRange(cartItems);
                await Save();
            }
            else
            {
                return;
            }
        }
        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
