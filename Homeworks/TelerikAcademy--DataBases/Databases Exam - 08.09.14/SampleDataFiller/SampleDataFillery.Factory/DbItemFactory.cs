using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataFiller.Data;

namespace SampleDataFillery.Factory
{
    public class DbItemFactory : IDbItemFactory
    {
        public DbItemFactory(RandomGen random)
        {
            this.random = random;
        }

        public Departament MakeADepartament()
        {
            return new Departament()
            {
                Name = this.random.RandomString(10, 40) + uniqueDepartamentNumber++
            };
        }

        public Employee MakeAnEmployee(List<int> departamentIds, List<int> managerIds = null)
        {
            var employee = new Employee()
            {
                FirstName = this.random.RandomString(5, 20),
                LastName = this.random.RandomString(5, 20),
                DepartmentId = departamentIds[this.random.RandomNum(departamentIds.Count())],
                YearSalary = this.random.RandomPrice(700, 2500)
            };
            if (managerIds != null)
            {
                employee.ManagerId = managerIds[this.random.RandomNum(managerIds.Count())];
            }

            return employee;
        }

        public EmployeesWorkOnProject MakeAnEmployeeProjectConnection(List<int> employeeIds, List<int> projectIds)
        {
            DateTime startDate = this.random.RandomDate();
            return new EmployeesWorkOnProject()
            {
                EmployeeId = employeeIds[this.random.RandomNum(employeeIds.Count())],
                ProjectId = projectIds[this.random.RandomNum(projectIds.Count())],
                StartDate = startDate,
                EndDate = this.random.RandomDateAfter(startDate)
            };
        }

        public Project MakeAProject()
        {
            return new Project()
            {
                Name = this.random.RandomString(30)
            };
        }

        public Report MakeAReport(List<int> employeeIds)
        {
            var rep = new Report()
            {
                EmployeeId = employeeIds[this.random.RandomNum(employeeIds.Count())],
                TimeOfReport = this.random.RandomDate()
            };
            return rep;
        }

        private RandomGen random;
        private int uniqueDepartamentNumber = 0;
    }
}