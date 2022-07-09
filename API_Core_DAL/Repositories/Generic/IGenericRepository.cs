using API_Core_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API_Core_DAL
{
    public interface IGenericRepository<T>
        where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate);
        Task<Guid> AddAsync(T baseEntity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(T baseEntity);
    }
}
