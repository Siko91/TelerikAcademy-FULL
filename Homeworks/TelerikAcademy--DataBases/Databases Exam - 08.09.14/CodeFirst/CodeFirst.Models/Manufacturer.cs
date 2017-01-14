using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.cars = new HashSet<Car>();
        }

        public virtual ICollection<Car> Cars
        {
            get
            {
                return this.cars;
            }

            set
            {
                this.cars = value;
            }
        }

        public virtual int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index("IX_Name", 1, IsUnique = true)]
        public virtual string Name { get; set; }

        private ICollection<Car> cars;
    }
}