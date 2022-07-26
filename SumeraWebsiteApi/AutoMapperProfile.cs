using AutoMapper;
using SumeraWebsiteApi.Data.Dto;
using SumeraWebsiteApi.Data.Models;

namespace SumeraWebsiteApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<City, CityDto>()
             .ForMember(evw => evw.CountryName, opt => opt.MapFrom(em => em.Country.Name))
             .ReverseMap()
              .ForPath(em => em.Country.Name, opt => opt.Ignore());
              

        }
    }
}
