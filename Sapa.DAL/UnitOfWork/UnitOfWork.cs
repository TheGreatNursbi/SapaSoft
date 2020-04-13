using Microsoft.EntityFrameworkCore;
using Sapa.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sapa.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly DbContext _context;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        /// <summary>
	    /// Async: Commit changes
	    /// </summary>
	    /// <returns></returns>
	    public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool CommitAndResult()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAndResultAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                        _context.Dispose();
                    _repositories?.Clear();
                }
            }
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if(_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (GenericRepository<T>)_repositories[type];

        }
    }
}
