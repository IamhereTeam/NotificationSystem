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

        public async Task Create(int id, Notification notification, IEnumerable<int> Departments, IEnumerable<int> Users)
        {
            var user = await _unitOfWork.Users.GetWithDepartmentByIdAsync(id);
            var userSettings = await _unitOfWork.UserSettings.GetByIdAsync(id);

            var allUsers = Users?.ToList() ?? new List<int>();

            foreach (var department in Departments)
            {
                var users = _unitOfWork.Users.Find(x => x.DepartmentId == department).Select(x => x.Id);
                allUsers.AddRange(users);
            }

            List<Notification> notifications = new List<Notification>();

            //foreach (var to in allUsers)
            //{
            //    notifications.Add(new Notification
            //    {
            //        To = to,
            //        FromUserId = user.Id,
            //        FromUserName = user.Username,
            //        FromDepartmentId = user.DepartmentId,
            //        FromDepartmentName = user.Department.Name,
            //        Subject = notification.Subject,
            //        Message = notification.Message
            //    });
            //}

            await _unitOfWork.Notification.AddRangeAsync(notifications);

            await _unitOfWork.CommitAsync();
        }
    }
}