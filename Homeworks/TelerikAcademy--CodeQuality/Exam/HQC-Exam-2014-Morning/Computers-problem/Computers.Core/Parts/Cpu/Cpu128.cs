﻿namespace Computers.Core.Parts.Cpu
{
    public class Cpu128 : Cpu
    {
        public Cpu128(byte numberOfCores) : base(numberOfCores, 128)
        {
        }

        public override string SquareNumber(int data)
        {
            if (data < 0)
            {
                return "Number too low.";
            }
            else if (data > 2000)
            {
                return "Number too high.";
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                return string.Format("Square of {0} is {1}.", data, value);
            }
        }
    }
}