// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBConnection.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook_AdoNet
{
    public class DBConnection
    {
        public SqlConnection GetConnection()
        {
            //string connectionString = @"Data Source=LAPTOP-TAR1C56T\MSSQLSERVER01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string connectionString = @"Server=LAPTOP-TAR1C56T\MSSQLSERVER01;Database=address_book_service;Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
