using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddressBook
    {
        static AddressBook()
        {
            Console.WriteLine("Welcome to Address Book Application");
        }
        private List<Contact> Contacts { get; set; } = [];

        public String AddContact(Contact contact)
        {
            if (contact != null)
            {
                Contacts.Add(contact);
                return "Contact Added Successfully";
            }
            return "Failed to Add Contact, Please Try Again";
        }

        public List<Contact> GetContacts() {  return Contacts; }

        public Contact GetContact(int id) {  return Contacts[id]; } 
    }


    // User Defined Exception to validate the User input 
    public class NullInputException(String issue) : ApplicationException
    {
        public string Issue { get; set; } = issue;
    }
}
