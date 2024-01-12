using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniStore.Business.CustomExceptions.User;
using MiniStore.Business.Services.Service;
using MiniStore.Business.ViewModels;
using MiniStore.Core.Entities;

namespace MiniStore.UI.areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
           
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            try
            {
                await _accountService.Login(loginViewModel);
            }
            catch (InvalidUsernameOrPassword ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "post");
        }

        public async Task<IActionResult> Logout()
        {
            

            return RedirectToAction("login", "account");
        }

        #region Creating Admin for the DashBoard
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    User admin = new User()
        //    {
        //        FullName = "Elvin Sarkarov",
        //        UserName = "Admin1",
        //    };

        //    var result = await _userManager.CreateAsync(admin, "#Admin1234");


        //    return Ok(result);
        //}
        #endregion

        #region Creating Roles for Admin
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("Member");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);

        //    return Ok("Rollar Yarandi");
        //}
        #endregion

        #region Adding the role to spesific user
        //public async Task<IActionResult> AddRoleAdmin()
        //{
        //    User admin = await _userManager.FindByNameAsync("Admin1");

        //    await _userManager.AddToRoleAsync(admin, "Admin");

        //    return Ok("rol elave olundu");
        //}
        #endregion
    }
}
