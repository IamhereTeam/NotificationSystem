using NS.Core;
using System.Linq;
using NS.Core.Entities;
using NS.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NS.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotificationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Notification> Create(Notification notification)
        {
            await _unitOfWork.Notification.AddAsync(notification);
            await _unitOfWork.CommitAsync();

            return notification;
        }

        public async Task Send(Notification notification, IEnumerable<int> departments, IEnumerable<int> users)
        {
            var user = await _unitOfWork.Users.GetWithDepartmentByIdAsync(notification.UserId);
            var senderDepartment = user.Department;

            // all users who are allowed to receive notifications
            var notificationEnabledUsers = await _unitOfWork.Users.GetNotificationEnabledUsers(senderDepartment.Id, departments, users);

            var userNotifications = new List<UserNotification>();

            foreach (var u in notificationEnabledUsers)
            {
                var userNotification = new UserNotification
                {
                    NotificationId = notification.Id,
                    UserId = u.Id
                };

                userNotifications.Add(userNotification);
            }

            await _unitOfWork.UserNotification.AddRangeAsync(userNotifications);

            await _unitOfWork.CommitAsync();
        }
    }
}