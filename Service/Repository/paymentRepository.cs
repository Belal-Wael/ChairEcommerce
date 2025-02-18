using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ChairEcommerce.Service.Repository
{
    public class paymentRepository:IpaymentRepository
    {
        private readonly AppDbContext _appDbContext;
        public paymentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Payment payment)
        {
            await _appDbContext.Payment.AddAsync(payment);
            await Save();
        }

        public async Task DeleteAsync(int id)
        {
            var add = await GetByIdAsync(id);
            if (add != null)
            {
                _appDbContext.Payment.Remove(add);
                await Save();
            }
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _appDbContext.Payment.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            if (id != 0)
            {
                return await _appDbContext.Payment.FirstOrDefaultAsync(x => x.Id == id);
            }
            return null;
        }



        public async Task UpdateAsync(Payment payment)
        {
            _appDbContext.Payment.Update(payment);
            await Save();
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
