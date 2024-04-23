﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Contact(string firstName,string lastName, string address, string city, long zip, string state, long phoneNumber, string email)
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;

        public string Address { get; set; } = address;

        public string City { get; set; } = city;

        public long Zip { get; set; } = zip;

        public string State { get; set; } = state;

        public long PhoneNumber { get; set; } = phoneNumber;

        public string Email { get; set; } = email;

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Address} {City} {Zip} {State} {PhoneNumber} {Email}";
        }
    }
}
