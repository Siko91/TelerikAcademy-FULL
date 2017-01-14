using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_SearchProductsByString
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string serverName = "TEDI-05-PC";
            string dbName = "Northwind";

            Console.Write("Input search string: ");
            string input = Console.ReadLine();

            SqlConnection dbCon = new SqlConnection("Server=" + serverName + "; " +
            "Database=" + dbName + "; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                Console.WriteLine("\nThe Product Names:\n");
                SqlCommand cmdAllEmployees = new SqlCommand(
                  "SELECT ProductName FROM Products WHERE ProductName LIKE '%" + input + "%'", dbCon);
                SqlDataReader reader = cmdAllEmployees.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["ProductName"];
                        Console.WriteLine("{0}", name);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}