namespace NinjaFactory.XMLReporting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using NinjaFactory.DataBase;

    /// <summary>
    /// Creates lost ninja reports as XML files
    /// </summary>
    public class XmlLostNinjaReportCreator
    {
        /// <summary>
        /// Creates the lost ninjas report.
        /// </summary>
        /// <param name="db"> The database. </param>
        /// <param name="filePath"> The file path. </param>
        public void CreateLostNinjasReport(INinjaFactoryData db, string filePath)
        {
            DateTime startedBefore = DateTime.Now.AddMonths(-2);

            IEnumerable<LostNinjaReport> oldUnfinishedJobs;

            oldUnfinishedJobs = this.SelectOldUnfinishedJobs(db, startedBefore);
            this.WriteToFile(oldUnfinishedJobs, filePath);
        }

        /// <summary>
        /// Selects the old unfinished jobs.
        /// </summary>
        /// <param name="db"> The database. </param>
        /// <param name="startedBefore"> The started before. </param>
        /// <returns> IEnumerable collection of all unfinished jobs started before specified date </returns>
        private IEnumerable<LostNinjaReport> SelectOldUnfinishedJobs(INinjaFactoryData db, DateTime startedBefore)
        {
            return db.Jobs.All()
                .Where(job => job.IsSuccessfull.HasValue == false)
                .Where(job => job.Ninja.IsDeleted == false)
                .Where(job => job.StartDate < startedBefore)
                .Select(job => new LostNinjaReport()
                       {
                           Job = job,
                           Ninja = job.Ninja,
                           Client = job.Client
                       });
        }

        /// <summary>
        /// Writes the report to an XML file.
        /// </summary>
        /// <param name="oldUnfinishedJobs"> The old unfinished jobs. </param>
        /// <param name="filePath"> The file path. </param>
        private void WriteToFile(IEnumerable<LostNinjaReport> oldUnfinishedJobs, string filePath)
        {
            XElement ninjaXml = new XElement("lostNinjaReportsContainer");

            foreach (var report in oldUnfinishedJobs)
            {
                ninjaXml.Add(
                    new XElement(
                        "LostNinjaReport",
                        new XElement("JobId", report.Job.Id),
                        new XElement("Client", report.Client.Name),
                        new XElement("Task", report.Job.Name),
                        new XElement("Price", report.Job.Price),
                        new XElement("NinjaId", report.Ninja.Id),
                        new XElement("NinjaName", report.Ninja.Name),
                        new XElement("NinjaKillingExperiance", report.Ninja.KillCount),
                        new XElement("NinjaMinimalPayment", report.Ninja.MinimalPersonalPrice)));
            }

            ninjaXml.Save(filePath);
        }
    }
}