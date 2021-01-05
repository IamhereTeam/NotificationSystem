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

        public async Task Send(Notification notification, IEnumerable<int> Departments, IEnumerable<int> Users)
        {
            var user = await _unitOfWork.Users.GetWithDepartmentByIdAsync(notification.UserId);
            var senderDepartment = user.Department;


            var sx =_unitOfWork.Users.Find(u => u.DepartmentId == 15 && !u.UserSettings.DisabledDepartments.Any(x => x == senderDepartment.Id));


           // var userSettings = await _unitOfWork.UserSettings.GetByIdAsync(id);

            var allUsers = Users?.ToList() ?? new List<int>();

            foreach (var department in Departments)
            {
                var users = _unitOfWork.Users.Find(x => x.DepartmentId == department).Select(x => x.Id);
                allUsers.AddRange(users);
            }

            List<Notification> notifications = new List<Notification>();



            await _unitOfWork.Notification.AddRangeAsync(notifications);

            await _unitOfWork.CommitAsync();
        }
    }
}