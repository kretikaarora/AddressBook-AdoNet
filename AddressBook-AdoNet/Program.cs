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
            ContactDetails contactDetails =  new ContactDetails();
            contactDetails.firstName = "daisy";
            contactDetails.lastName = "erison";
            contactDetails.phoneNumber = 8111100011;
            contactDetails.email = "eric@skype.com";
            contactDetails.addressBookName = "First";
            Console.WriteLine("bool value"+addressBookOperations.UpdateAddressBookDetails(contactDetails)); 
        }
    }
}
