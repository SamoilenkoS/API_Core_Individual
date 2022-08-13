using API_Core_BL.DTOs;
using API_Core_DAL;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {
        private readonly IGenericRepository<Library> _libraryRepository;
        private readonly IGenericRepository<City> _cityRepository;

        public LibraryService(IGenericRepository<Library> libraryRepository, IGenericRepository<City> cityRepository)
        {
            _libraryRepository = libraryRepository;
            _cityRepository = cityRepository;
        }

        public async Task<Guid> AddLibraryAsync(LibraryDto libraryDto)
        {
            var addLibrary = new Library
            {
                DelayPrice = libraryDto.DelayPrice,
                FullAddress = libraryDto.FullAddress,
                Latitude = libraryDto.Latitude,
                Longitude = libraryDto.Longitude,
                CityId = libraryDto.CityId
            };

            return await _libraryRepository.AddAsync(addLibrary);
        }

        public async Task<bool> DeleteLibraryAsync(Guid id)
        {
            return await _libraryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Library>> GetAllLibrariesAsync()
        {
            return await _libraryRepository.GetAllAsync();
        }

        public async Task<Library> GetLibraryByIdAsync(Guid id)
        {
            return await _libraryRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateLibraryAsync(Library library)
        {
            return await _libraryRepository.UpdateAsync(library);
        }
    }
}
