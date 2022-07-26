using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SumeraWebsiteApi.Data;
using SumeraWebsiteApi.Data.Dto;
using SumeraWebsiteApi.Data.Models;

namespace SumeraWebsiteApi.services
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CityService(ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<List<CityDto>> GetAllAsync()
        {
            var cities = await _mapper.ProjectTo<CityDto>(_dbContext.cities).ToListAsync();
            return cities;
        }
        public async Task CreateAsync(CityDto city)
        {
            var cityModel = _mapper.Map<City>(city);
            _dbContext.Add(cityModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _dbContext.cities.FindAsync(id);
            if (city == null)
            {
                _dbContext.cities.Remove(city);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.cities.AnyAsync(x => x.Id == id);
        }


        public async Task<CityDto?> GetByIdAsync(int id)
        {
            var cities = await _mapper.ProjectTo<CityDto>(_dbContext.cities).FirstOrDefaultAsync(x => x.Id == id);
            return cities;
        }

        public async Task UpdateAsync(CityDto city)
        {
            var cities = _mapper.Map<City>(city);
            _dbContext.Update(cities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
