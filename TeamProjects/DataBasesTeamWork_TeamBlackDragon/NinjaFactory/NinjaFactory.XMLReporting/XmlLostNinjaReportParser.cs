namespace NinjaFactory.XMLReporting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using NinjaFactory.DataBase;

    /// <summary>
    /// Reads lost ninja reports and executes the commands in them
    /// </summary>
    public class XmlLostNinjaReportParser
    {
        /// <summary>
        /// Deletes the ninjas mentioned in a lost ninjas report.
        /// </summary>
        /// <param name="db"> The database. </param>
        /// <param name="filePath"> The file path. </param>
        public void DeleteNinjasMentionedInLostNinjaReport(INinjaFactoryData db, string filePath)
        {
            XDocument lostNinjaReports = XDocument.Load(filePath);

            var lostNinjas = this.GetLostNinjas(lostNinjaReports, db);

            var failedMissions = this.GetFailedMissions(lostNinjaReports, db);

            this.RemoveFromDataBase(lostNinjas, failedMissions, db);
        }

        /// <summary>
        /// Gets the failed missions.
        /// </summary>
        /// <param name="lostNinjaReports"> The lost ninja reports. </param>
        /// <param name="db"> The database. </param>
        /// <returns> Queryable collection of all failed missions </returns>
        private IQueryable<Job> GetFailedMissions(XDocument lostNinjaReports, INinjaFactoryData db)
        {
            IEnumerable<int> failedMissionsIds = new List<int>();
            failedMissionsIds =
                               from ninja in lostNinjaReports.Descendants("LostNinjaReport")
                               select int.Parse(ninja.Element("JobId").Value);

            var failedMissions = db.Jobs.All().Where(j => failedMissionsIds.Contains(j.Id));
            return failedMissions;
        }

        /// <summary>
        /// Gets the lost ninjas.
        /// </summary>
        /// <param name="lostNinjaReports"> The lost ninja reports. </param>
        /// <param name="db"> The database. </param>
        /// <returns> Queryable collection of all lost ninjas </returns>
        private IQueryable<Ninja> GetLostNinjas(XDocument lostNinjaReports, INinjaFactoryData db)
        {
            IEnumerable<int> lostNinjaIds = new List<int>();
            lostNinjaIds =
                          from ninja in lostNinjaReports.Descendants("LostNinjaReport")
                          select int.Parse(ninja.Element("NinjaId").Value);
            var lostNinjas = db.Ninjas.All().Where(n => lostNinjaIds.Contains(n.Id));
            return lostNinjas;
        }

        /// <summary>
        /// Removes the lost ninjas from the data base.
        /// </summary>
        /// <param name="lostNinjas"> The lost ninjas. </param>
        /// <param name="failedMissions"> The failed missions. </param>
        /// <param name="db"> The database. </param>
        private void RemoveFromDataBase(IQueryable<Ninja> lostNinjas, IQueryable<Job> failedMissions, INinjaFactoryData db)
        {
            foreach (Ninja nin in lostNinjas)
            {
                nin.IsDeleted = true;
            }

            foreach (Job job in failedMissions)
            {
                job.IsSuccessfull = false;
                job.EndDate = DateTime.Now;
            }

            db.SaveChanges();
        }
    }
}