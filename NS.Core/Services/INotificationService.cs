using NS.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NS.Core.Services
{
    public interface INotificationService
    {
        Task Create(int id, Notification notification, IEnumerable<int> Departments, IEnumerable<int> Users);
    }
}