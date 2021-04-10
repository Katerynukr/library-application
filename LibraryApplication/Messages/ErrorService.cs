using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services.Messages
{
    public class ErrorService
    {
        public string ReturnDelayedReturnErrorMessage()
        {
            var error = "The book was return with delay! :(";
            return error;
        }
    }
}
