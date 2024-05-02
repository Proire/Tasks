using System.Text.RegularExpressions;
using UserRegistration;

namespace UserRegistrationUC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to User Registration App!\n");

            User user = new User();
            // Lambda function for input validation and code reusability
            Func<string, string, string> validateInput = (input, pattern) =>
            {
                if (Regex.IsMatch(input, pattern))
                {
                    return input;
                }
                else
                {
                    throw new InvalidInputException("Invalid Input");
                }
            };

            // FirstName
            Console.WriteLine("------------------ Welcome User ------------------\n");
            Console.Write("Enter the FirstName : ");
            user.FirstName = validateInput(UserInput(), @"^[A-Z]\w{2,}");

            Console.WriteLine($"FirstName of the User : {user.FirstName}");

            // LastName
            Console.Write("Enter the LastName : ");
            user.LastName = validateInput(UserInput(), @"^[A-Z]\w{2,}");

            Console.WriteLine($"LastName of the User : {user.LastName}");

            // Email
            Console.Write("Enter the Email : ");
            user.Email = validateInput(UserInput(), @"^[\w.]+@\w+\.\w{2,}[\w.]*$");

            Console.WriteLine($"Email of the User : {user.Email}");

            // PhoneNumber
            Console.Write("Enter the Phone number : ");
            user.Phonenumber = validateInput(UserInput(), @"(?:[+]\d{2})?\s?\d{10}");

            Console.WriteLine($"PhoneNumber of the User : {user.Phonenumber}");

            // Password
            Console.Write("Enter the Password : ");
            user.Password = validateInput(UserInput(), @"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$");

            Console.WriteLine($"Password of the User : {user.Password}");

            // clear all email samples provided separately
            string textWithEmailSamples = @" Lorem ipsum dolor sit amet, consectetur adipiscing elit. Email samples: sample1@example.com, sample2@example.com, sample3@example.com Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            // Define the regex pattern to match email addresses
            string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";
            // Remove email samples using regex
            string textWithoutEmails = Regex.Replace(textWithEmailSamples, pattern, "");
            // Output the text without email samples
            Console.WriteLine("Text without email samples:");
            Console.WriteLine(textWithoutEmails);

        }

        static String UserInput()
        {
            // Accepting user input it can be null as well 
            String? input = Console.ReadLine();

            // Validating for Null or empty input string 
            if (string.IsNullOrEmpty(input))
            {
                throw new NullInputException("Null Value not allowed");
            }
            else
            {
                return input;
            }
        }
    }
}
