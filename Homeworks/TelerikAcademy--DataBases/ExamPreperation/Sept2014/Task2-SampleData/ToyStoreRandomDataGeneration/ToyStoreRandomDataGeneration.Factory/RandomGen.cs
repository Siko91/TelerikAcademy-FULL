using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStoreRandomDataGeneration.Factory
{
    internal class RandomGen
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