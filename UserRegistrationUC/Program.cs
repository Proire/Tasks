using System.Text.RegularExpressions;
using UserRegistration;

namespace UserRegistrationUC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to User Registration App!\n");

            Console.WriteLine("------------------ Welcome User ------------------\n");
            Console.Write("Enter the FirstName : ");
            String firstName = UserInput("firstname");
            User user = new User();
            user.FirstName = firstName;
            Console.WriteLine($"FirstName of the User : {user.FirstName}");
        }

        static String UserInput(string msg)
        {
            // Accepting user input it can be null as well 
            String? input = Console.ReadLine();

            // Validating user input for first capital letter and minimum 3 letters
            if (Regex.IsMatch(input, @"^[A-Z]\w{2,}"))
            {
                return input;
            }

            else
            {
                throw new InvalidInputException("Invalid input for "+msg);
            }
        }
    }
}
