using API_Core_BL.DTOs;
using API_Core_DAL;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.BooksService
{
    public interface IBooksService
    {
        Task<Book> GetBookByIdAsync(Guid id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Guid> AddBookAsync(Book book);
        Task<bool> DeleteBookAsync(Guid id);
        Task<bool> UpdateBookAsync(Book book);
        Task<BookDto> GetAllAboutBook(Guid id);
    }
}
