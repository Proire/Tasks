using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration
{
    internal class User
    {
        public string FirstName { get; set; } = string.Empty;
    }

    // Custom Exception class 
    public class InvalidInputException(String issue) : ApplicationException
    {
        public string Issue { get; set; } = issue;
    }
}
