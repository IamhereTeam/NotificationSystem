using System;

namespace NS.Core.Entities
{
    public class UserNotification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NotificationId { get; set; }

        public DateTime Date { get; set; }
        public bool WasRead { get; set; }

        public User User { get; set; }
        public Notification Notification { get; set; }
    }
}