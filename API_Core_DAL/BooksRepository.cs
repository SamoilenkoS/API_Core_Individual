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
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            var id = book.Id;
            return null;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            bool result;
            var book = _dbContext.Books.Where(x => x.Id == id).First();
            _dbContext.Books.Remove(book);
            result = _dbContext.SaveChanges() != 0;

            return result;
        }


        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public Task<Book> GetBookByIdAsync(Guid id)
        {
            return null/*_dbContext.Books.Where(x => x.Id == id).FirstOrDefault()*/;
        }

        public Task<bool> UpdateBookAsync(Book book)
        {
            bool result;

            _dbContext.Books.Attach(book);

            _dbContext.Entry(book).State = EntityState.Modified;

            result = _dbContext.SaveChanges() != 0;

            return null /*result*/;
        }
    }
}
