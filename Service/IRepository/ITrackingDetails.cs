using ChairEcommerce.Models;

namespace ChairEcommerce.Service.IRepository
{
    public interface ITrackingDetails
    {
        Task<IEnumerable<TrackingDetails>> GetAllAsync();
        Task<TrackingDetails> GetByIdAsync(int id);
        Task AddAsync(TrackingDetails TrackingDetails);
        Task UpdateAsync(TrackingDetails TrackingDetails);
        Task DeleteAsync(int id);
        Task Save();
    }
}
