// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" ContactDetails.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook_AdoNet
{
    /// <summary>
    /// Contact Details
    /// </summary>
    class ContactDetails
    {      
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public float phoneNumber { get; set; }
        public string email { get; set; }
        public int addressBookId { get; set; }
        public int completeAddressId { get; set; }
        public string addressBookName { get; set; }
        public int typeId { get; set; }
        public string typeName { get; set; }
    }
}
