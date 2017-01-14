using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_CreateExcelTable
{
    internal class Program
    {
        private const string DataProviderString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelFileXls + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";

        private const string ExcelFileXls = "ExcelFile.xls";

        private static void DisplayRowsOfExcelFile(OleDbConnection excelCon)
        {
            using (excelCon)
            {
                OleDbCommand cmdAllEmployees = new OleDbCommand("SELECT * FROM Sheet1", excelCon);
                OleDbDataReader reader = cmdAllEmployees.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["name"];
                        string score = (string)reader["score"];
                        Console.WriteLine("Name '{0}' has score of {1}", name, score);
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            OleDbConnection excelCon;

            if (!File.Exists(ExcelFileXls))
            {
                excelCon = new OleDbConnection(DataProviderString);
                excelCon.Open();

                OleDbCommand cmdInsertProject = new OleDbCommand(
                    "CREATE TABLE Sheet1 (name char(255), score char(255))", excelCon);
                cmdInsertProject.ExecuteNonQuery();
            }
            else
            {
                excelCon = new OleDbConnection(DataProviderString);
                excelCon.Open();
            }

            DisplayRowsOfExcelFile(excelCon);
        }
    }
}