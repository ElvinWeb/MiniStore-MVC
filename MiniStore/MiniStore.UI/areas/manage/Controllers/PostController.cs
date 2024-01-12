using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniStore.Business.CustomExceptions.Common;
using MiniStore.Business.CustomExceptions.Image;
using MiniStore.Business.Services.Service;
using MiniStore.Core.Entities;
using MiniStore.UI.Pagination;

namespace MiniStore.UI.areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var posts = await _postService.GetAllAsync();

            PaginatedList<Post> paginatedPosts = PaginatedList<Post>.CreatePagination(posts, page, 3);

            return View(paginatedPosts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            //if (!ModelState.IsValid) return View();

            try
            {
                await _postService.CreateAsync(post);
            }
            catch (InvalidContentTypeOrSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (ImageRequiredException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "post");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == null && id <= 0) return NotFound();

            Post post = await _postService.GetByIdAsync(id);

            if (post == null) return NotFound();

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Post post)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _postService.UpdateAsync(post);
            }
            catch (InvalidContentTypeOrSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "post");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _postService.SoftDelete(id);
            }
            catch (InvalidIdAndBelowZeroException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return Ok();
        }
    }
}
