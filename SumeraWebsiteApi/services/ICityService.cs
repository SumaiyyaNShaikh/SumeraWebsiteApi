using SumeraWebsiteApi.Data.Dto;
using SumeraWebsiteApi.Data.Models;

namespace SumeraWebsiteApi.services
{
    public interface ICityService
    {
        public Task<List<CityDto>> GetAllAsync();

        public Task<CityDto?> GetByIdAsync(int id);
        public Task CreateAsync(CityDto city);
        public Task UpdateAsync(CityDto city);
        public Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
