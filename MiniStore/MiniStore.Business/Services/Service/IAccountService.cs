using Microsoft.AspNetCore.Identity;
using MiniStore.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.Services.Service
{
    public interface IAccountService
    {
        Task Login(LoginViewModel loginViewModel);
        Task Logout();
    }
}
