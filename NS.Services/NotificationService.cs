using NS.Core.Entities;
using NS.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NS.Services
{
    public class NotificationService : INotificationService
    {
        public Task Create(Notification notification, User sourse, Department destination)
        {
            throw new NotImplementedException();
        }
    }
}