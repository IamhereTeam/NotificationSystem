using NS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NS.Core.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task Delete(int id);
    }
}