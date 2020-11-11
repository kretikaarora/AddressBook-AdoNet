// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace AddressBook_AdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book AdoNet");
            AddressBookOperations addressBookOperations = new AddressBookOperations();
            var list = addressBookOperations.GetAllContactDetails();
            foreach(ContactDetails contactDetails in list)
            {
                Console.WriteLine(contactDetails.firstName,contactDetails.typeName,contactDetails.address);
            }
        }
    }
}
