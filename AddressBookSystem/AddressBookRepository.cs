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
        public string Path { get; set; } = @"C:\Users\proir\Desktop\Training\Tasks\AddressBookSystem\address_book.csv";

        public string SerializeContacts(List<Contact> contacts)
        {

            using (var writer = new StreamWriter(Path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(contacts);
            }
            return "Contact Saved to File Successfully";
        }

        public List<Contact> DeserializeContacts()
        {
            using (var reader = new StreamReader(Path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ContactMap>();
                return csv.GetRecords<Contact>().ToList();
            }
        }
    }
}
