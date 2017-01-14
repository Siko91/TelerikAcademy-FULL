namespace NinjaFactory.ExcelReporting
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using NinjaFactory.DataBase.MySql;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    /// <summary>
    /// Creates success rate of ninjas reports as Excel files
    /// </summary>
    public class ExcelSuccessRateReportCreator
    {
        ////private const string SQLitePath = "Data Source=ninja_specialties.db;Version=3;New=False;Compress=True;";

        public Dictionary<string, string> LoadSQliteData()
        {
            var specialties = new Dictionary<string, string>();
            try
            {
                var connection = new SQLiteConnection("Data Source=ninja_specialties.db;Version=3;New=False;Compress=True;");
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Specialty, Weight FROM Specialties";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string specialty = reader[0].ToString();
                    string weight = reader[1].ToString();
                    specialties.Add(specialty, weight);
                }

                connection.Close();
            }
            catch (Exception exc)
            {
                throw new ArgumentException(exc.Message);
            }
            
            return specialties;
        }

        public void CreateSuccessRateReport(INinjaCatalogueModelUnitOfWork db, string filePath)
        {
            IEnumerable<NinjaReport> successRateReport;
            var specialties = this.LoadSQliteData();
            successRateReport = this.SelectSuccessRateList(db, specialties);
            this.WriteToFile(successRateReport, filePath); 
        }

        private IEnumerable<NinjaReport> SelectSuccessRateList(INinjaCatalogueModelUnitOfWork db, IDictionary<string, string> specialties)
        {
            var ninjas = db.Ninja_catalogue_items
                .OrderBy(item => item.SuccessRate)
                .Select(item => new NinjaReport()
                       {
                           Id = item.Id,
                           Name = item.Name,
                           Weapon = item.Weapon,
                           SpecialtyWeight = int.Parse(specialties[item.Speciality]),
                           Speciality = item.Speciality,
                           SuccessfulJobsCount = item.SuccessfulJobsCount,
                           KillCount = item.KillCount,
                           SuccessRate = item.SuccessRate
                       }).ToList<NinjaReport>();
            return ninjas.OrderByDescending(ninja => ninja.SpecialtyWeight);
        }

        private void WriteToFile(IEnumerable<NinjaReport> successRateReportList, string filePath)
        {
            // Create the file using the FileInfo object
            var excelFile = File.Create(filePath);

            using (var excelPackage = new ExcelPackage(excelFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Success rate report - " + DateTime.Now.ToShortDateString());

                worksheet.TabColor = Color.Blue;
                worksheet.DefaultRowHeight = 12;
                worksheet.HeaderFooter.FirstFooter.LeftAlignedText = string.Format("Generated: {0}", DateTime.Now.ToShortDateString());
                worksheet.Row(1).Height = 20;
                worksheet.Row(2).Height = 18;

                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Name of the ninja";
                worksheet.Cells[1, 3].Value = "Weapon used";
                worksheet.Cells[1, 4].Value = "Speciality weight";
                worksheet.Cells[1, 5].Value = "Speciality";
                worksheet.Cells[1, 6].Value = "Jobs Done";
                worksheet.Cells[1, 7].Value = "Kill Count";
                worksheet.Cells[1, 8].Value = "Success Rate";

                var rowIndex = 2;
                foreach (var report in successRateReportList)
                {
                    worksheet.Cells[rowIndex, 1].Value = report.Id;
                    worksheet.Cells[rowIndex, 2].Value = report.Name;
                    worksheet.Cells[rowIndex, 3].Value = report.Weapon;
                    worksheet.Cells[rowIndex, 4].Value = report.SpecialtyWeight;
                    worksheet.Cells[rowIndex, 5].Value = report.Speciality;
                    worksheet.Cells[rowIndex, 6].Value = report.SuccessfulJobsCount;
                    worksheet.Cells[rowIndex, 7].Value = report.KillCount;
                    worksheet.Cells[rowIndex, 8].Value = report.SuccessRate;

                    rowIndex++;
                }

                using (var range = worksheet.Cells[1, 1, 1, 8])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Black);
                    range.Style.Font.Color.SetColor(Color.WhiteSmoke);
                    range.Style.ShrinkToFit = true;
                }

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();
                worksheet.Column(4).AutoFit();
                worksheet.Column(5).AutoFit();
                worksheet.Column(6).AutoFit();
                worksheet.Column(7).AutoFit();
                worksheet.Column(8).AutoFit();

                // Set document properties
                excelPackage.Workbook.Properties.Title = "Success rate report";
                excelPackage.Workbook.Properties.Author = "Team Black Dragon";
                excelPackage.Workbook.Properties.Company = "Telerik Academy";

                excelPackage.Save();
            }
        }
    }
}
