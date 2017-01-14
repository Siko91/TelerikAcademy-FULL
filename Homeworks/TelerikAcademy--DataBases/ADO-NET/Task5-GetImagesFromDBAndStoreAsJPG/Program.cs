using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_GetImagesFromDBAndStoreAsJPG
{
    internal class Program
    {
        private static void ExtractImagesFromDB()
        {
            string serverName = "TEDI-05-PC";
            string dbName = "Northwind";

            SqlConnection dbCon = new SqlConnection("Server=" + serverName + "; " +
            "Database=" + dbName + "; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Categories ", dbCon);
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("Warning! The files are broken...\nBut I extracted them anyway. Have fun!\n\n\n");
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"] + ".jpg";
                        byte[] image = (byte[])reader["Picture"];

                        while (name.IndexOf("/") != -1)
                        {
                            name = name.Replace("/", " or ");
                        }

                        WriteBinaryFile(name, image);
                        Console.WriteLine("Extracting file: " + name);
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            ExtractImagesFromDB();
        }

        private static void WriteBinaryFile(string fileName,
            byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }
    }
}