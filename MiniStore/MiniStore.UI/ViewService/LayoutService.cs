using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniStore.Core.Entities;
using MiniStore.Core.Repositories;

namespace MiniStore.UI.ViewService
{
    public class LayoutService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public LayoutService(ISettingRepository settingRepository, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _settingRepository = settingRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<List<Setting>> GetSettings()
        {
            var settings = await _settingRepository.Table.ToListAsync();

            return settings;
        }

        public async Task<User> GetUser()
        {
            User user = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            }

            return user;
        }
    }
}
