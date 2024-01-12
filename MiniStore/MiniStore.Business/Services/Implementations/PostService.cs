using Microsoft.AspNetCore.Hosting;
using MiniStore.Business.CustomExceptions.Common;
using MiniStore.Business.CustomExceptions.Image;
using MiniStore.Business.Helpers;
using MiniStore.Business.Services.Service;
using MiniStore.Core.Entities;
using MiniStore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IWebHostEnvironment _env;

        public PostService(IPostRepository postRepository, IWebHostEnvironment env)
        {
            _postRepository = postRepository;
            _env = env;
        }
        public async Task CreateAsync(Post post)
        {
            if (post.Image != null)
            {
                if (post.Image.ContentType != "image/png" && post.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidContentTypeOrSizeException("Image", "please select correct file type");
                }

                if (post.Image.Length > 1048576)
                {
                    throw new InvalidContentTypeOrSizeException("Image", "file size should be more lower than 1mb");
                }
            }
            else
            {
                throw new ImageRequiredException("Image", "image is required");
            }

            string folder = "uploads/posts-Images";
            string newFilePath = await Helper.GetFileName(_env.WebRootPath, folder, post.Image);
            post.ImgUrl = newFilePath;

            await _postRepository.CreateAsync(post);
            await _postRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null && id <= 0) throw new InvalidIdAndBelowZeroException("Id coudn't be null or below than zero");

            var post = await _postRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);

            if (post == null) throw new InvalidNullReferenceException("object is coudn't be null");

            string fullPath = Path.Combine(_env.WebRootPath, "uploads/bg-slide", post.ImgUrl);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            _postRepository.Delete(post);
            await _postRepository.CommitAsync();
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync(x => !x.IsDeleted);
        }

        public async Task<Post> GetByIdAsync(int id)
        {

            return await _postRepository.GetByIdAsync(x => x.Id == id);
        }

        public async Task SoftDelete(int id)
        {

            if (id == null && id <= 0) throw new InvalidIdAndBelowZeroException("Id coudn't be null or below than zero");

            var post = await _postRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);

            if (post == null) throw new InvalidNullReferenceException("object is coudn't be null");

            post.IsDeleted = !post.IsDeleted;

            await _postRepository.CommitAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            Post wantedPost = await _postRepository.GetByIdAsync(x => x.Id == post.Id && !x.IsDeleted);

            if (wantedPost == null) throw new InvalidNullReferenceException("object is could't be null");

            if (post.Image != null)
            {
                if (post.Image.ContentType != "image/png" && post.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidContentTypeOrSizeException("Image", "please select correct file type");
                }

                if (post.Image.Length > 1048576)
                {
                    throw new InvalidContentTypeOrSizeException("Image", "file size should be more lower than 1mb");
                }

                string folder = "uploads/posts-Images";
                string oldFilePath = Path.Combine(_env.WebRootPath, folder, wantedPost.ImgUrl);

                string newFilePath = await Helper.GetFileName(_env.WebRootPath, folder, post.Image);

                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);   
                }
                
                wantedPost.ImgUrl = newFilePath;
            }

            wantedPost.Title = post.Title;
            wantedPost.PostDate = post.PostDate;
            wantedPost.Category = post.Category;    

            await _postRepository.CommitAsync();    

        }
    }
}
