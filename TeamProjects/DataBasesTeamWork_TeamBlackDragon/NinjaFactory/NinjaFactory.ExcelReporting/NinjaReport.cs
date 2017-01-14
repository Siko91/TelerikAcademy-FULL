namespace NinjaFactory.ExcelReporting
{
    using NinjaFactory.DataBase.MySql;

    public class NinjaReport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Weapon { get; set; }

        public int SpecialtyWeight { get; set; }

        public string Speciality { get; set; }

        public int? SuccessfulJobsCount { get; set; }

        public int? KillCount { get; set; }

        public double? SuccessRate { get; set; }
    }
}
