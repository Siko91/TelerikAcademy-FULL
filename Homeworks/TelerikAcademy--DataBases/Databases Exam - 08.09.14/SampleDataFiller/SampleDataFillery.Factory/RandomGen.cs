using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataFillery.Factory
{
    public class RandomGen
    {
        public static RandomGen Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomGen();
                }
                return instance;
            }
        }

        public bool RandomBool()
        {
            return this.random.Next() % 2 == 1;
        }

        public bool RandomChance(double chance)
        {
            return this.random.Next(0, 101) < (chance * 100);
        }

        public DateTime RandomDate(int year = 0, int month = 0, int day = 0)
        {
            if (year == 0)
            {
                year = this.RandomNum(DateTime.Now.Year - 10, DateTime.Now.Year);
            }
            if (month == 0)
            {
                month = this.RandomNum(1, DateTime.Now.Month);
            }
            if (day == 0)
            {
                day = this.RandomNum(1, DateTime.Now.Day);
            }

            return new DateTime(year, month, day);
        }

        public DateTime RandomDateAfter(DateTime date)
        {
            int year = this.RandomNum(date.Year, date.Year + 10);
            int month = this.RandomNum(date.Month, date.Month + 12);
            int day = this.RandomNum(date.Day, date.Day + 31);

            month += day / 28;
            day %= 28;
            if (day==0)
            {
                day = 1;
            }
            year += month / 12;
            month %= 12;
            if (month==0)
            {
                month = 1;
            }

            return new DateTime(year, month, day);
        }

        public char RandomLatinLetter()
        {
            char letter = (char)('a' + this.random.Next(26));
            if (this.random.Next(4) == 1)
            {
                letter = letter.ToString().ToUpperInvariant().ToCharArray()[0];
            }
            return letter;
        }

        public int RandomNum()
        {
            return this.RandomNum(0, int.MaxValue);
        }

        public int RandomNum(int max = int.MaxValue)
        {
            return this.RandomNum(0, max);
        }

        public int RandomNum(int min = 0, int max = int.MaxValue)
        {
            return this.random.Next(min, max);
        }

        public decimal RandomPrice(int min, int max)
        {
            decimal price = this.random.Next(min, max) + ((decimal)this.random.Next(1, 101) / 100);
            return price;
        }

        public string RandomString(int minLength, int maxLength)
        {
            return this.RandomString(minLength, true) + this.RandomString(maxLength - minLength);
        }

        public string RandomString(int maxLength, bool lengthExact = false)
        {
            int len = (this.random.Next(1, int.MaxValue)) % maxLength;
            if (lengthExact)
            {
                len = maxLength;
            }
            char[] result = new char[len];
            for (int c = 0; c < len; c++)
            {
                result[c] = this.RandomLatinLetter();
            }
            return string.Join("", result);
        }

        private static RandomGen instance;

        private Random random;

        private RandomGen()
        {
            this.random = new Random();
        }
    }
}