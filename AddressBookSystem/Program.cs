using AddressBookSystem;
using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        AddressBook addressBook = new();

        // Adding new Contact 
        Contact newContact = CreateContact("new");
        String Addresponse = addressBook.AddContact(newContact);
        Console.WriteLine(Addresponse);

        // Displaying all Contacts
        Console.WriteLine("Address Book has : ");
        foreach(var contact in addressBook.GetContacts())
            Console.WriteLine(contact);

        Console.WriteLine();

        // update current Contact
        Contact updatedContact = CreateContact("Updated");
        Contact updateresponse = addressBook.UpdateContactByName(updatedContact);  
        Console.WriteLine("Updated Contact : "+updateresponse);

        // Displaying all Contacts
        Console.WriteLine("Address Book has : ");
        foreach (var contact in addressBook.GetContacts())
            Console.WriteLine(contact);
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

    static Contact CreateContact(string action)
    {
        Console.WriteLine($"\nPlease Enter the below details for {action} Contact");

        if (action.Equals("new"))
            Console.Write("\nEnter the First Name : ");
        else
            Console.Write("Enter the name of contact to be updated : ");
        String firstname = UserInput();

        Console.Write("\nEnter the Last Name : ");
        String lastname = UserInput();

        Console.Write("\nEnter the Address : ");
        String address = UserInput();

        Console.Write("\nEnter the State : ");
        String state = UserInput();

        Console.Write("\nEnter the Zip : ");
        long zip = long.Parse(UserInput());

        Console.Write("\nEnter the Email : ");
        String email = UserInput();

        Console.Write("\nEnter the City : ");
        String city = UserInput();

        Console.Write("\nEnter the Phonenumber : ");
        long phonenumber = long.Parse(UserInput());

        return new Contact(firstname, lastname, address, city, zip, state, phonenumber, email);
    }
}