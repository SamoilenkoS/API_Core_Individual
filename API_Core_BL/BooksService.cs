using API_Core_DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Guid> AddBookAsync(Book book)
        {
            return await _booksRepository.AddBookAsync(book);
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            return await _booksRepository.DeleteBookAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _booksRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _booksRepository.GetBookByIdAsync(id);
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            return await _booksRepository.UpdateBookAsync(book);
        }
    }
}
