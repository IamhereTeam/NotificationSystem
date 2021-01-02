using NS.Core.Models;
using NS.Core.Repositories;

namespace NS.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(NSDbContext context)
        : base(context)
        { }

        private NSDbContext NSDbContext
        {
            get { return Context as NSDbContext; }
        }
    }
}