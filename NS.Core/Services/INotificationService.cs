using NS.Core.Entities;
using System.Threading.Tasks;

namespace NS.Core.Services
{
    public interface INotificationService
    {
        Task Create(Notification notification, User sourse, Department destination);
    }
}