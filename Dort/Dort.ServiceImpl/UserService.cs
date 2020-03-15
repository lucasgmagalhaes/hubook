using Dort.Entity;
using Dort.Repository.Db;
using Dort.Service;
using Dort.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Dort.ServiceImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _passwordKey;

        public UserService(IUserRepository userRepository, IConfiguration configs)
        {
            _userRepository = userRepository;
            _passwordKey = configs.GetSection("passwordKey").Value;
        }

        public async Task<User> Create(User user)
        {
            user.Password = Cryptography.Encrypt(user.Password, _passwordKey);
            var registredUser = await _userRepository.FindOne(new { user.Email, user.IsActive });

            if (registredUser != null)
                throw new Exception("This email is already in use, please inform another one");

            return await _userRepository.Insert(user);
        }

        public async Task<User> FindByEmailAndPassword(string email, string password)
        {
            string cryptPassword = Cryptography.Encrypt(password, _passwordKey);
            var user = await _userRepository.FindOne(new { email, password = cryptPassword });
            
            if (user == null)
                throw new Exception("Inválid email/password");

            return user;
        }
    }
}
