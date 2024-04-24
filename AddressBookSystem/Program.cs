using AddressBookSystem;
using System.Net;
using System.Numerics;
using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        AddressBook addressBook = new();
        int choice;
        do
        {
            Console.WriteLine("\n\nUser Enter the Choice : ");
            Console.WriteLine("\n1.Add Contact\n2.Update Contact\n3.Delete Contact\n4.Display Contacts\n5.Add Multiple Contacts\n0.Exit Application\n");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    // Adding new Contact 
                    Contact newContact = CreateContact("new");
                    String Addresponse = addressBook.AddContact(newContact);
                    Console.WriteLine(Addresponse);
                    break;
                case 2:
                    // Update a Contact
                    Contact updatedContact = CreateContact("Updated");
                    Contact updateresponse = addressBook.UpdateContactByName(updatedContact);
                    Console.WriteLine("Updated Contact : " + updateresponse);
                    break;
                case 3:
                    // Delete Contact by Name 
                    Console.Write("Enter the Name of Contact to be deleted : ");
                    string name = Console.ReadLine();
                    Contact deleteresponse = addressBook.DeleteContactByName(name);
                    Console.WriteLine("Deleted Contact details : " + deleteresponse);
                    break;
                case 4:
                    // Display all Contacts
                    Console.WriteLine("Address Book has : ");
                    foreach (var contact in addressBook.GetContacts())
                        Console.WriteLine(contact);
                    break;
                case 5:
                    // Add Multiple contacts
                    Console.Write("Number of Contacts you want to add: ");
                    int contacts = int.Parse(Console.ReadLine());
                    do
                    {
                        Contact contact = CreateContact("new");
                        String response = addressBook.AddContact(contact);
                        Console.WriteLine(response);
                        contacts--;
                    } while (contacts > 0);
                    break;
                case 0:
                    Console.WriteLine("Exiting Application, Thank you for Visiting");
                    break;
                default:
                    Console.WriteLine("Wrong Choice");
                    break;
            }

        } while (choice != 0);
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
            Console.Write("\nEnter the name of contact to be updated : ");
        String firstname = UserInput();

        Console.Write("Enter the Last Name : ");
        String lastname = UserInput();

        Console.Write("Enter the Address : ");
        String address = UserInput();

        Console.Write("Enter the State : ");
        String state = UserInput();

        Console.Write("Enter the Zip : ");
        long zip = long.Parse(UserInput());

        Console.Write("Enter the Email : ");
        String email = UserInput();

        Console.Write("Enter the City : ");
        String city = UserInput();

        Console.Write("Enter the Phonenumber : ");
        long phonenumber = long.Parse(UserInput());

        return new Contact(firstname, lastname, address, city, zip, state, phonenumber, email);
    }
}