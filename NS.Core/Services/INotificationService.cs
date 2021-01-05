using NS.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NS.Core.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<UserNotification>> GetByUserId(int id);
        Task<Notification> Create(Notification notification);
        Task Send(Notification notification, IEnumerable<int> Departments, IEnumerable<int> Users);
    }
}