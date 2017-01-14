namespace NinjaFactory.Imports
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Linq;
    using System.Linq;
    using System.Windows.Forms;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using NinjaFactory.DataBase;

    public class MongoDBImport
    {
        /*

        //================================================================================================
        //                                      HOW TO USE EXAMPLE
        //================================================================================================

        //var db = GetMongoDatabase(ConfigurationManager.ConnectionStrings["NinjaFactoryMongoDB"].ConnectionString);

        //var ninjaJobsCollection = db.GetCollection("jobs");

        ////Get all the records in the collection
        //GetAllRecordsInCollection(ninjaJobsCollection);

        ////Adding new entity to the collection
        //AddNewEntityToCollection(ninjaJobsCollection, new Job { Description = "Kill your boss", Score = 43 });

        ////Editing a entity
        //var topPersonQuery = Query<Job>.EQ(e => e.Score, 100);
        //var updateTopPerson = Update<Job>.Set(e => e.Score, 43);
        //ninjaJobsCollection.Update(topPersonQuery, updateTopPerson);

        ////Removing entity
        ////var query = Query<Entity>.EQ(e => e.Id, id);
        ////personsCollection.Remove(query);

        ////Export the collection to MSSQL
        //ExportCollectionToMSSQLServer(ninjaJobsCollection);

        //================================================================================================
        //                                      HOW TO USE EXAMPLE
        //================================================================================================
        */

        public static void InsertMongoDbReportsInDatabse(INinjaFactoryData db)
        {
            var con = ConfigurationManager.ConnectionStrings["NinjaFactoryMongoDB"];
            var conStr = con.ConnectionString;
            InsertMongoDbReportsInDatabse(conStr, db);
        }

        public static void InsertMongoDbReportsInDatabse(string connectionString, INinjaFactoryData db)
        {
            var mongoDatabase = GetMongoDatabase(connectionString, dbName);
            var mongoCollection = mongoDatabase.GetCollection(collectionName);
            var reports = GetAllRecordsInCollection(mongoCollection);
            ExportCollectionToDataBase(reports, db);

            ClearRecords(mongoCollection);
        }

        public static void SetMongoDBForTesting(INinjaFactoryData db)
        {
            var con = ConfigurationManager.ConnectionStrings["NinjaFactoryMongoDB"];
            var conStr = con.ConnectionString;
            SetMongoDBForTesting(conStr, db);
        }

        public static void SetMongoDBForTesting(string connectionString, INinjaFactoryData db)
        {
            var mongoDatabase = GetMongoDatabase(connectionString, dbName);
            var mongoCollection = mongoDatabase.GetCollection(collectionName);
            ClearRecords(mongoCollection);
            int addedCount = AddSomeRecords(mongoCollection, db);
            MessageBox.Show(string.Format("Removed all rows in the Mongo table, and added {0} [valid] rows for testing.", addedCount));
        }

        private static string collectionName = "JobReports";
        private static string dbName = "Ninja_Factory";

        private static void AddNewEntityToCollection(MongoCollection<BsonDocument> collection, JobReport newEntity)
        {
            collection.Insert(newEntity);
        }

        private static void AddReportToDb(INinjaFactoryData db, JobReport rep)
        {
            Job finishedJob = db.Jobs.Where(j => j.Id == rep.Id).FirstOrDefault();
            finishedJob.IsSuccessfull = rep.Success;
            finishedJob.EndDate = rep.EndDate;
            finishedJob.Ninja.KillCount += rep.KillCount;
            db.SaveChanges();
        }

        private static int AddSomeRecords(MongoCollection<BsonDocument> mongoCollection, INinjaFactoryData db)
        {
            IQueryable<JobReport> unfinishedJobsReports = db.Jobs
                .Where(j => j.IsSuccessfull.HasValue == false)
                .Select(j => new JobReport()
                    {
                        Id = j.Id,
                        Success = true,
                        EndDate = DateTime.Today,
                        KillCount = 2
                    });

            foreach (JobReport jobRep in unfinishedJobsReports)
            {
                AddNewEntityToCollection(mongoCollection, jobRep);
            }

            return unfinishedJobsReports.Count();
        }

        private static bool CheckIfReportIsValid(INinjaFactoryData db, JobReport rep)
        {
            var job = db.Jobs.Where(j => j.Id == rep.Id).FirstOrDefault();

            if (job == null)
            {
                throw new ArgumentOutOfRangeException("There is no job with Id '" + rep.Id + "'");
            }

            if (job.IsSuccessfull.HasValue == true)
            {
                throw new ArgumentException("The job with Id '" + rep.Id + "' is already compleated");
            }

            return true;
        }

        private static void ClearRecords(MongoCollection<BsonDocument> collection)
        {
            collection.RemoveAll();
        }

        private static void ExportCollectionToDataBase(ICollection<JobReport> reports, INinjaFactoryData db)
        {
            foreach (var rep in reports)
            {
                /*

                // testing. Delete this MessageBox.Show() once the program is confirmed to work.
                // MessageBox.Show(string.Format( "id:{0}, \n" + "Success: {1}, \n" + "KillCount:
                // {2}, \n" + "EndDate: {3}", rep.Id, rep.Success, rep.KillCount, rep.EndDate));
                */
                try
                {
                    if (CheckIfReportIsValid(db, rep))
                    {
                        AddReportToDb(db, rep);
                    }
                }
                catch (ArgumentException ae)
                {
                    MessageBox.Show(ae.Message + "\n\n" +
                        string.Format(
                        "id:{0}, \n" +
                        "Success: {1}, \n" +
                        "KillCount: {2}, \n" +
                        "EndDate: {3}",
                        rep.Id,
                        rep.Success,
                        rep.KillCount,
                        rep.EndDate));
                }
            }
        }

        private static ICollection<JobReport> GetAllRecordsInCollection(MongoCollection<BsonDocument> collection)
        {
            var jobs = collection.FindAll();
            List<JobReport> reports = new List<JobReport>();
            foreach (var job in jobs)
            {
                if (!job.Contains("_id") || !job.Contains("Success"))
                {
                    throw new ArgumentException("There is an invalid row in the Mongo Database");
                }

                int jobId = job["_id"].AsInt32;

                bool isSuccessful = job["Success"].AsBoolean;

                JobReport report = new JobReport()
                {
                    Id = jobId,
                    Success = isSuccessful
                };

                if (job.Contains("EndDate") && job["EndDate"].IsValidDateTime)
                {
                    report.EndDate = job["EndDate"].ToUniversalTime();
                }
                else
                {
                    report.EndDate = DateTime.Now;
                }

                if (job.Contains("KillCount"))
                {
                    report.KillCount = job["KillCount"].AsInt32;
                }

                reports.Add(report);
            }

            return reports;
        }

        private static MongoDatabase GetMongoDatabase(string connectionString, string ninjasDBName)
        {
            return new MongoClient(connectionString).GetServer().GetDatabase(ninjasDBName);
        }
    }
}