using ChairEcommerce.Models;

namespace ChairEcommerce.Service.IRepository
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart> GetByIdAsync(int id);
        Task AddProductAsync(string userId, int productId, int quantity=1);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(int id);
        Task<List<Cart>> GetByUserIdAsync(string userId);
        Task Save();
    }
}
