using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddressBookRepository
    {
        public string Path { get; set; } = @"C:\Users\proir\Desktop\Training\Tasks\AddressBookSystem\address_book.txt";

        public string SerializeContacts(List<Contact> contacts)
        {
            
            string jsonText = JsonConvert.SerializeObject(contacts);

            // Write JSON string to a text file
            File.WriteAllText(Path, jsonText);
            return "Contact Saved to File Successfully";
        }

        public List<Contact> DeserializeContacts()
        {
            string jsonFromFile = File.ReadAllText(Path);
            return JsonConvert.DeserializeObject<List<Contact>>(jsonFromFile);
        }
    }
}
