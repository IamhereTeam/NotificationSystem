using NS.Core.Entities;
using System.Threading.Tasks;

namespace NS.Core.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User userToBeUpdated, User user);
        Task DeleteUser(User user);
    }
}