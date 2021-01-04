using NS.Core.Entities;
using NS.Core.Repositories;

namespace NS.Data.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(NSDbContext context)
        : base(context)
        { }

        private NSDbContext NSDbContext
        {
            get { return Context as NSDbContext; }
        }
    }
}