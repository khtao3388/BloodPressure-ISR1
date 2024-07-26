

using BloodPressure.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodPressure.Repository
{
    public class BPReadingRepository : IBPReadingRepository
    {
        private readonly BPReadingContext _context;

        public BPReadingRepository(BPReadingContext context)
        {
            _context = context;
        }

        public async Task<BPReading> GetByIdAsync(int id)
        {
            return await _context.BPReading.FindAsync(id);
        }

        public async Task<IEnumerable<BPReading>> GetAllAsync()
        {
            return await _context.BPReading.ToListAsync();
        }

        public async Task AddAsync(BPReading bpReading)
        {
            await _context.BPReading.AddAsync(bpReading);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BPReading bpReading)
        {
            _context.Attach(bpReading).State=EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bpReading = await _context.BPReading.FindAsync(id);
            if (bpReading != null)
            {
                _context.BPReading.Remove(bpReading);
                await _context.SaveChangesAsync();
            }
        }
    }
}
