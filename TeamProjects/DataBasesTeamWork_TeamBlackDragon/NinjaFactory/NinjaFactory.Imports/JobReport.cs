namespace NinjaFactory.Imports
{
    using System;
    using MongoDB.Bson;

    public class JobReport
    {
        public DateTime EndDate { get; set; }

        public int Id { get; set; }

        public int KillCount { get; set; }

        public bool Success { get; set; }
    }
}