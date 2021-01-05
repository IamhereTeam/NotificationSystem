using NS.Core.Entities;
using NS.Core.Repositories;

namespace NS.Data.Repositories
{
    public class UserNotificationRepository : Repository<UserNotification>, IUserNotificationRepository
    {
        public UserNotificationRepository(NSDbContext context)
        : base(context)
        { }

        private NSDbContext NSDbContext
        {
            get { return Context as NSDbContext; }
        }
    }
}