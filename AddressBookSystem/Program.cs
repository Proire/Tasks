using AddressBookSystem;

internal class Program
{
    private static void Main(string[] args)
    {
        AddressBook addressBook = new AddressBook();

        Console.WriteLine("\nPlease Enter the below details for Contact Entry");

        Console.Write("\nEnter the First Name : ");
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

        Console.WriteLine();
        String response = addressBook.AddContact(new Contact(firstname, lastname, address, city, zip, state, phonenumber, email));
        Console.WriteLine(response);

        Console.WriteLine("Address Book has : ");
        foreach(var contact in addressBook.GetContacts())
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
}