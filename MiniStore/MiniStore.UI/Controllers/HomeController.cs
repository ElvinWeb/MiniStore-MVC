using Microsoft.AspNetCore.Mvc;
using MiniStore.Business.Services.Service;
using MiniStore.Core.Entities;
using System.Diagnostics;

namespace MiniStore.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public async Task<IActionResult> Index()
        {
            List<Post> posts = await _postService.GetAllAsync();

            return View(posts);
        }


    }
}