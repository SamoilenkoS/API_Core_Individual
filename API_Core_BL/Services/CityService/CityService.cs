using API_Core_DAL;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.CitySevice
{
    public class CityService : ICityService
    {
        private readonly IGenericRepository<City> _cityRepository;

        public CityService(IGenericRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Guid> AddCityAsync(City city)
        {
            return await _cityRepository.AddAsync(city);
        }

        public async Task<bool> DeleteCityAsync(Guid id)
        {
            return await _cityRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllAsync();
        }

        public async Task<City> GetCityByIdAsync(Guid id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateCityAsync(City city)
        {
            return await _cityRepository.UpdateAsync(city);
        }
    }
}
