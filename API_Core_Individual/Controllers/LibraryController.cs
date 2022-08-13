using API_Core_BL.DTOs;
using API_Core_BL.Services.LibraryService;
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
    public class LibraryController : ControllerBase
    {
        private readonly ILogger<LibraryController> _logger;
        private readonly ILibraryService _libraryService;

        public LibraryController(
            ILibraryService libraryService,
            ILogger<LibraryController> logger)
        {
            _libraryService = libraryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Library>> GetAllLibrariesAsync()
        {
            _logger.LogInformation("Called get all libraries");

            return await _libraryService.GetAllLibrariesAsync();
        }

        [HttpGet("{id}")]
        public async Task<Library> GetLibraryById(Guid id)
        {
            return await _libraryService.GetLibraryByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateLibrary(Guid id, Library library)
        {
            library.Id = id;

            return await _libraryService.UpdateLibraryAsync(library);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteLibrary(Guid id)
        {
            return await _libraryService.DeleteLibraryAsync(id);
        }

        [HttpPost]
        public async Task<Guid> CreateLibrary(LibraryDto libraryDto)
        {
            return await _libraryService.AddLibraryAsync(libraryDto);
        }
    }
}
