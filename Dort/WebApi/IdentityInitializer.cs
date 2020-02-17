using Context;
using Microsoft.AspNetCore.Identity;
using System;

namespace WebApi
{
    public class IdentityInitializer
    {
        private readonly UserManager<UserSession> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public IdentityInitializer(
            UserManager<UserSession> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (!_roleManager.RoleExistsAsync(Roles.READER).Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new IdentityRole(Roles.READER)).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role {Roles.READER}.");
                }
            }

            CreateUser(
                new UserSession()
                {
                    UserName = "admin_apialturas",
                    Email = "admin-apialturas@teste.com.br",
                    EmailConfirmed = true
                }, "test");

            CreateUser(
                new UserSession()
                {
                    UserName = "usrinvalido_apialturas",
                    Email = "usrinvalido-apialturas@teste.com.br",
                    EmailConfirmed = true
                }, "test");
        }

        private void CreateUser(
            UserSession user,
            string password,
            string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}
