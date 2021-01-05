using NS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NS.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetWithDepartmentByIdAsync(int id);
        Task<User> GetWithDepartmentByUsernameAsync(string username);
        Task<IEnumerable<User>> GetNotificationEnabledUsers(int senderDepartment, IEnumerable<int> departments, IEnumerable<int> users);
    }
}
