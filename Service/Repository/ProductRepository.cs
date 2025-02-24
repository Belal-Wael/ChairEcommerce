using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ChairEcommerce.Service.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await Save();
        }

        public async Task DeleteAsync(int id)
        {
            var add = await GetByIdAsync(id);
            if (add != null)
            {
                _appDbContext.Products.Remove(add);
                await Save();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _appDbContext.Products
                .Include(c => c.Category)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            if (id != 0)
            {
                return await _appDbContext.Products.FindAsync(id);
            }
            return null;
        }



        public async Task UpdateAsync(Product product)
        {
            _appDbContext.Update(product);
            await Save();
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCatName(string catName)
        {
            return await _appDbContext.Products
                .Include(c => c.Category)
                .Where(p=>p.Category.Name==catName).ToListAsync();
        }
    }
}
