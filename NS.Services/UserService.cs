using NS.Core;
using NS.Core.Entities;
using NS.Core.Services;
using System.Threading.Tasks;

namespace NS.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users
                .GetWithDepartmentByIdAsync(id);
        }

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.Name = user.Name;
            userToBeUpdated.DepartmentId = user.DepartmentId;

            await _unitOfWork.CommitAsync();
        }
    }
}
