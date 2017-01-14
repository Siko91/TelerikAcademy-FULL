using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Car
    {
        public virtual Dealer Dealer { get; set; }

        [Required]
        public virtual int DealerId { get; set; }

        public virtual int Id { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public virtual int ManufacturerId { get; set; }

        [Required]
        [MaxLength(20)]
        public virtual string Model { get; set; }

        [Required]
        public virtual decimal Price { get; set; }

        [Required]
        public virtual TransmissionType TransmissionType { get; set; }

        [Required]
        public virtual int Year { get; set; }
    }
}