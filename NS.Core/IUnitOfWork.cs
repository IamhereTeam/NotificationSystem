using System;
using NS.Core.Repositories;
using System.Threading.Tasks;

namespace NS.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IDepartmentRepository Departments { get; }
        IUserSettingsRepository UserSettings { get; }
        INotificationRepository Notification { get; }
        Task<int> CommitAsync();
    }
}