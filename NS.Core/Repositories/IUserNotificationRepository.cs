using NS.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NS.Core.Repositories
{
    public interface IUserNotificationRepository : IRepository<UserNotification>
    {
        Task<IEnumerable<UserNotification>> GetByUserId(int id);
    }
}
