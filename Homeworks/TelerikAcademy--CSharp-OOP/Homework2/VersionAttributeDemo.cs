using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2
{
    [VersionAttribute(1, 1001)]
    class VersionAttributeDemo
    {
        public static string TestVersionAttribute()
        {
            Type type = typeof(VersionAttributeDemo);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in attributes)
            {
                return ("The version is " + attr.Major + "." + attr.Minor);
            }
            return "no version was found";
        }
    }
}
