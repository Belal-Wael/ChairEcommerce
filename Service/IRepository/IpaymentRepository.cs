using ChairEcommerce.Models;

namespace ChairEcommerce.Service.IRepository
{
    public interface IpaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        Task AddAsync(Payment Payment);
        Task UpdateAsync(Payment Payment);
        Task DeleteAsync(int id);
        Task Save();
    }
}
