using System;
using System.Collections.Generic;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Core.Utilities;

namespace App.Core
{
    public class UserService : IUserService
    {
        IUserDataServices _users { get; }

        public UserService(IUserDataServices users)
        {
            Require.ObjectNotNull(users, "User data services need to be defined");

            _users = users;
        }


        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            User user = _users.GetUserByName(username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public User Create(User user, string password)
        {
            Require.ObjectNotNull(user, "User needs to be defined.");
            Require.NotNullOrEmpty(password, "Password needs to be defined.");

            // check to see if user name exists
            if (_users.UserNameUsed(user.UserName))
            {
                throw new ApplicationException($"User name already used: {user.UserName} ");
            }
            
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Id = Guid.NewGuid().ToString();

            _users.Add(user);

            return user;
        }

        public void Delete(string id)
        {
            Require.NotNullOrEmpty(id, "User id must be defined.");
            var user = GetById(id);
            _users.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.List();
        }

        public User GetById(string id)
        {
            Require.NotNullOrEmpty(id, "User id must be defined.");
            return _users.GetById(id);
        }

        public void Update(User user, string password = null)
        {
            throw new System.NotImplementedException();
        }

        // https://github.com/cornflourblue/aspnet-core-registration-login-api/blob/master/Services/UserService.cs
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

        // https://github.com/cornflourblue/aspnet-core-registration-login-api/blob/master/Services/UserService.cs
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
