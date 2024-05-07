using AddressBookSystem;
using System.Net;
using System.Numerics;
using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Address Book Application\n");

        // Dictinary to maintain multiple Address books
        Dictionary<string, AddressBook> addressBooks = [];

        // Adding First Address Book
        Console.Write("Enter the Name for Address Book : ");
        string? addressbookname = Console.ReadLine();
        if (addressbookname != null)
            addressBooks[addressbookname] = new AddressBook(addressbookname);

        // Maintaining Dictionaries for city and states
        Dictionary<string, List<Contact>> cityPersons = [];
        Dictionary<string, List<Contact>> statePersons = [];

        // Menudriven code for Address book
        int userChoice;
        do
        {
            Console.WriteLine("\n\nEnter the Choice");
            Console.WriteLine("\n1.Add Address Book\n2.Enter Address Book\n3.Search Person by City or State\n4.Search Person by City\n5.Search Person by State\n6.Get count by City or State\n7. Get Sorted Contacts by Name\n8. Get Sorted Contacts by city and state\n0.Exit Application\n");
            userChoice = int.Parse(Console.ReadLine());

            // Choice for Creating Address Book or Entering particular Address Book
            switch(userChoice)
            {
                case 1:
                    // Adding new Address Book 
                    Console.Write("Enter the Name for Address Book : ");
                    string? addressBookname = Console.ReadLine();
                    if (addressbookname != null)
                        addressBooks.Add(addressBookname, new AddressBook(addressBookname));
                    break;
                case 2:
                    Console.Write("\nEnter the Name of Address Book : ");
                    string name = Console.ReadLine();
                    AddressBook addressBook = addressBooks[name];

                    // Menu driven code for Contacts
                    int choice;
                    do
                    {
                        Console.WriteLine("\n\nEnter the Choice : ");
                        Console.WriteLine("\n1.Add Contact\n2.Update Contact\n3.Delete Contact\n4.Display Contacts\n5.Add Multiple Contacts\n0.Exit Address Book\n");
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
                                Contact updatedresponse = addressBook.UpdateContactByName(updatedContact);
                                Console.WriteLine("Updated Contact : " + updatedresponse);
                                break;
                            case 3:
                                // Delete Contact by Name 
                                Console.Write("Enter the Name of Contact to be deleted : ");
                                string deletename = Console.ReadLine();
                                Contact deleteresponse = addressBook.DeleteContactByName(deletename);
                                Console.WriteLine("Deleted Contact details : " + deleteresponse);
                                break;
                            case 4:
                                // Display all Contacts
                                Console.WriteLine($"Contacts in Address Book {addressBook.Name} : ");
                                foreach (var contact in addressBook.GetContacts())
                                    Console.WriteLine(contact);
                                break;
                            case 5:
                                // Add Multiple Contacts
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
                                Console.WriteLine($"Exiting Address Book {addressBook}, Thank you for Visiting");
                                break;
                            default:
                                Console.WriteLine("Wrong Choice");
                                break;
                        }

                    } while (choice != 0);
                    break;
                case 3:
                    Console.Write("Enter the City or State for which Contacts to be Searched : ");
                    String? cityOrState = Console.ReadLine();
                    List<Contact> ResultContacts = [];
                    foreach(var addressbook in addressBooks)
                    {
                        List<Contact> contacts = addressbook.Value.GetContactsByCityOrState(cityOrState);
                        ResultContacts.AddRange(contacts);
                    }
                    foreach(var contact in ResultContacts)
                        Console.WriteLine(contact+" ");
                    break;
                case 4:
                    Console.WriteLine("Fetching the Contacts of each city : ");
                    foreach (var addressbook in addressBooks)
                    {
                        Dictionary<string,List<Contact>> contacts = addressbook.Value.GetContactsByCity();
                        foreach(var contact in contacts)
                            cityPersons.TryAdd(contact.Key,contact.Value);
                    }
                    foreach (var contact in cityPersons)
                    {
                        Console.WriteLine("--------------"+contact.Key + "--------------");
                        foreach(var Contact in contact.Value)
                        {
                            Console.WriteLine(Contact+" ");
                        }
                    }
                    break;
                case 5:
                    Console.WriteLine("Fetching the Contacts of each state : ");
                    foreach (var addressbook in addressBooks)
                    {
                        Dictionary<string, List<Contact>> contacts = addressbook.Value.GetContactsByState();
                        foreach (var contact in contacts)
                            statePersons.TryAdd(contact.Key, contact.Value);
                    }
                    foreach (var contact in statePersons)
                    {
                        Console.WriteLine("-----------------"+contact.Key + "-----------------");
                        foreach (var Contact in contact.Value)
                        {
                            Console.WriteLine(Contact + " ");
                        }
                    }
                    break;
                case 6:
                    Console.Write("Enter the City or State for which Count of Contacts to be given");
                    String? cityOrstate = Console.ReadLine();
                    int count = 0;
                    foreach (var addressbook in addressBooks)
                    {
                        count = addressbook.Value.GetCountByCityOrState(cityOrstate);
                    }
                    Console.WriteLine($"The count of Contacts for {cityOrstate } is {count}");
                    break;
                case 7:
                    Console.Write("Sorted Contacts By Name : ");
                    foreach( var addressbook in addressBooks)
                    {
                        IEnumerable<Contact> Contacts = addressbook.Value.GetSortedContactsByName();
                        foreach(var contact in Contacts)
                        {
                            Console.WriteLine(contact);
                        }
                    }
                    break;
                case 8:
                    Console.Write("Sorted Contacts By city and state : ");
                    foreach (var addressbook in addressBooks)
                    {
                        IEnumerable<Contact> Contacts = addressbook.Value.GetSortedContactsByCityAndState();
                        foreach (var contact in Contacts)
                        {
                            Console.WriteLine(contact);
                        }
                    }
                    break;
                case 0:
                    Console.WriteLine("Exiting Application, Thank you for Visiting"); 
                    break;
                default :
                    Console.WriteLine("Wrong choice");
                    break;
            }
        } while (userChoice != 0);

        Console.WriteLine("Address Books : ");
        foreach (var AddressBook in addressBooks)
            Console.WriteLine(AddressBook);
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
                Console.Write("\nEnter the First Name of contact to be updated : ");
            String firstname = UserInput();

            if (action.Equals("new"))
                Console.Write("Enter the Last Name : ");
            else
                Console.Write("Enter the Last Name of contact to be updated : ");
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