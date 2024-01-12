using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.CustomExceptions.Image
{
    public class InvalidContentTypeOrSizeException : Exception
    {
        public string PropertyName { get; set; }
        public InvalidContentTypeOrSizeException()
        {
        }

        public InvalidContentTypeOrSizeException(string? message) : base(message)
        {

        }

        public InvalidContentTypeOrSizeException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
