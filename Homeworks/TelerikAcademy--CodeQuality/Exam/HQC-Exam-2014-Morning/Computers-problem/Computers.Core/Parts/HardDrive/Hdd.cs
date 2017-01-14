namespace Computers.Core.Parts.HardDrive
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Hdd : IHardDrive
    {
        private int capacity;

        internal Hdd(int capacity)
        {
            this.Capacity = capacity;
            this.Data = new Dictionary<int, string>(capacity);
        }

        public Dictionary<int, string> Data { get; private set; }

        private int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (0 > value)
                {
                    throw new ArgumentOutOfRangeException("HDD capacity must be positive");
                }

                this.capacity = value;
            }
        }

        public string LoadData(int address)
        {
            string result = string.Empty;
            bool success = this.Data.TryGetValue(address, out result);
            if (success)
            {
                return result;
            }
            else
            {
                throw new ArgumentOutOfRangeException("No such address in HDD");
            }
        }

        public void SaveData(int address, string data)
        {
            this.Data.Add(address, data);
        }
    }
}