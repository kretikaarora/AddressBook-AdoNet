// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace AddressBook_AdoNet
{
    /// <summary>
    /// Program Class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book AdoNet");
            AddressBookOperations addressBookOperations = new AddressBookOperations();
            ContactDetails contactDetails = new ContactDetails();
            contactDetails.firstName = "aayush";
            contactDetails.lastName = "arora";
            contactDetails.phoneNumber = 877655447;
            contactDetails.email = "aa@gmail.com";
            contactDetails.city = "bang";
            contactDetails.start = Convert.ToDateTime("1/2/2018");
            contactDetails.state = "AP";
            contactDetails.addressBookId = 6;
            contactDetails.completeAddressId = 106;
            contactDetails.addressBookName = "First";
            contactDetails.address = "street 6";
            contactDetails.zip = 09865;
            contactDetails.typeId = 1;
            contactDetails.typeName = "Friends";
            List<ContactDetails> listOfContactsToBeAdded = new List<ContactDetails>();
            listOfContactsToBeAdded.Add(contactDetails);
            addressBookOperations.AddingMultipleContactDetailsUsingThreading(listOfContactsToBeAdded);

        }
    }
}
