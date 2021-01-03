using NS.Core.Entities;
using NS.Core.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        private NSDbContext NSDbContext
        {
            get { return Context as NSDbContext; }
        }
    }
}