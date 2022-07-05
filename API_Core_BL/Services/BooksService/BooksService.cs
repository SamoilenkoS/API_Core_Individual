using API_Core_DAL;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.BooksService
{
    public class BooksService : IBooksService
    {
        private readonly IRepository<Book> _booksRepository;

        public BooksService(IRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
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
    }
}
