namespace NinjaFactory.PDFReporting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Linq;

    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using NinjaFactory.DataBase;

    public class PDFIncomeReportCreator
    {
        private const string SuccessfulJosHeader = "Successfully completed jobs for last month: \n \n";
        private const string SuccessfulJosFooter = "Completed Jobs Total Income:";

        private const string FailedJosHeader = "Failed jobs for last month: \n \n";
        private const string FailedJosFooter = "Failed jobs Total Income:";

        private const string UnfinishedJosHeader = "Jobs in Progress: \n \n";
        private const string UnfinishedJosFooter = "Jobs in Progress Expected Income:";

        private const int ReportsTimespanInMonths = -1;

        public void CreatePDFReport(INinjaFactoryData db, string filePath)
        {
            DateTime date = DateTime.Now.AddMonths(ReportsTimespanInMonths);
            try
            {
                IEnumerable<JobReport> successfullJobs = SelectJobs(db, date, true);
                IEnumerable<JobReport> failedJobs = SelectJobs(db, date, false);
                IEnumerable<JobReport> jobsInProgress = SelectUnfinishedJobs(db);

                Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 50, 50, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();
                string header = SuccessfulJosHeader;
                string footer = SuccessfulJosFooter;
                WriteToFile(successfullJobs, filePath, doc, header, footer);
                doc.NewPage();
                header = FailedJosHeader;
                footer = FailedJosFooter;
                WriteToFile(failedJobs, filePath, doc, header, footer);
                doc.NewPage();
                header = UnfinishedJosHeader;
                footer = UnfinishedJosFooter;
                WriteToFile(jobsInProgress, filePath, doc, header, footer);
                doc.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error occured!" + exc.Message);
            }

            /*
            IEnumerable<JobReport> successfullJobs;

            successfullJobs = this.SelectSuccesfullJobs(db);

            this.WriteToFile(successfullJobs, filePath);
            */
        }

        /// <summary>
        /// Gets all jobs that are still in progress (dont have end date too)
        /// </summary>
        /// <param name="db"> the database context to get the data from </param>
        /// <param name="date"> the speciafied date for reports period </param>
        /// <returns></returns>
        private static IEnumerable<JobReport> SelectUnfinishedJobs(INinjaFactoryData db)
        {
            return db.Jobs
                .Where(job => job.IsSuccessfull.Value == null)
                .Select(job => new JobReport()
                {
                    Job = job,
                    Ninja = job.Ninja,
                    Client = job.Client,
                });
        }

        /// <summary>
        /// Gets all jobs with specific outcome since a specified date
        /// </summary>
        /// <param name="db"> the database context to get the data from </param>
        /// <param name="date"> the specified date for reports period </param>
        /// <param name="state"> the state of the jobs required </param>
        /// <returns></returns>
        private static IEnumerable<JobReport> SelectJobs(INinjaFactoryData db, DateTime date, bool state)
        {
            return db.Jobs
                .Where(job => job.EndDate.Value.Month >= date.Month)
                .Where(job => job.IsSuccessfull.Value == state)
                .Select(job => new JobReport()
                {
                    Job = job,
                    Ninja = job.Ninja,
                    Client = job.Client
                });
        }

        /// <summary>
        /// Writes given reports into a pdf file
        /// </summary>
        /// <param name="selectedReport"> the report to write in the file </param>
        /// <param name="filePath"> the specified path to put the report in </param>
        /// <param name="doc"> the document instance to collect reports </param>
        /// <param name="header"> current report header </param>
        /// <param name="footer"> current report footer </param>
        private static void WriteToFile(IEnumerable<JobReport> selectedReport, string filePath, Document doc, string header, string footer)
        {
            Font verdana = FontFactory.GetFont("Verdana", 20, Font.BOLD);
            doc.Add(new Paragraph(header, verdana));

            PdfPTable table = new PdfPTable(5);
            table.AddCell("Job name");
            table.AddCell("Client");
            table.AddCell("Ninja");
            table.AddCell("End date");
            table.AddCell("Income");

            CultureInfo c = CultureInfo.InvariantCulture;

            decimal incomeSum = 0;

            foreach (var entry in selectedReport)
            {
                table.AddCell(entry.Job.Name);
                table.AddCell(entry.Client.Name);
                table.AddCell(entry.Ninja.Name);
                table.AddCell(string.Format("{0:dd-MM-yyyy}", entry.Job.EndDate));
                table.AddCell(string.Format("{0:C}", entry.Job.Price));
                incomeSum += entry.Job.Price;
            }

            PdfPCell sumCell = new PdfPCell(new Phrase(footer));
            sumCell.Colspan = 4;
            table.AddCell(sumCell);
            table.AddCell(string.Format("{0:C}", incomeSum));

            doc.Add(table);
        }
    }
}
