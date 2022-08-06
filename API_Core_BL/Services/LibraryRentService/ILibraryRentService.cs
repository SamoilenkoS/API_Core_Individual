using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.LibraryRentService
{
    public interface ILibraryRentService
    {
        Task<LibraryRent> GetLibraryRentByIdAsync(Guid id);
        Task<IEnumerable<LibraryRent>> GetAllLibraryRentAsync();
        Task<Guid> AddLibraryRentAsync(LibraryRent libraryRent);
        Task<bool> DeleteLibraryRentAsync(Guid id);
        Task<bool> UpdateLibraryRentAsync(LibraryRent libraryRent);
    }
}
