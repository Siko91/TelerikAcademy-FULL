namespace Computers.Core.Parts.Cpu
{
    using System;
    using Interfaces;

    public class Cpu : ICpu
    {
        private static readonly Random Random = new Random();
        private byte numberOfBits;
        private byte numberOfCores;

        public Cpu(byte numberOfCores, byte numberOfBits)
        {
            this.NumberOfCores = numberOfCores;
            this.NumberOfBits = numberOfBits;
        }

        public byte NumberOfBits
        {
            get
            {
                return this.numberOfBits;
            }

            private set
            {
                if (0 > value)
                {
                    throw new ArgumentOutOfRangeException("Number of bits must be positive");
                }

                this.numberOfBits = value;
            }
        }

        public byte NumberOfCores
        {
            get
            {
                return this.numberOfCores;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Number of cores must be positive");
                }

                this.numberOfCores = value;
            }
        }

        public int GetRandomNumber(int a, int b)
        {
            return Random.Next(a, b);
        }

        public virtual string SquareNumber(int data)
        {
            if (data < 0)
            {
                return "Number too low.";
            }
            else if (data > 500)
            {
                return "Number too high.";
            }
            else
            {
                int value = (int)Math.Pow(data, 2);

                return string.Format("Square of {0} is {1}.", data, value);
            }
        }
    }
}