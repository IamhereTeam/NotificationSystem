using System.Linq;
using NS.Core.Entities;
using NS.Core.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NS.Data.Repositories
{
    public class UserNotificationRepository : Repository<UserNotification>, IUserNotificationRepository
    {
        public UserNotificationRepository(NSDbContext context)
        : base(context)
        { }

        public async Task<IEnumerable<UserNotification>> GetByUserId(int id)
        {
            var query = NSDbContext.UserNotifications
                .Include(x => x.Notification)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.Department)
                .Where(x => x.UserId == id);

            var data = await query.ToListAsync();
            return data;
        }

        private NSDbContext NSDbContext
        {
            get { return Context as NSDbContext; }
        }
    }
}