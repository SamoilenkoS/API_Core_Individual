using API_Core_DAL;
using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.GenericService
{
    public class GenericService<T> : IGenericService<T>
               where T : BaseEntity, new()
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericRespository)
        {
            _genericRepository = genericRespository;
        }

        public async Task<Guid> AddAsync(T item)
        {
            return await _genericRepository.AddAsync(item);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _genericRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(T item)
        {
            return await _genericRepository.UpdateAsync(item);
        }
    }
}
