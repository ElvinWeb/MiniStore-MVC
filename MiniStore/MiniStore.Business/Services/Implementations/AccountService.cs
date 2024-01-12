using Microsoft.AspNetCore.Identity;
using MiniStore.Business.CustomExceptions.User;
using MiniStore.Business.Services.Service;
using MiniStore.Business.ViewModels;
using MiniStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.Services.Implementations
{

    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task Login(LoginViewModel loginViewModel)
        {
            User admin = null;

            admin = await _userManager.FindByNameAsync(loginViewModel.Username);

            if (admin == null)
            {
                throw new InvalidUsernameOrPassword("", "username or password is wrong!");
            }

            var result = await _signInManager.PasswordSignInAsync(admin, loginViewModel.Password, false, false);

            if (!result.Succeeded)
            {
                throw new InvalidUsernameOrPassword("", "username or password is wrong!");
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
