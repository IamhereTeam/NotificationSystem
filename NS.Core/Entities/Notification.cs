using System;

namespace NS.Core.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime Date { get; set; }
        public bool WasRead { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }

        public User User { get; set; }
    }

    public class NotificationUsers
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int UserId { get; set; }

        public Notification Notification { get; set; }
        public User User { get; set; }
    }

    public class NotificationDepartments
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int DepartmentId { get; set; }

        public Notification Notification { get; set; }
        public Department Department { get; set; }
    }
}