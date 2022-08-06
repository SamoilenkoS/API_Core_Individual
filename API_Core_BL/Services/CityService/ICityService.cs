using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.CitySevice
{
    public interface ICityService
    {
        Task<City> GetCityByIdAsync(Guid id);
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<Guid> AddCityAsync(City city);
        Task<bool> DeleteCityAsync(Guid id);
        Task<bool> UpdateCityAsync(City city);
    }
}
