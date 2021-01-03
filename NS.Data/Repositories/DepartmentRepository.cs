using NS.Core.Entities;
using NS.Core.Repositories;

namespace NS.Data.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(NSDbContext context)
        : base(context)
        { }

        private NSDbContext NSDbContext
        {
            get { return Context as NSDbContext; }
        }
    }
}