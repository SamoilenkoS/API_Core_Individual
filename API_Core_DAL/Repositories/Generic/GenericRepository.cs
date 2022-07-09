using API_Core_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API_Core_DAL
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity, new()
    {
        private readonly DbEfContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbEfContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<Guid> AddAsync(T baseEntity)
        {
            _dbSet.Add(baseEntity);

            await _dbContext.SaveChangesAsync();

            return baseEntity.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var baseEntity = new T { Id = id };
            _dbSet.Attach(baseEntity);

            _dbContext.Entry(baseEntity).State = EntityState.Deleted;

            return await _dbContext.SaveChangesAsync() != 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }


        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(T baseEntity)
        {
            _dbSet.Attach(baseEntity);

            _dbContext.Entry(baseEntity).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync() != 0;
        }
    }
}
