using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ChairEcommerce.Service.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _appDbContext;
        public AddressRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Address address)
        {
            await _appDbContext.Addresss.AddAsync(address);
            await Save();
        }

        public async Task DeleteAsync(int id)
        {
            var add = await GetByIdAsync(id);
            if (add!=null)
            {
               _appDbContext.Addresss.Remove(add);
                await Save();
            }
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _appDbContext.Addresss.ToListAsync();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            if (id != 0)
            {
                return await _appDbContext.Addresss.FirstOrDefaultAsync(x => x.Id == id);
            }
            return null;
        }

     

        public async Task UpdateAsync(Address address)
        {
            _appDbContext.Addresss.Update(address);
            await Save();
        }

        public async Task Save()
        {
          await _appDbContext.SaveChangesAsync();
        }
    }
}
