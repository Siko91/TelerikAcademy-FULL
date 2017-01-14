﻿namespace Computers.Core.Parts
{
    using Interfaces;

    public class ALaptopBattery : ILaptopBattery
    {
        public ALaptopBattery()
        {
            this.Percentage = 100 / 2;
        }

        public int Percentage { get; set; }

        public void Charge(int p)
        {
            this.Percentage += p;

            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }
            else if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}