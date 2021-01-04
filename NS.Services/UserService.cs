using System;
using NS.Core;
using System.Linq;
using NS.Core.Entities;
using NS.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NS.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await _unitOfWork.Users.GetWithDepartmentByUsernameAsync(username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _unitOfWork.Users.GetAllAsync();
        }

        public Task<User> GetById(int id)
        {
            return _unitOfWork.Users.GetWithDepartmentByIdAsync(id);
        }

        public async Task<User> Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new ValidationException("Password is required");

            if (await _unitOfWork.Users.AnyAsync(x => x.Username == user.Username))
                throw new ValidationException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return user;
        }

        public async Task<User> Update(User userParam, string password = null)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userParam.Id);

            if (user == null)
                throw new ValidationException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (await _unitOfWork.Users.AnyAsync(x => x.Username == userParam.Username))
                    throw new ValidationException("Username " + userParam.Username + " is already taken");

                user.Username = userParam.Username;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            if (userParam.DepartmentId != 0)
                user.DepartmentId = userParam.DepartmentId;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            //_unitOfWork.Users.Update(user);
            await _unitOfWork.CommitAsync();

            return user;
        }

        public async Task Delete(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<UserSettings> ApplySettings(UserSettings userSettings)
        {
            var entity = await _unitOfWork.UserSettings.GetByIdAsync(userSettings.Id);

            if (entity == null)
            {
                await _unitOfWork.UserSettings.AddAsync(userSettings);
                await _unitOfWork.CommitAsync();
                return userSettings;
            }

            if (userSettings.DisabledDepartments != null && !userSettings.DisabledDepartments.SequenceEqual(entity.DisabledDepartments))
            {
                entity.DisabledDepartments = userSettings.DisabledDepartments;
            }

            await _unitOfWork.CommitAsync();
            return entity;
        }

        // private helper methods
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
