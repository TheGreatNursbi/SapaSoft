using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sapa.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate);
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> DeleteAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(object id);
        Task<int> SaveChanges();
    }
}
