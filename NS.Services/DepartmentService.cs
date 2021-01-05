using NS.Core;
using NS.Core.Entities;
using NS.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NS.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return _unitOfWork.Departments.GetAllAsync();
        }

        public async Task Delete(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department != null)
            {
                _unitOfWork.Departments.Remove(department);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
