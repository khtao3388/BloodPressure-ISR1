using BloodPressure.Models;

namespace BloodPressure.Repository
{
    public interface IBPReadingRepository
    {
        Task<BPReading> GetByIdAsync(int id);
        Task<IEnumerable<BPReading>> GetAllAsync();
        Task<IEnumerable<BPReading>> GetByMonth(int year, int month);
        Task AddAsync(BPReading bpReading);
        Task UpdateAsync(BPReading bpReading);
        Task DeleteAsync(int id);

    }
}
