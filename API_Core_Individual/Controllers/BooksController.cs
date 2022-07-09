using API_Core_BL;
using API_Core_BL.DTOs;
using API_Core_BL.Services.BooksService;
using API_Core_DAL;
using API_Core_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            _logger.LogInformation("Called get all books");

            return await _booksService.GetAllBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookById(Guid id)
        {
            return await _booksService.GetBookByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateBook(Guid id, Book book)
        {
            book.Id = id;

            return await _booksService.UpdateBookAsync(book);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteBook(Guid id)
        {
            return await _booksService.DeleteBookAsync(id);
        }

        [HttpPost]
        public async Task<Guid> CreateBook(Book book)
        {
            return await _booksService.AddBookAsync(book);
        }

        [HttpGet("test/{id}")]
        public async Task<IActionResult> GetSomething(Guid id)
        {
            BookDto bookInfo = null;
            try
            {
                bookInfo = await _booksService.GetAllAboutBook(id);
            }
            catch (ArgumentException)
            {
            }

            return bookInfo != null ? Ok(bookInfo) : BadRequest();
        }
    }
}
