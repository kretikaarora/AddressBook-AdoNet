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
        public void GetAllContactDetails()
        {
            List<ContactDetails> ListOfContacts = new List<ContactDetails>();
            ///Getting connection
            SqlConnection sqlConnection = dBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    ///using stored procedure
                    SqlCommand command = new SqlCommand("dbo.spGetAllContacts", sqlConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
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
                            contactDetails.firstName = Convert.ToString(dr["firstname"]);
                            contactDetails.lastName = Convert.ToString(dr["lastname"]);
                            contactDetails.address = Convert.ToString(dr["address"]);
                            contactDetails.city = Convert.ToString(dr["city"]);
                            contactDetails.state = Convert.ToString(dr["state"]);
                            contactDetails.zip = Convert.ToInt32(dr["zip"]);
                            contactDetails.phoneNumber = Convert.ToDouble(dr["phonenumber"]);
                            contactDetails.email = Convert.ToString(dr["email"]);
                            contactDetails.addressBookId = Convert.ToInt32(dr["AddressBookId"]);
                            contactDetails.completeAddressId = Convert.ToInt32(dr["CompleteAddressId"]);
                            contactDetails.addressBookName = Convert.ToString(dr["addressBookName"]);
                            contactDetails.typeId = Convert.ToInt32(dr["TypeId"]);
                            contactDetails.typeName = Convert.ToString(dr["TypeName"]);
                            contactDetails.start = Convert.ToDateTime(dr["start"]);                           
                            ListOfContacts.Add(contactDetails);
                        }
                        ///closing reader and connection
                        dr.Close();
                        sqlConnection.Close();
                        //return true;

                    }
                    else
                    {
                        throw new Exception("No data Found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

        /// <summary>
        /// Updating email and phonenumber using firstname lastname and addressbookname
        /// UC17
        /// </summary>
        /// <param name="contactDetails"></param>
        /// <returns></returns>
        public bool UpdateAddressBookDetails(ContactDetails contactDetails)
        {
            ///getting Connection
            SqlConnection sqlConnection = dBConnection.GetConnection();
            try
            {
                ///checking if connection is established
                using (sqlConnection)
                {
                    ///stored procedure
                    SqlCommand command = new SqlCommand("dbo.spUpdateContactDetails", sqlConnection);
                    ///changing command type to stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    ///adding value using cmd
                    command.Parameters.AddWithValue("@firstname", contactDetails.firstName);
                    command.Parameters.AddWithValue("@lastname", contactDetails.lastName);
                    command.Parameters.AddWithValue("@phonenumber", contactDetails.phoneNumber);
                    command.Parameters.AddWithValue("@email", contactDetails.email);
                    command.Parameters.AddWithValue("@addressBookName", contactDetails.addressBookName);
                    sqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    ///checking if rows are being affected
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

        /// <summary>
        /// Get Contact Details Between DateRange
        /// UC18
        /// </summary>
        /// <returns></returns>
        public bool GetContactDetailsBetweenDateRange()
        {
            ///Getting Connection
            SqlConnection connection = dBConnection.GetConnection();
            try
            {
                ///checking if connection is established
                using (connection)
                {
                    ///query
                    string query = "select * from address_book_table where start between cast('2016-01-01' as date) and GETDATE()";
                    SqlCommand command = new SqlCommand(query, connection);
                    ///openning connection
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    ///checking if database hasrows 
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ///reading
                            ContactDetails contactDetails = new ContactDetails();
                            contactDetails.firstName = Convert.ToString(dr["firstname"]);
                            contactDetails.lastName = Convert.ToString(dr["lastname"]);                           
                            contactDetails.phoneNumber = Convert.ToDouble(dr["phonenumber"]);
                            contactDetails.email = Convert.ToString(dr["email"]);
                            contactDetails.addressBookId = Convert.ToInt32(dr["AddressBookId"]);
                            contactDetails.completeAddressId = Convert.ToInt32(dr["CompleteAddressId"]);
                            contactDetails.addressBookName = Convert.ToString(dr["addressBookName"]);
                            contactDetails.start = Convert.ToDateTime(dr["start"]);                          
                            dr.Close();
                            connection.Close();
                            return true;
                        }
                    }
                    else
                    {
                        throw new Exception("No data found ");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return false;
        }

        /// <summary>
        /// Get Contacts By City Or State
        /// UC19
        /// </summary>
        /// <returns></returns>
        public bool GetContactsByCityOrState()
        {
            List<ContactDetails> ListOfContacts = new List<ContactDetails>();
            ///Getting connection
            SqlConnection sqlConnection = dBConnection.GetConnection();
            try
            {
                using (sqlConnection)
                {
                    ///using stored procedure
                    string query = "select * from address_book_table a join complete_address c on a.CompleteAddressId=c.CompleteAddressId where c.city='delhi' ";
                    SqlCommand command = new SqlCommand(query, sqlConnection);              
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
                            contactDetails.firstName = Convert.ToString(dr["firstname"]);
                            contactDetails.lastName = Convert.ToString(dr["lastname"]);
                            contactDetails.address = Convert.ToString(dr["address"]);
                            contactDetails.city = Convert.ToString(dr["city"]);
                            contactDetails.state = Convert.ToString(dr["state"]);
                            contactDetails.zip = Convert.ToInt32(dr["zip"]);
                            contactDetails.phoneNumber = Convert.ToDouble(dr["phonenumber"]);
                            contactDetails.email = Convert.ToString(dr["email"]);
                            contactDetails.addressBookId = Convert.ToInt32(dr["AddressBookId"]);
                            contactDetails.completeAddressId = Convert.ToInt32(dr["CompleteAddressId"]);
                            contactDetails.addressBookName = Convert.ToString(dr["addressBookName"]);                   
                            contactDetails.start = Convert.ToDateTime(dr["start"]);
                            ListOfContacts.Add(contactDetails);                           
                        }
                        ///closing reader and connection
                        dr.Close();
                        sqlConnection.Close();
                        return true;

                    }
                    else
                    {
                        throw new Exception("No data Found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

        /// <summary>
        /// Adding Contact Details In Database
        /// UC20
        /// </summary>
        /// <param name="contactDetails"></param>
        /// <returns></returns>
        public bool AddingContactDetailsInDatabase(ContactDetails contactDetails)
        {
            SqlConnection connection = dBConnection.GetConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.spInsertData", connection);
                    ///changing command type to stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", contactDetails.firstName);
                    command.Parameters.AddWithValue("@lastname", contactDetails.lastName);
                    command.Parameters.AddWithValue("@phonenumber", contactDetails.phoneNumber);
                    command.Parameters.AddWithValue("@email", contactDetails.email);
                    command.Parameters.AddWithValue("@addressBookName", contactDetails.addressBookName);
                    command.Parameters.AddWithValue("@AddressBookId", contactDetails.addressBookId);
                    command.Parameters.AddWithValue("@CompleteAddressId", contactDetails.completeAddressId);
                    command.Parameters.AddWithValue("@start", contactDetails.start);
                    command.Parameters.AddWithValue("@address", contactDetails.address);
                    command.Parameters.AddWithValue("@city", contactDetails.city);
                    command.Parameters.AddWithValue("@state", contactDetails.state);
                    command.Parameters.AddWithValue("@zip", contactDetails.zip);
                    command.Parameters.AddWithValue("@TypeId", contactDetails.typeId);
                    command.Parameters.AddWithValue("@TypeName", contactDetails.typeName);
                    ///opening connection
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}

