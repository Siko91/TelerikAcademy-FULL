namespace Computers.Core.Parts.HardDrive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class RaidHddSystem : IHardDrive
    {
        internal RaidHddSystem() : this(new List<Hdd>())
        {
        }

        internal RaidHddSystem(IEnumerable<Hdd> hardDrives)
        {
            this.HardDrives = hardDrives;
        }

        public IEnumerable<Hdd> HardDrives { get; set; }

        public string LoadData(int address)
        {
            if (this.HardDrives.Count() == 0)
            {
                return "No hard drive in the RAID array!";
            }

            string data;
            foreach (var hdd in this.HardDrives)
            {
                try
                {
                    data = hdd.LoadData(address);
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }

                return data;
            }

            throw new ArgumentOutOfRangeException("No such data");
        }

        public void SaveData(int address, string data)
        {
            foreach (var hdd in this.HardDrives)
            {
                hdd.SaveData(address, data);
            }
        }
    }
}