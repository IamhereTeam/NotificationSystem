using System.Linq;
using NS.Core.Entities;
using NS.Core.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace NS.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(NSDbContext context)
        : base(context)
        { }

        public async Task<User> GetWithDepartmentByIdAsync(int id)
        {
            return await NSDbContext.Users
                .Include(m => m.Department)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<User> GetWithDepartmentByUsernameAsync(string usersName)
        {
            return await NSDbContext.Users
                .Include(m => m.Department)
                .SingleOrDefaultAsync(m => m.Username == usersName);
        }

        public async Task<IEnumerable<User>> GetNotificationEnabledUsers(int senderDepartment, IEnumerable<int> departments, IEnumerable<int> users)
        {
            var query = NSDbContext.Users
                .Where(u => users.Contains(u.Id) || departments.Contains(u.DepartmentId))
                .Include(u => u.UserSettings);

            var data = await query.ToListAsync();

            var notificationEnabledUsers = data.Distinct()
                .Where(x => x.UserSettings == null || !x.UserSettings.DisabledDepartments.Contains(senderDepartment))
                .ToList();

            return notificationEnabledUsers;
        }

        private NSDbContext NSDbContext
        {
            get { return Context as NSDbContext; }
        }
    }
}