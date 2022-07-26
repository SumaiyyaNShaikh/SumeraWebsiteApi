using Microsoft.EntityFrameworkCore;
using SumeraWebsiteApi.Data;
using SumeraWebsiteApi.Data.Models;

namespace SumeraWebsiteApi.Repository_Pattern
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
      
             public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                _context.Countries.Remove(country);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Countries.AnyAsync(e => e.Id == id);
        }

        public async Task<List<Country>> GetAllAsync()
        {

         return await _context.Countries.ToListAsync();
        }

        public Task<Country?> GetByIdAsync(int id)
        {
            var country = _context.Countries.FirstOrDefaultAsync(e => e.Id == id);
            return country;
        }

        public async Task UpdateAsync(Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
        }
    }
}
