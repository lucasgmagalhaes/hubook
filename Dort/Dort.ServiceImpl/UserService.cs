using Dort.Entity;
using Dort.Entity.HttpEntity;
using Dort.Repository.Db;
using Dort.Service;
using Dort.ServiceImpl.Exceptions;
using Dort.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Dort.ServiceImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;
        private readonly string _passwordKey;

        public UserService(IUserRepository userRepository, IConfiguration configs, IMailService mailService)
        {
            _userRepository = userRepository;
            _mailService = mailService;
            _passwordKey = configs.GetSection("passwordKey").Value;
        }

        public async Task<User> Create(string name, string email, string password)
        {
            try
            {
                //var registredUser = await _userRepository.FindOne(new { email, isActive = true });

                //User user = new User
                //{
                //    Password = Cryptography.Encrypt(password, _passwordKey),
                //    Email = email,
                //    Name = name,
                //    IsActive = true,
                //    Level = 1
                //};

                //var newUser = await _userRepository.Insert(user);
                await SendConfirmationEmail(name, email);
                return new User();
            }
            catch (EmailSendingFailureException e)
            {
                Debug.Print(e.Message);
                throw e;
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

        private async Task SendConfirmationEmail(string userName, string userEmail)
        {
            var emailContent = await BuildEmailContent();
            await _mailService.SendAsync(userEmail, emailContent, "Email confirmation");
        }

        private async Task<string> BuildEmailContent()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", "SubscriptionConfirmTemplate.html");
            var file = await File.ReadAllTextAsync(path);
            return file.Replace("{{url_click_button}}", "http://test.com");
        }
    }
}
