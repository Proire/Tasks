using System.Text.RegularExpressions;
using UserRegistration;

namespace UserRegistrationUC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to User Registration App!\n");

            // FirstName 
            Console.WriteLine("------------------ Welcome User ------------------\n");
            Console.Write("Enter the FirstName : ");
            String firstName = UserInput();
            User user = new();
            if (Regex.IsMatch(firstName, @"^[A-Z]\w{2,}"))
            {
                user.FirstName = firstName;
            }
            else
            {
                throw new InvalidInputException("Invalid Input");
            }
            Console.WriteLine($"FirstName of the User : {user.FirstName}");

            // LastName
            Console.Write("Enter the LastName : ");
            String lastName = UserInput();
            if (Regex.IsMatch(lastName, @"^[A-Z]\w{2,}"))
            {
                user.LastName = lastName;
            }
            else
            {
                throw new InvalidInputException("Invalid Input");
            }
            Console.WriteLine($"LastName of the User : {user.LastName}");

            // Email
            Console.Write("Enter the Email : ");
            String email = UserInput();
            if (Regex.IsMatch(email, @"^[\w.]+@\w+\.\w{2,}[\w.]*$"))
            {
                user.Email = email;
            }
            else
            {
                throw new InvalidInputException("Invalid Input");
            }
            Console.WriteLine($"Email of the User : {user.Email}");

            // Phone number 
            Console.Write("Enter the Phone number : ");
            String phonenumber = UserInput();
            if (Regex.IsMatch(phonenumber, @"(?:[+]\d{2})?\s?\d{10}"))
            {
                user.Phonenumber = phonenumber;
            }
            else
            {
                throw new InvalidInputException("Invalid Input");
            }
            Console.WriteLine($"Phonenumber of the User : {user.Phonenumber}");

            // Password
            Console.Write("Enter the Password : ");
            String password = UserInput();
            if (Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$"))
            {
                user.Password = password;
            }
            else
            {
                throw new InvalidInputException("Invalid Input");
            }
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
