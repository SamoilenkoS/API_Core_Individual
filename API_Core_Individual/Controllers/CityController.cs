using API_Core_BL.Services.CitySevice;
using API_Core_DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_Individual.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityService _cityService;

        public CityController(
            ICityService cityService,
            ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            _logger.LogInformation("Called get all cities");

            return await _cityService.GetAllCitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<City> GetCityById(Guid id)
        {
            return await _cityService.GetCityByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateCity(Guid id, City city)
        {
            city.Id = id;

            return await _cityService.UpdateCityAsync(city);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCity(Guid id)
        {
            return await _cityService.DeleteCityAsync(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<Guid> CreateCity(City city)
        {
            return await _cityService.AddCityAsync(city);
        }
    }
}
