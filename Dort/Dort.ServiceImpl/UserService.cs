using Dort.Entity;
using Dort.Repository.Db;
using Dort.Service;
using Dort.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
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

        public async Task<User> Create(string name, string email, string password)
        {
            try
            {
                var registredUser = await _userRepository.FindOne(new { email, isActive = true });

                User user = new User
                {
                    Password = Cryptography.Encrypt(password, _passwordKey),
                    Name = name,
                    IsActive = true,
                    Level = 1
                };

                return await _userRepository.Insert(user);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                throw new Exception("This email is already in use, please inform another one");
            }
        }

        public async Task<User> FindByEmailAndPassword(string email, string password)
        {
            try
            {
                string cryptPassword = Cryptography.Encrypt(password, _passwordKey);
                return await _userRepository.FindOne(new { email, password = cryptPassword });
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                throw new Exception("Inválid email/password");
            }
        }
    }
}
