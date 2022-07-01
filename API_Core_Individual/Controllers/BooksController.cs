using API_Core_BL;
using API_Core_DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Core_Individual.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService _booksService;

        public BooksController(
            IBooksService booksService,
            ILogger<BooksController> logger)
        {
            _booksService = booksService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _booksService.GetAllBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookById(Guid id)
        {
            return null;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateBook(Guid id, Book book)
        {
            return true;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteBook(Guid id)
        {
            return true;
        }

        [HttpPost]
        public async Task<Guid> CreateBook(Book book)
        {
            return Guid.NewGuid();
        }
    }
}
