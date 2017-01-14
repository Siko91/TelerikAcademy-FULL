namespace NinjaFactory.Imports
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Windows.Forms;
    using NinjaFactory.DataBase;

    public class ExcelImport
    {
        /*
        //================================================================================================
        //                                      HOW TO USE EXAMPLE
        //================================================================================================

        //The name of the zip file
        //string zipFileName = "Sample-Sales-Reports.zip";

        //The full path where the zip archive is stored. In our case the path that is returned from the OpenDialog
        //string zipFilePath = @"E:\DEV\DataBasesTeamWork_TeamBlackDragon\Example TeamBlackDragon\" + zipFileName;

        //This can be a constant and must be extended to match .xlsx too
        //string filePattern = "*.xls";

        //The folder where the zip will be extracted
        //string extractFolderPath = @"C:\Users\vesel_000\Desktop\ZipFile-from-C#";

        //ExtractFile(zipFileName, zipFilePath, extractFolderPath);

        //Here the files will be imported to the DB
        //ProcessExcelFiles(extractFolderPath, filePattern);

        //================================================================================================
        //                                      HOW TO USE EXAMPLE
        //================================================================================================
        */
        public static void ExtractFile(string fullFilePath, string extractToPath)
        {
            int index = fullFilePath.LastIndexOf("\\");
            if (index == -1)
            {
                index = 0;
            }

            string directory = fullFilePath.Substring(0, index);
            string fileName = fullFilePath.Substring(index);
            ExtractFile(fileName, directory, extractToPath);
        }

        public static void ExtractFile(string zipFileName, string zipSourcePath, string extractToPath)
        {
            ////Check if the extractToPath folder exists
            if (!Directory.Exists(extractToPath))
            {
                Directory.CreateDirectory(extractToPath);
            }

            ////Check if the folder is not empty to delete everything in it
            if (Directory.GetDirectories(extractToPath).Length >= 0 && Directory.GetFiles(extractToPath).Length >= 0)
            {
                Directory.Delete(extractToPath + "\\" + zipFileName.Split('.')[0], true);
            }

            ////Extract the .zip file
            ZipFile.ExtractToDirectory(zipSourcePath + "\\" + zipFileName, extractToPath);
        }

        public static void ProcessExcelFiles(string rootDirPath, string pattern, INinjaFactoryData db)
        {
            var files = Directory.GetFiles(rootDirPath, pattern);
            if (string.IsNullOrEmpty(pattern))
            {
                files = Directory.GetFiles(rootDirPath);
            }

            ImportExcelFilesIntoDb(files, db);

            var directories = Directory.GetDirectories(rootDirPath);

            foreach (var dir in directories)
            {
                var dirFiles = Directory.GetFiles(dir, pattern);

                ImportExcelFilesIntoDb(dirFiles, db);

                ProcessExcelFiles(dir, pattern, db);
            }
        }

        private static bool CheckJobIsValid(DataBase.Job job, INinjaFactoryData db)
        {
            var unfinishedJobsCountOfSameNinja = db.Jobs
                .Where(j => j.NinjaId == job.NinjaId)
                .Where(j => j.IsSuccessfull.HasValue == false)
                .Count();

            if (unfinishedJobsCountOfSameNinja > 0)
            {
                throw new ArgumentException("A ninja can not take two jobs at the same time. Job '" + job.Name + "' was not imported");
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Imports data in database
        /// </summary>
        /// <param name="files"> excel files containing import data </param>
        /// <param name="db"> the database to import the data in </param>
        private static void ImportExcelFilesIntoDb(string[] files, INinjaFactoryData db)
        {
            string sheetName = "Sales";

            foreach (var filePath in files)
            {
                DataTable excelTable = ReadExcelFile(filePath, sheetName);

                for (int i = 2; i < excelTable.Rows.Count - 1; i++)
                {
                    var row = excelTable.Rows[i];

                    int ninjaId = int.Parse(row.ItemArray[0].ToString());
                    int clientId = int.Parse(row.ItemArray[1].ToString());
                    string briefDescription = row.ItemArray[2].ToString();
                    double jobPrice = double.Parse(row.ItemArray[3].ToString());

                    DataBase.Job job = new DataBase.Job()
                    {
                        NinjaId = ninjaId,
                        ClientId = clientId,
                        Name = briefDescription,
                        Price = (decimal)jobPrice,
                        StartDate = DateTime.Now,
                        IsDeleted = false
                    };

                    try
                    {
                        CheckJobIsValid(job, db);
                        ImportJobToDb(job, db);
                    }
                    catch (ArgumentException ae)
                    {
                        MessageBox.Show(ae.Message);
                    }
                }
            }
        }

        private static void ImportJobToDb(DataBase.Job job, INinjaFactoryData db)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
        }

        private static DataTable ReadExcelFile(string filePath, string sheetName)
        {
            OleDbConnection connection = new OleDbConnection();

            using (connection)
            {
                DataTable table = new DataTable();

                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                OleDbCommand command = new OleDbCommand();
                using (command)
                {
                    command.CommandText = "SELECT * FROM [" + sheetName + "$]";
                    command.Connection = connection;

                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    using (adapter)
                    {
                        adapter.SelectCommand = command;
                        adapter.Fill(table);

                        return table;
                    }
                }
            }
        }
    }
}