using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Task9_MySQLConnector
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string commandString = "";

            string serverName = "127.0.0.1";
            string dbName = "test";
            string userName = "root";
            string passWord = "";

            MySqlConnection dbCon = new MySqlConnection("Server=" + serverName + ";Database=" + dbName + ";Uid=" + userName + ";Pwd=" + passWord + ";");
            dbCon.Open();
            using (dbCon)
            {
                MySqlCommand cmdAllEmployees = new MySqlCommand(commandString, dbCon);

                // I've got 99 problems, but MySQL ain't one!
            }
        }
    }
}