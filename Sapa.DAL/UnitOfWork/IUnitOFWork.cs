using Sapa.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sapa.DAL.UnitOfWork
{
    public interface IUnitOFWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        int Commit();
        Task<int> CommitAsync();
    }
}
