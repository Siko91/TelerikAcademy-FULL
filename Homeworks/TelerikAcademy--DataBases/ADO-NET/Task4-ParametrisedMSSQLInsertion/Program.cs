using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_ParametrisedMSSQLInsertion
{
    internal class Program
    {
        private static int InsertProduct(SqlConnection dbCon, string name, double price)
        {
            SqlCommand cmdInsertProject = new SqlCommand(
                "INSERT INTO Products (ProductName, UnitPrice, Discontinued) VALUES (@name, @price, 0)", dbCon);
            cmdInsertProject.Parameters.AddWithValue("@name", name);
            cmdInsertProject.Parameters.AddWithValue("@price", price);
            cmdInsertProject.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }

        private static void Main(string[] args)
        {
            string serverName = "TEDI-05-PC";
            string dbName = "Northwind";

            SqlConnection dbCon = new SqlConnection("Server=" + serverName + "; " +
            "Database=" + dbName + "; Integrated Security=true");
            dbCon.Open();
            int result = InsertProduct(dbCon, "CocoaColla", 3.20);

            using (dbCon)
            {
                SqlCommand cmdAllEmployees = new SqlCommand("SELECT * FROM Products WHERE ProductID = " + result, dbCon);
                SqlDataReader reader = cmdAllEmployees.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("Product '{0}' has been added  at the {1}th position", productName, result);
                    }
                }
            }
        }
    }
}