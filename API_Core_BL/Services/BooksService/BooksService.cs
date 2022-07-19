using API_Core_BL.DTOs;
using API_Core_DAL;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Core_BL.Services.BooksService
{
    public class BooksService : IBooksService
    {
        private readonly IGenericRepository<Book> _booksRepository;
        private readonly IBookRevisionRepository _bookRevisionRepository;

        public BooksService(IGenericRepository<Book> booksRepository, IBookRevisionRepository bookRevisionRepository)
        {
            _booksRepository = booksRepository;
            _bookRevisionRepository = bookRevisionRepository;
        }

        public async Task<Guid> AddBookAsync(Book book)
        {
            return await _booksRepository.AddAsync(book);
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            return await _booksRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _booksRepository.GetAllAsync();
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _booksRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            return await _booksRepository.UpdateAsync(book);
        }

        public async Task<BookDto> GetAllAboutBook(Guid id)
        {
            var bookRevisions = await _bookRevisionRepository.GetAllAboutBook(id);

            if (!bookRevisions.Any())
            {
                throw new ArgumentException();
            }

            var book = bookRevisions.First().Book;

            return new BookDto
            {
                BookId = book.Id,
                Author = book.Author,
                Title = book.Title,
                BookRevisions = bookRevisions.Select(
                    bookRevision => new BookRevisionDto
                    {
                        LostPrice = bookRevision.LostPrice,
                        PagesCount = bookRevision.PagesCount,
                        PublishedCount = bookRevision.PublishedCount,
                        Year = bookRevision.Year
                    })
            };
        }
    }
}
