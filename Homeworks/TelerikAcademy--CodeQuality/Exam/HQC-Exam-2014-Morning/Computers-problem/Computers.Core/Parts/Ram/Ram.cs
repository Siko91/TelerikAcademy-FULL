namespace Computers.Core.Parts.Ram
{
    using System;
    using Interfaces;

    public class Ram : IRam
    {
        private int amount;

        internal Ram(int amount)
        {
            this.Amount = amount;
        }

        private int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.amount = value;
            }
        }

        private int Value { get; set; }

        public int LoadValue()
        {
            return this.Value;
        }

        public void SaveValue(int newValue)
        {
            this.Value = newValue;
        }
    }
}