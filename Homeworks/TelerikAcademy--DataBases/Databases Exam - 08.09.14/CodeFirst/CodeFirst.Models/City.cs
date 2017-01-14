using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class City
    {
        public City()
        {
            this.dealers = new HashSet<Dealer>();
        }

        public virtual ICollection<Dealer> Dealers
        {
            get
            {
                return this.dealers;
            }

            set
            {
                this.dealers = value;
            }
        }

        public virtual int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index("IX_Name", 1, IsUnique = true)]
        public virtual string Name { get; set; }

        private ICollection<Dealer> dealers;
    }
}