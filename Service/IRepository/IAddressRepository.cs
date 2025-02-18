using ChairEcommerce.Models;

namespace ChairEcommerce.Service.IRepository
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address> GetByIdAsync(int id);
        Task AddAsync(Address address);
        Task UpdateAsync(Address address);
        Task DeleteAsync(int id);
        Task Save();
    }
}

