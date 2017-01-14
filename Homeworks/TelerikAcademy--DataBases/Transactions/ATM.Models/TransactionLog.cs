using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM.Models
{
    public class TransactionLog
    {
        public int Id { get; set; }

        public decimal Ammount { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(10)]
        [MinLength(10)]
        public string CardNumber { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}