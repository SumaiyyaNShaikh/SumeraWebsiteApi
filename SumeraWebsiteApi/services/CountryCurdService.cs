using SumeraWebsiteApi.Data.Models;
using SumeraWebsiteApi.Repository_Pattern;

namespace SumeraWebsiteApi.services
{
    public class CountryCurdService : ICountryCurdService
    {
        private readonly ICountryRepository _countryRepository ;

        public CountryCurdService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task CreateAsync(Country country)
        {
            await _countryRepository.CreateAsync(country);
        }

        public async Task DeleteAsync(int id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _countryRepository.GetAllAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _countryRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Country country)
        {
           await _countryRepository.UpdateAsync(country);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _countryRepository.Exists(id);
        }


    }
}
