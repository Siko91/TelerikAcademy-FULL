using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4Person
{
    class Person
    {
        private string name;
        private object age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age 
        {
            get { return (int)this.age; }
            set { this.age = (int)value; }
        }

        public Person(string Name)
        {
            this.Name = Name;
        }
        public Person(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        public override string ToString()
        {
            return (this.name + ((this.age != null) ? (" - " + (int)this.age + ".") : "."));
        }
    }
}
