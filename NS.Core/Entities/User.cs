using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NS.Core.Entities
{
    public class User
    {
        public User()
        {
            Notifications = new Collection<Notification>();
            UserNotifications = new Collection<UserNotification>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public UserSettings UserSettings { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }
        public IEnumerable<UserNotification> UserNotifications { get; set; }
    }
}