using MiniStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.Services.Service
{
    public interface IPostService
    {
        Task CreateAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(int id);
        Task<Post> GetByIdAsync(int id);
        Task<List<Post>> GetAllAsync();
        Task SoftDelete(int id);
    }
}
