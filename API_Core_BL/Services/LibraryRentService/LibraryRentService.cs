using API_Core_DAL;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.LibraryRentService
{
    public class LibraryRentService : ILibraryRentService
    {
        private readonly IGenericRepository<LibraryRent> _libraryRentRepository;

        public LibraryRentService(IGenericRepository<LibraryRent> libraryRentRepository)
        {
            _libraryRentRepository = libraryRentRepository;
        }

        public async Task<Guid> AddLibraryRentAsync(LibraryRent libraryRent)
        {
            return await _libraryRentRepository.AddAsync(libraryRent);
        }

        public async Task<bool> DeleteLibraryRentAsync(Guid id)
        {
            return await _libraryRentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LibraryRent>> GetAllLibraryRentAsync()
        {
            return await _libraryRentRepository.GetAllAsync();
        }

        public async Task<LibraryRent> GetLibraryRentByIdAsync(Guid id)
        {
            return await _libraryRentRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateLibraryRentAsync(LibraryRent libraryRent)
        {
            return await _libraryRentRepository.UpdateAsync(libraryRent);
        }
    }
}
