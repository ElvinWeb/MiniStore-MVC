using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.CustomExceptions.Common
{
    public class InvalidNullReferenceException : Exception
    {
        public string PropertyName { get; set; }
        public InvalidNullReferenceException()
        {
        }

        public InvalidNullReferenceException(string? message) : base(message)
        {

        }

        public InvalidNullReferenceException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
