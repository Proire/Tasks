using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddressBook
    {
        public AddressBook(string addressbookname)
        {
            this.Name = addressbookname;
            Console.WriteLine($"\n---------------------- Created {addressbookname} Address Book ----------------------");
        }
        private List<Contact> Contacts { get; set; } = [];

        public string Name { get; set; } 
        public String AddContact(Contact contact)
        {
            Contact ContactPresent = Contacts.FirstOrDefault(cont => cont.Equals(contact));
            Console.WriteLine("he kay :"+ContactPresent);
            if (contact != null && ContactPresent == null)
            {
                int id;
                if(Contacts.Count != 0)
                    id = Contacts.Max(x => x.Id);
                else
                    id = 0;
                contact.Id = id + 1;
                Contacts.Add(contact);
                return "Contact Added Successfully";
            }
            return "Failed to Add Contact, Please Try Again";
        }

        public List<Contact> GetContacts() {  return Contacts; }

        public Contact GetContact(int id) {  return Contacts[id]; } 

        public Contact UpdateContactByName(Contact newContact)
        {
            Contact? oldContact = Contacts.FirstOrDefault(contact => contact.FirstName == newContact.FirstName && contact.LastName == newContact.LastName);    
            if(oldContact != null)
            {
                oldContact.LastName = newContact.LastName;
                oldContact.Zip = newContact.Zip;
                oldContact.PhoneNumber = newContact.PhoneNumber;    
                oldContact.City = newContact.City;
                oldContact.Email = newContact.Email;
                oldContact.Address = newContact.Address;    
                oldContact.State = newContact.State;    
            }
            return oldContact;
        }

        public Contact DeleteContactByName(string firstName)
        {
            Contact? contact = Contacts.FirstOrDefault(contact => contact.FirstName == firstName);
            if(contact != null) 
            { 
                Contacts.Remove(contact);
            }
            return contact;
        }

        public List<Contact> GetContactByCityOrState(string cityOrState)
        {
            List<Contact> contacts = [];
            if(cityOrState != null)
            {
                contacts = Contacts.FindAll(contact => (contact.City == cityOrState) || (contact.State==cityOrState));
            }
            return contacts;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }


    // User Defined Exception to validate the User input 
    public class NullInputException(String issue) : ApplicationException
    {
        public string Issue { get; set; } = issue;
    }
}
