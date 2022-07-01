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
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _booksRepository.GetAllBooksAsync();
        }

        public Task<Book> GetBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
