using API_Core_BL.Services.LibraryRentService;
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
    public class LibraryRentController : ControllerBase
    {
        private readonly ILogger<LibraryRentController> _logger;
        private readonly ILibraryRentService _libraryRentService;

        public LibraryRentController(
            ILibraryRentService libraryRentService,
            ILogger<LibraryRentController> logger)
        {
            _libraryRentService = libraryRentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<LibraryRent>> GetAllLibraryRentAsync()
        {
            _logger.LogInformation("Called get all library rent");

            return await _libraryRentService.GetAllLibraryRentAsync();
        }

        [HttpGet("{id}")]
        public async Task<LibraryRent> GetLibraryRentById(Guid id)
        {
            return await _libraryRentService.GetLibraryRentByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateLibraryRent(Guid id, LibraryRent libraryRent)
        {
            libraryRent.Id = id;

            return await _libraryRentService.UpdateLibraryRentAsync(libraryRent);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<bool> DeleteLibraryRent(Guid id)
        {
            return await _libraryRentService.DeleteLibraryRentAsync(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<Guid> CreateLibraryRent(LibraryRent libraryRent)
        {
            return await _libraryRentService.AddLibraryRentAsync(libraryRent);
        }
    }
}
