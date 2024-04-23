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
    }
}
