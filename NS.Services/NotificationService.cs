using NS.Core;
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

        public async Task Create(int id, Notification notification, IEnumerable<int> Departments, IEnumerable<int> Users)
        {
            IEnumerable<int> allUsers = null; // find all users permited to get notifications

            List<Notification> notifications = new List<Notification>();

            foreach (var user in allUsers)
            {
                notifications.Add(new Notification
                {
                    To = user,
                    From = id,
                    Subject = notification.Subject,
                    Message = notification.Message
                });
            }

            await _unitOfWork.Notification.AddRangeAsync(notifications);

            await _unitOfWork.CommitAsync();
        }
    }
}