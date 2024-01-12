using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.CustomExceptions.Image
{
    public class ImageRequiredException : Exception 
    {
        public string PropertyName { get; set; }
        public ImageRequiredException()
        {
        }

        public ImageRequiredException(string? message) : base(message)
        {

        }

        public ImageRequiredException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
