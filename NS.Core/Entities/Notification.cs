using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NS.Core.Entities
{
    public class Notification
    {
        public Notification()
        {
            UserNotifications = new Collection<UserNotification>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }

        public User User { get; set; }
        public IEnumerable<UserNotification> UserNotifications { get; set; }
    }
}