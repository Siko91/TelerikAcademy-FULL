using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_SimpleConnectionToMSSQL
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
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);
                int employeesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("there are {0} categories", employeesCount);
                Console.WriteLine();
            }
        }
    }
}