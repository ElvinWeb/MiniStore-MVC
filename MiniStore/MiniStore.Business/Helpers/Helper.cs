using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.Helpers
{
    public static class Helper
    {
        public static async Task<string> GetFileName(string webRootPath, string folder, IFormFile Image)
        {
            string fileName = Image.FileName.Length > 64 ? Image.FileName.Substring(Image.FileName.Length - 64, 64) : Image.FileName;
            fileName = Guid.NewGuid().ToString() + Image.FileName;
            string path = Path.Combine(webRootPath, folder, fileName);

            using (FileStream Stream = new FileStream(path, FileMode.Create))
            {
                await Image.CopyToAsync(Stream);
            }

            return fileName;
        }
    }
}
