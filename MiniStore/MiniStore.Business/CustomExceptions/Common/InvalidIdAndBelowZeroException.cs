using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.CustomExceptions.Common
{
    public class InvalidIdAndBelowZeroException : Exception
    {
        public string PropertyName { get; set; }
        public InvalidIdAndBelowZeroException()
        {
        }

        public InvalidIdAndBelowZeroException(string? message) : base(message)
        {

        }

        public InvalidIdAndBelowZeroException(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }

    }
}
