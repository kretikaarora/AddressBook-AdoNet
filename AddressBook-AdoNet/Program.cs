// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------

using System;

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
            Console.WriteLine(addressBookOperations.GetContactDetailsBetweenDateRange() ? "Query Succesful " : "Failed");
        }
    }
}
