using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Business.CustomExceptions.User
{
    public class InvalidUsernameOrPassword : Exception
    {
        public string PropertyName { get; set; }
        public InvalidUsernameOrPassword()
        {
        }

        public InvalidUsernameOrPassword(string? message) : base(message)
        {

        }

        public InvalidUsernameOrPassword(string propName, string? message) : base(message)
        {
            PropertyName = propName;
        }
    }
}
