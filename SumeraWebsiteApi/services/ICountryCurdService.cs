using SumeraWebsiteApi.Data.Models;

namespace SumeraWebsiteApi.services
{
    public interface ICountryCurdService
    {
        public Task<List<Country>> GetAllAsync();

        public Task<Country?> GetByIdAsync(int id);
        public Task CreateAsync(Country country);
        public Task UpdateAsync(Country country);
        public Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);

    }
}
