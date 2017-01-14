using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task5HashedSet;

namespace Task6UsageOfHashedSet
{
    public class PhoneBook
    {
        public PhoneBook()
            : this(new HashedSet<Human>())
        {
        }

        public PhoneBook(HashedSet<Human> records)
        {
            this.Records = records;
        }

        public HashedSet<Human> Records { get; set; }

        public ICollection<Human> FindByName(string name)
        {
            var filtered = new HashedSet<Human>();
            foreach (var human in this.Records)
            {
                if (human.Name.Equals(name))
                {
                    filtered.Add(human);
                }
            }
            return filtered;
        }

        public ICollection<Human> FindByNameAndTown(string name, string town)
        {
            var filteredByName = this.FindByName(name);
            var filtered = new HashedSet<Human>();
            foreach (var human in filteredByName)
            {
                if (human.Town.Equals(town))
                {
                    filtered.Add(human);
                }
            }
            return filtered;
        }
    }
}