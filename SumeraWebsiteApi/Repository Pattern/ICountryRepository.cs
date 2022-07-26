using SumeraWebsiteApi.Data.Models;

namespace SumeraWebsiteApi.Repository_Pattern
{
    public interface ICountryRepository
    {

        public Task<List<Country>> GetAllAsync();

        public Task<Country?> GetByIdAsync(int id);

        public Task CreateAsync(Country country);

        public Task UpdateAsync(Country country);

        public Task DeleteAsync(int id);
        Task<bool> Exists(int employeeId);
    }
}
