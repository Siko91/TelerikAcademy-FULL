using System;
using System.Data.Entity;
using System.Linq;
using StudentSystem.Data.Migrations;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base(Settings.Default.MSSQLConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudyMaterial> StudyMaterials { get; set; }

        public DbSet<T> Get<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}