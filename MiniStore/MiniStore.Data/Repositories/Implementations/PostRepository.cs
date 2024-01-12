using MiniStore.Core.Entities;
using MiniStore.Core.Repositories;
using MiniStore.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Data.Repositories.Implementations
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
