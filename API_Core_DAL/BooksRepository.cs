using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Guid> AddBookAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book.Id;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var book = _dbContext.Books.Where(x => x.Id == id).First();
            _dbContext.Books.Remove(book);
            return await _dbContext.SaveChangesAsync() != 0;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _dbContext.Books
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            _dbContext.Books.Attach(book);

            _dbContext.Entry(book).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync() != 0;
        }
    }
}
