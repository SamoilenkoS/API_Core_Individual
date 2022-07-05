using API_Core_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Core_BL
{
    public class BooksService : IBooksService
    {
        private IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public Task<Guid> AddBookAsync(Book book)
        {
            return _booksRepository.AddBookAsync(book);
        }

        public Task<bool> DeleteBookAsync(Guid id)
        {
            return _booksRepository.DeleteBookAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _booksRepository.GetAllBooksAsync();
        }

        public Task<Book> GetBookByIdAsync(Guid id)
        {
            return _booksRepository.GetBookByIdAsync(id);
        }

        public Task<bool> UpdateBookAsync(Book book)
        {
            return _booksRepository.UpdateBookAsync(book);
        }
    }
}
