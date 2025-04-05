using ChairEcommerce.Models;

namespace ChairEcommerce.Service.IRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);

        Task CheckOut(string userId);
        Task Save();
    }
}
