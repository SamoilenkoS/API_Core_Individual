using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.LibraryBookService
{
    public interface ILibraryBookService
    {
        Task<LibraryBook> GetLibraryBookByIdAsync(Guid id);
        Task<IEnumerable<LibraryBook>> GetAllLibraryBooksAsync();
        Task<Guid> AddLibraryBookAsync(LibraryBook libraryBook);
        Task<bool> DeleteLibraryBookAsync(Guid id);
        Task<bool> UpdateLibraryBookAsync(LibraryBook libraryBook);
    }
}
