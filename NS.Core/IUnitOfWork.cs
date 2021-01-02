using System;
using NS.Core.Repositories;
using System.Threading.Tasks;

namespace NS.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IDepartmentRepository Departments { get; }
        Task<int> CommitAsync();
    }
}