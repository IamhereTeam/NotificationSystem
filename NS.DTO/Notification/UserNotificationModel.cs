using NS.DTO.Acount;
using System;

namespace NS.DTO.Notification
{
    public class UserNotificationModel
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }

        public DateTime Date { get; set; }
        public bool WasRead { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }

        public UserModel Sender { get; set; }
    }
}