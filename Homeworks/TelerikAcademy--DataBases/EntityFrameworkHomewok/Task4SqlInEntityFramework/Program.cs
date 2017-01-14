using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDBContext;

namespace Task4SqlInEntityFramework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string command = "SELECT" +
            "[Project1].[CustomerID] AS [CustomerID], " +
            "[Project1].[CompanyName] AS [CompanyName], " +
            "[Project1].[ContactName] AS [ContactName], " +
            "[Project1].[ContactTitle] AS [ContactTitle], " +
            "[Project1].[Address] AS [Address], " +
            "[Project1].[City] AS [City], " +
            "[Project1].[Region] AS [Region], " +
            "[Project1].[PostalCode] AS [PostalCode], " +
            "[Project1].[Country] AS [Country], " +
            "[Project1].[Phone] AS [Phone], " +
            "[Project1].[Fax] AS [Fax]" +
            "FROM ( SELECT " +
            "   [Extent1].[CustomerID] AS [CustomerID], " +
            "   [Extent1].[CompanyName] AS [CompanyName], " +
            "   [Extent1].[ContactName] AS [ContactName], " +
            "   [Extent1].[ContactTitle] AS [ContactTitle], " +
            "   [Extent1].[Address] AS [Address], " +
            "   [Extent1].[City] AS [City], " +
            "   [Extent1].[Region] AS [Region], " +
            "   [Extent1].[PostalCode] AS [PostalCode], " +
            "   [Extent1].[Country] AS [Country], " +
            "   [Extent1].[Phone] AS [Phone]," +
            "   [Extent1].[Fax] AS [Fax], " +
            "   (SELECT " +
            "       COUNT(1) AS [A1]" +
            "       FROM [dbo].[Orders] AS [Extent2]" +
            "       WHERE ([Extent1].[CustomerID] = [Extent2].[CustomerID]) AND (1997 = (DATEPART (year, [Extent2].[OrderDate]))) AND (N'Canada' = [Extent2].[ShipCountry])) AS [C1]" +
            "    FROM [dbo].[Customers] AS [Extent1]" +
            ")  AS [Project1]" +
            "WHERE [Project1].[C1] > 0";

            NorthwindEntities db = new NorthwindEntities();

            var result = db.Customers.SqlQuery(command).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.City + ", " + item.ContactName);
            }
        }
    }
}