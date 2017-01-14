using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_JoinQuery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string query = "SELECT c.CategoryName, p.ProductName FROM Categories c RIGHT OUTER JOIN Products p ON p.CategoryID = c.CategoryID";

            string serverName = "TEDI-05-PC";
            string dbName = "Northwind";

            SqlConnection dbCon = new SqlConnection("Server=" + serverName + "; " +
            "Database=" + dbName + "; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdAllEmployees = new SqlCommand(query, dbCon);
                SqlDataReader reader = cmdAllEmployees.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string catName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("Category '{0}' has the product '{1}'", catName, productName);
                    }
                }
            }
        }
    }
}