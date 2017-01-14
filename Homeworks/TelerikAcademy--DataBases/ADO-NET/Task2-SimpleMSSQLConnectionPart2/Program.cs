using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_SimpleMSSQLConnectionPart2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string serverName = "TEDI-05-PC";
            string dbName = "Northwind";

            SqlConnection dbCon = new SqlConnection("Server=" + serverName + "; " +
            "Database=" + dbName + "; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                Console.WriteLine("The categories:");
                SqlCommand cmdAllEmployees = new SqlCommand(
                  "SELECT * FROM Categories", dbCon);
                SqlDataReader reader = cmdAllEmployees.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        // I used these indexers, becouse there was a spelling misstake in the
                        // column name of my database, but it is likely that your database won,t
                        // have the same mistake.

                        string catName = (string)reader[1];
                        string catDescr = (string)reader[2];
                        Console.WriteLine("{0} --- {1}", catName, catDescr);
                    }
                }
            }
        }
    }
}