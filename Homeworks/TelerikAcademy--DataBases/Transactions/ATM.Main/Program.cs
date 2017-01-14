using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;

namespace ATM.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AtmDbContext();
            foreach (var acc in db.Accounts)
            {
                Console.WriteLine(acc.Id + " / " + acc.CardPIN  + " / " + acc.CardCash);
            }
        }
    }
}
