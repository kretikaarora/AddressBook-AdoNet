// --------------------------------------------------------------------------------------------------------------------
// <copyright file=" AddressBookOperations.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace AddressBook_AdoNet
{
    /// <summary>
    /// Address Book Operations
    /// </summary>
    class AddressBookOperations
    {
        /// <summary>
        /// creating an instance of connection class
        /// </summary>
        DBConnection dBConnection = new DBConnection();

        /// <summary>
        /// reading all contacts and storing them in a list
        /// UC16
        /// </summary>
        /// <returns></returns>
        public List<ContactDetails> GetAllContactDetails()
        {
            List<ContactDetails> ListOfContacts = new List<ContactDetails>();
            ///Getting connection
            SqlConnection sqlConnection = dBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    ///using stored procedure
                    SqlCommand command = new SqlCommand("spGetAllContacts", sqlConnection);
                    ///opening connection
                    sqlConnection.Open();                   
                    SqlDataReader dr = command.ExecuteReader();
                    ///checking if rows are there
                    if (dr.HasRows)
                    {
                        ///reading till there are rows
                        while (dr.Read())
                        {
                            ContactDetails contactDetails = new ContactDetails();
                            contactDetails.firstName = dr.GetString(0);
                            contactDetails.lastName = dr.GetString(1);
                            contactDetails.address = dr.GetString(2);
                            contactDetails.city = dr.GetString(3);
                            contactDetails.state = dr.GetString(4);
                            contactDetails.zip = dr.GetInt32(5);
                            contactDetails.phoneNumber = dr.GetFloat(6);
                            contactDetails.email = dr.GetString(7);
                            contactDetails.addressBookId = dr.GetInt32(8);
                            contactDetails.completeAddressId = dr.GetInt32(9);
                            contactDetails.addressBookName = dr.GetString(10);
                            contactDetails.typeId = dr.GetInt32(11);
                            contactDetails.typeName = dr.GetString(12);
                            ListOfContacts.Add(contactDetails);
                        }
                        ///closing reader and connection
                        dr.Close();
                        sqlConnection.Close();
                        ///returning list 
                        return ListOfContacts;
                    }
                    else
                    {
                        throw new Exception("No data Found");                       
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ListOfContacts;
            }
            finally
            {
                sqlConnection.Close();
            }            
        }
    }
}
