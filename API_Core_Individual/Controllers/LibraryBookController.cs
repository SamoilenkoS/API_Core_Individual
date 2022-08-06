using API_Core_BL.Services.LibraryBookService;
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
    public class LibraryBookController : ControllerBase
    {
        private readonly ILogger<LibraryBookController> _logger;
        private readonly ILibraryBookService _libraryBookService;

        public LibraryBookController(
            ILibraryBookService libraryBookService,
            ILogger<LibraryBookController> logger)
        {
            _libraryBookService = libraryBookService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<LibraryBook>> GetAllLibraryBooksAsync()
        {
            _logger.LogInformation("Called get all library books");

            return await _libraryBookService.GetAllLibraryBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<LibraryBook> GetLibraryBookById(Guid id)
        {
            return await _libraryBookService.GetLibraryBookByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateLibraryBook(Guid id, LibraryBook libraryBook)
        {
            libraryBook.Id = id;

            return await _libraryBookService.UpdateLibraryBookAsync(libraryBook);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<bool> DeleteLibraryBook(Guid id)
        {
            return await _libraryBookService.DeleteLibraryBookAsync(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<Guid> CreateLibraryBook(LibraryBook libraryBook)
        {
            return await _libraryBookService.AddLibraryBookAsync(libraryBook);
        }
    }
}
