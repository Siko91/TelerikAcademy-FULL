namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystem.Data.StudentSystemDbContext context)
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                context.Students.Add(
                    new Student()
                    {
                        Name = "Student " + i * rand.Next(),
                        Number = (long)(i * DateTime.Now.Second) | (((long)(rand.Next() * rand.Next())) << 32),
                        Homeworks = new HashSet<Homework>()
                        {
                            new Homework()
                            {
                                Name = "Homework " + i*rand.Next(),
                            },
                            new Homework()
                            {
                                Name = "Homework " + i*rand.Next(),
                            }},
                        Courses = new HashSet<Course>()
                        {
                            new Course()
                            {
                                Name = "Course " + i*rand.Next(),
                                Materials = new HashSet<StudyMaterial>()
                                {
                                    new StudyMaterial()
                                    {
                                        Name= "StudyMaterial " + i*rand.Next(),
                                    },
                                    new StudyMaterial()
                                    {
                                        Name= "StudyMaterial " + i*rand.Next(),
                                    }
                                },
                            },
                            new Course()
                            {
                                Name = "Course " + i,
                                Materials = new HashSet<StudyMaterial>()
                                {
                                    new StudyMaterial()
                                    {
                                        Name= "StudyMaterial " + i*rand.Next(),
                                    },
                                    new StudyMaterial()
                                    {
                                        Name= "StudyMaterial " + i*rand.Next(),
                                    }
                                }
                            }}
                    });
            }
            context.SaveChanges();
        }
    }
}