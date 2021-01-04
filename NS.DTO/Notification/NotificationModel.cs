using System.Collections.Generic;

namespace NS.DTO.Notification
{
    public class CreateNotificationModel
    {
        public NotificationModel Notification { get; set; }

        public IEnumerable<int> Departments { get; set; }
        public IEnumerable<int> Users { get; set; }
    }

    public class NotificationModel
    {
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}