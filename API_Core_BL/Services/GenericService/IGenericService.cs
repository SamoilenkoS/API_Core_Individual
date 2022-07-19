using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Core_BL.Services.GenericService
{
    public interface IGenericService<T>
        where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<Guid> AddAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(T item);
    }
}
