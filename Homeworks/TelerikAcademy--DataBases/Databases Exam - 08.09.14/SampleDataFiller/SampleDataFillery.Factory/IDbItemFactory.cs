using System.Collections.Generic;
using SampleDataFiller.Data;

namespace SampleDataFillery.Factory
{
    public interface IDbItemFactory
    {
        Departament MakeADepartament();

        Employee MakeAnEmployee(List<int> departamentIds, List<int> managerIds = null);

        EmployeesWorkOnProject MakeAnEmployeeProjectConnection(List<int> employeeIds, List<int> projectIds);

        Project MakeAProject();

        Report MakeAReport(List<int> employeeIds);
    }
}