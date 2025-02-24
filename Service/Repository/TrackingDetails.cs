using ChairEcommerce.Models;
using ChairEcommerce.Service.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ChairEcommerce.Service.Repository
{
    public class TrackingDetails : ITrackingDetails
    {
        private readonly AppDbContext _appDbContext;
        public TrackingDetails(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Models.TrackingDetails TrackingDetails)
        {
            await _appDbContext.TrackingDetails.AddAsync(TrackingDetails);
            await Save();
        }

        public async Task DeleteAsync(int id)
        {
            var de = await GetByIdAsync(id);
            if (de != null)
            {
                _appDbContext.TrackingDetails.Remove(de);
                await Save();
            }
        }

        public async Task<IEnumerable<Models.TrackingDetails>> GetAllAsync()
        {
            return await _appDbContext.TrackingDetails.ToListAsync();
        }

        public async Task<Models.TrackingDetails> GetByIdAsync(int id)
        {
            return await _appDbContext.TrackingDetails.FindAsync(id);
        }

        public async Task UpdateAsync(Models.TrackingDetails TrackingDetails)
        {
            _appDbContext.TrackingDetails.Update(TrackingDetails);
            await Save();
        }
        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }

    }
}
