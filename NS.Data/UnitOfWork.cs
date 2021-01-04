using NS.Core;
using NS.Core.Repositories;
using NS.Data.Repositories;
using System.Threading.Tasks;

namespace NS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NSDbContext _context;
        private UserRepository _userRepository;
        private DepartmentRepository _departmentRepository;
        private UserSettingsRepository _userSettingsRepository;

        public UnitOfWork(NSDbContext context)
        {
            this._context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);
        public IDepartmentRepository Departments => _departmentRepository ??= new DepartmentRepository(_context);
        public IUserSettingsRepository UserSettings => _userSettingsRepository ??= new UserSettingsRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}