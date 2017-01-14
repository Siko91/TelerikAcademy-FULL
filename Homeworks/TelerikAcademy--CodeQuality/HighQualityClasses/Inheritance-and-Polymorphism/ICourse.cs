using System;
using System.Collections.Generic;
using System.Linq;

namespace InheritanceAndPolymorphism
{
    interface ICourse
    {
        string Name { get; set; }
        string TeacherName { get; set; }
        IList<string> Students { get; set; }
    }
}
