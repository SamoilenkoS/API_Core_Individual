using API_Core_DAL;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.LibraryBookService
{
    public class LibraryBookService : ILibraryBookService
    {
        private readonly IGenericRepository<LibraryBook> _libraryBookRepository;

        public LibraryBookService(IGenericRepository<LibraryBook> libraryBookRepository)
        {
            _libraryBookRepository = libraryBookRepository;
        }

        public async Task<Guid> AddLibraryBookAsync(LibraryBook libraryBook)
        {
            return await _libraryBookRepository.AddAsync(libraryBook);
        }

        public async Task<bool> DeleteLibraryBookAsync(Guid id)
        {
            return await _libraryBookRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LibraryBook>> GetAllLibraryBooksAsync()
        {
            return await _libraryBookRepository.GetAllAsync();
        }

        public async Task<LibraryBook> GetLibraryBookByIdAsync(Guid id)
        {
            return await _libraryBookRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateLibraryBookAsync(LibraryBook libraryBook)
        {
            return await _libraryBookRepository.UpdateAsync(libraryBook);
        }
    }
}
