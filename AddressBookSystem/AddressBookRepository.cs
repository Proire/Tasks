using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace AddressBookSystem
{
    internal class AddressBookRepository
    {
        public string Path { get; set; } = @"C:\Users\proir\Desktop\Training\Tasks\AddressBookSystem\address_book.json";

        public string SerializeContacts(List<Contact> contacts)
        { 
            string jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(Path, jsonData);
            return "Contact Saved to File Successfully";
        }

        public List<Contact> DeserializeContacts()
        {
            string jsonData = File.ReadAllText(Path);
            List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
            return contacts;
        }
    }
}
