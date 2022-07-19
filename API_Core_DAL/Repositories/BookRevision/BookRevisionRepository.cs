using API_Core_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Core_DAL
{
    public class BookRevisionRepository : IBookRevisionRepository
    {
        private readonly DbEfContext _dbContext;

        public BookRevisionRepository(DbEfContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BookRevision>> GetAllAboutBook(Guid id)
        {
            return await _dbContext.BookRevisions
                .Include(x => x.Book)
                .Where(x => x.BookId == id)
                .ToListAsync();
        }
    }
}
