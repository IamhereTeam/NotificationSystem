using NS.Core.Entities;
using System.Threading.Tasks;

namespace NS.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetWithDepartmentByIdAsync(int id);
    }
}
