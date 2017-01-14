using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public decimal CardCash { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(10)]
        [MinLength(10)]
        public string CardNumber { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(4)]
        [MinLength(4)]
        public string CardPIN { get; set; }

        public void RetrieveSomeMoney(decimal money)
        {
            if (this.CardCash < money)
            {
                throw new InsufficientMoneyException("Not enough money in card");
            }
            this.CardCash -= money;
        }
    }
}