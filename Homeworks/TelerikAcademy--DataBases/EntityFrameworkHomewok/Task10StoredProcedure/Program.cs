using System;
using System.Data.SqlClient;
using System.Linq;
using NorthwindDBContext;

namespace Task10StoredProcedure
{
    internal class Program
    {
        private static void CreateStoredProcedure()
        {
            string procedure = "" +
               "CREATE PROC usp_FindTotalIncome (@start_date int,  @end_date int, @company_name nvarchar(50))" + "\n" +
               "AS" + "\n" +
               "SELECT SUM(od.Quantity*od.UnitPrice) as TotalIncome" + "\n" +
               "FROM Suppliers s" + "\n" +
               "INNER JOIN Products p" + "\n" +
               "ON s.SupplierID = p.SupplierID" + "\n" +
               "INNER JOIN [Order Details] od" + "\n" +
               "ON od.ProductID = p.ProductID" + "\n" +
               "INNER JOIN Orders o" + "\n" +
               "ON od.OrderID = o.OrderID " + "\n" +
               "WHERE s.CompanyName = @company_name and (YEAR(o.OrderDate) >= @start_date AND YEAR(o.OrderDate) <= @end_date);";

            NorthwindEntities db = new NorthwindEntities();
            db.Database.ExecuteSqlCommand(procedure);
        }

        private static void GetTotalIncome(int startYear, int endYear, string companyName)
        {
            NorthwindEntities db = new NorthwindEntities();

            using (db)
            {
                SqlParameter startYearParam = new SqlParameter("@startYear", startYear);
                SqlParameter endYearParam = new SqlParameter("@endYear", endYear);
                SqlParameter name = new SqlParameter("@companyName", companyName);

                var income = db.Database.ExecuteSqlCommand("usp_FindTotalIncome @startYear, @endYear, @companyName", startYearParam, endYearParam, name);

                Console.WriteLine("Total income is {0}", income);
            }
        }

        private static void Main(string[] args)
        {
            try
            {
                CreateStoredProcedure();
            }
            catch (SqlException)
            {
                Console.WriteLine("The procedure might be already created. If it is - comment the code in the try block.\n");
                Console.WriteLine();
            }

            GetTotalIncome(1990, 2000, "LINO-Delicateses");
        }
    }
}