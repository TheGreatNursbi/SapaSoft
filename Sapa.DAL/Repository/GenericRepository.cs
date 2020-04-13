using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sapa.DAL.Repository
{
    class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _entities;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(MyDbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            EntityEntry<T> entry = await _dbset.AddAsync(entity);
            return entry.Entity;
        }

        public async Task<IEnumerable<T>> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> listToDelete = await _dbset.Where(predicate).ToListAsync();
            _dbset.RemoveRange(listToDelete);
            return listToDelete;
        }

        public async Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _dbset.Where(predicate).AsNoTracking().ToListAsync();
            return result;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            var query = _dbset.Where(predicate).AsNoTracking().FirstOrDefault();
            return query;
        }

        public async Task<T> GetAsync(object id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Update (T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public async Task<int> SaveChanges()
        {
            int state = await _entities.SaveChangesAsync();
            return state;
        }
    }
}
