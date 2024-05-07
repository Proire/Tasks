using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddressBookMain
    {
        static AddressBookMain()
        {
            Console.WriteLine("---------------------- Welcome to Address Book Application ----------------------\n");
        }

        // Dictinary to maintain mulitple Address books
        public Dictionary<string, AddressBook> addressBooks = [];

        // Maintaining Dictionaries for city and states
        public Dictionary<string, List<Contact>> cityPersons = [];
        public Dictionary<string, List<Contact>> statePersons = [];

        public void AddAddressBook()
        {
            Console.Write("Enter the Name for Address Book : ");
            string? addressbookname = Console.ReadLine();
            if (addressbookname != null)
                addressBooks[addressbookname] = new AddressBook(addressbookname);
        }

        public Dictionary<string, AddressBook> GetAddressBooks()
        {
            return addressBooks;
        }

        public void PrintAddressBooks()
        {
            Console.WriteLine("Address Books : ");
            foreach (var AddressBook in GetAddressBooks())
                Console.WriteLine(AddressBook);
        }

        public AddressBook GetAddressBookByName(string name)
        {
            return addressBooks[name];
        }

        public void EnterAddressBook()
        {
            
            Console.Write("\nEnter the Name of Address Book : ");
            string? name = Console.ReadLine();
            AddressBook addressBook;
            if (name != null)
                addressBook = GetAddressBookByName(name);
            else
                throw new NullInputException("Null Value not allowed");

            // Menu driven code for Contacts
            int choice;
            do
            {
                Console.WriteLine("\n\nEnter the Choice : ");
                Console.WriteLine("\n1.Add Contact\n2.Update Contact\n3.Delete Contact\n4.Display Contacts\n5.Add Multiple Contacts\n0.Exit Address Book\n");
                _ = int.TryParse(Console.ReadLine(), out choice);
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
           
        }

        public void SearchAddressBooksByCityOrState()
        {
            Console.Write("Enter the City or State for which Contacts to be Searched : ");
            String? cityOrState = Console.ReadLine();
            List<Contact> ResultContacts = [];
            foreach (var addressbook in addressBooks)
            {
                List<Contact> contacts = addressbook.Value.GetContactsByCityOrState(cityOrState);
                ResultContacts.AddRange(contacts);
            }
            foreach (var contact in ResultContacts)
                Console.WriteLine(contact + " ");
        }

        public void SearchAddressBookForEachCity()
        {
            Console.WriteLine("Fetching the Contacts of each city : ");
            foreach (var addressbook in addressBooks)
            {
                Dictionary<string, List<Contact>> contacts = addressbook.Value.GetContactsByCity();
                foreach (var contact in contacts)
                    cityPersons.TryAdd(contact.Key, contact.Value);
            }
            foreach (var contact in cityPersons)
            {
                Console.WriteLine("--------------" + contact.Key + "--------------");
                foreach (var Contact in contact.Value)
                {
                    Console.WriteLine(Contact + " ");
                }
            }
        }

        public void SearchAddressBookForEachState()
        {
            Console.WriteLine("Fetching the Contacts of each state : ");
            foreach (var addressbook in addressBooks)
            {
                Dictionary<string, List<Contact>> contacts = addressbook.Value.GetContactsByState();
                foreach (var contact in contacts)
                    statePersons.TryAdd(contact.Key, contact.Value);
            }
            foreach (var contact in statePersons)
            {
                Console.WriteLine("-----------------" + contact.Key + "-----------------");
                foreach (var Contact in contact.Value)
                {
                    Console.WriteLine(Contact + " ");
                }
            }
        }

        public void CountOfContactsByCityOrState()
        {
            Console.Write("Enter the City or State for which Count of Contacts to be given");
            String? cityOrstate = Console.ReadLine();
            int count = 0;
            foreach (var addressbook in addressBooks)
            {
                count = addressbook.Value.GetCountByCityOrState(cityOrstate);
            }
            Console.WriteLine($"The count of Contacts for {cityOrstate} is {count}");
        }

        public void SortedContactsByName()
        {
            Console.Write("Sorted Contacts By Name : ");
            foreach (var addressbook in addressBooks)
            {
                IEnumerable<Contact> Contacts = addressbook.Value.GetSortedContactsByName();
                foreach (var contact in Contacts)
                {
                    Console.WriteLine(contact);
                }
            }
        }

        public void SortedContactsByCityAndState()
        {
            Console.Write("Sorted Contacts By city and state : ");
            foreach (var addressbook in addressBooks)
            {
                IEnumerable<Contact> Contacts = addressbook.Value.GetSortedContactsByCityAndState();
                foreach (var contact in Contacts)
                {
                    Console.WriteLine(contact);
                }
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
