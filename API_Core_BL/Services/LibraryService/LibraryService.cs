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
            Library addLibrary = new Library();
            addLibrary.DelayPrice = libraryDto.DelayPrice;
            addLibrary.FullAddress = libraryDto.FullAddress;
            addLibrary.Latitude = libraryDto.Latitude;
            addLibrary.Longitude = libraryDto.Longitude;

            var city = await _cityRepository.GetByIdAsync(libraryDto.CityId);
            addLibrary.City = city;
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
