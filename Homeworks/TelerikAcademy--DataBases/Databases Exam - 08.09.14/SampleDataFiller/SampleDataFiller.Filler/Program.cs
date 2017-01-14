using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataFiller.Data;
using SampleDataFillery.Factory;

namespace SampleDataFiller.Filler
{
    internal class Program
    {
        private static void Add100Departaments(EmployeeProjectSystemEntities1 db, IDbItemFactory factory, ILogger logger)
        {
            for (int i = 0; i < 100; i++)
            {
                db.Departaments.Add(factory.MakeADepartament());
            }
            db.SaveChanges();
            logger.Log("100 departaments added");
        }

        private static void Add200Employees(EmployeeProjectSystemEntities1 db, IDbItemFactory factory, ILogger logger, List<int> departamentIds, List<int> managerIds = null)
        {
            for (int i = 0; i < 200; i++)
            {
                db.Employees.Add(factory.MakeAnEmployee(departamentIds, managerIds));
            }
            db.SaveChanges();
            logger.Log("200 employees" + (managerIds != null ? " with managers" : "") + " added");
        }

        private static void Add200ProjectsAndEmployeeProjectConnections(EmployeeProjectSystemEntities1 db, IDbItemFactory factory, ILogger logger, List<int> employeeIds)
        {
            List<Project> projects = new List<Project>();
            for (int i = 0; i < 200; i++)
            {
                var proj = factory.MakeAProject();
                db.Projects.Add(proj);
                projects.Add(proj);
            }
            db.SaveChanges();
            logger.Log("200 projects added");

            int caunter = 0;
            int totalProjectWorkers = 0;
            foreach (var proj in projects)
            {
                caunter++;
                int len = GetRandomWorkersCount();
                totalProjectWorkers += len;
                for (int i = 0; i < len; i++)
                {
                    //var workerToProject = factory.MakeAnEmployeeProjectConnection(employeeIds, new List<int>() { proj.Id });
                    //db.EmployeesWorkOnProjects.Add(workerToProject);
                }
                if (caunter % 40 == 0)
                {
                    db.SaveChanges();
                }
            }

            db.SaveChanges();
            logger.Log(totalProjectWorkers + " workers added for those projects");
        }

        private static void Add250Reports(EmployeeProjectSystemEntities1 db, IDbItemFactory factory, ILogger logger, List<int> employeeIds)
        {
            for (int i = 0; i < 250; i++)
            {
                var rep = factory.MakeAReport(employeeIds);
                db.Reports.Add(rep);
            }
            db.SaveChanges();
            logger.Log("250 reports added");
        }

        private static int GetRandomWorkersCount()
        {
            var rand = RandomGen.Instance;
            if (rand.RandomChance(0.5))
            {
                return rand.RandomNum(3, 7);
            }
            else
            {
                return rand.RandomNum(2, 20);
            }
        }

        private static void Main(string[] args)
        {
            EmployeeProjectSystemEntities1 db = new EmployeeProjectSystemEntities1();
            IDbItemFactory factory = new DbItemFactory(RandomGen.Instance);
            ILogger logger = new ConsoleLogger();

            //•	100 departments
            Add100Departaments(db, factory, logger);

            //•	5 000 employees – each employee has department, 95% of them have managers and their salary is between $50 000 and $200 000, inclusive. There must be no cycles in the management tree –example for a cycle is Pesho’s manager is Gosho, Gosho’s manager is Ivan and Ivan’s manager is Pesho.
            List<int> departamentIds = db.Departaments.Select(d => d.Id).ToList();

            //for (int i = 0; i < 2; i++)
            {
                db = new EmployeeProjectSystemEntities1();
                Add200Employees(db, factory, logger, departamentIds);
            }
            List<int> managerIds = db.Employees.Select(d => d.Id).ToList();

            //for (int i = 0; i < 23; i++)
            {
                db = new EmployeeProjectSystemEntities1();
                Add200Employees(db, factory, logger, departamentIds, managerIds);
            }

            //•	1 000 projects– on each project there are working between 2 and 20 employees, inclusive – average of 5. Ending date is always after starting date (you don’t say) and ending date may be in the future.
            List<int> employeeIds = db.Employees.Select(d => d.Id).ToList();

            //for (int i = 0; i < 5; i++)
            {
                db = new EmployeeProjectSystemEntities1();
                Add200ProjectsAndEmployeeProjectConnections(db, factory, logger, employeeIds);
            }

            //•	250 000 reports –add average of 50 reportsper employee.
            //for (int i = 0; i < 1000; i++)
            {
                db = new EmployeeProjectSystemEntities1();
                Add250Reports(db, factory, logger, employeeIds);
            }

            logger.Log("Compleated");
        }
    }
}