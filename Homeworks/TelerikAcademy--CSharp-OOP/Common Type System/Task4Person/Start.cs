using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4Person
{
    class Start
    {
        static void Main()
        {
            Person prsn = new Person("Person 1", 22);
            Person prsn2 = new Person("Person 2");
            Console.WriteLine(prsn.ToString());
            Console.WriteLine(prsn2.ToString());
            
        }
    }
}
