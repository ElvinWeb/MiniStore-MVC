using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string PostDate { get; set; }
        public string Category { get; set; }
        public string ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
