using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    public class Group
    {
        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }

        public Group(int GroupNumber, string DepartmentName)
        {
            this.GroupNumber = GroupNumber;
            this.DepartmentName = DepartmentName;
        }

        public static readonly Group Math = new Group(2, "Mathematics");
        public static readonly Group IT = new Group(3, "IT");
        public static readonly Group Sport = new Group(5, "Sport");

        public static List<Group> Departaments = new List<Group> { Math, IT, Sport };
    }
}
