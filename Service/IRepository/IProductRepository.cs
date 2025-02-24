using ChairEcommerce.Models;

namespace ChairEcommerce.Service.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product Product);
        Task UpdateAsync(Product Product);
        Task<IEnumerable<Product>> GetProductsByCatName(string catName);
        Task DeleteAsync(int id);
        Task Save();
    }
}
