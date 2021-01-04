using NS.Core.Entities;
using NS.Core.Repositories;

namespace NS.Data.Repositories
{
    public class UserSettingsRepository : Repository<UserSettings>, IUserSettingsRepository
    {
        public UserSettingsRepository(NSDbContext context)
        : base(context)
        { }
    }
}