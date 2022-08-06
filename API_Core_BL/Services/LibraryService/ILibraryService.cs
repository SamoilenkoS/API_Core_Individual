using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.LibraryService
{
    public interface ILibraryService
    {
        Task<Library> GetLibraryByIdAsync(Guid id);
        Task<IEnumerable<Library>> GetAllLibrariesAsync();
        Task<Guid> AddLibraryAsync(Library library);
        Task<bool> DeleteLibraryAsync(Guid id);
        Task<bool> UpdateLibraryAsync(Library library);
    }
}
