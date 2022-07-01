using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Core_DAL
{
    public class BooksRepository : IBooksRepository
    {
        private EFCoreContext _dbContext;

        public BooksRepository(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
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
            return await _dbContext.Books.ToListAsync();
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
