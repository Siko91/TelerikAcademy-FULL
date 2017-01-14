namespace Computers.Core.Computers
{
    using Interfaces;
    
    public class LapTop : IComputer
    {
        public LapTop(IMotherBoard motherboard, IHardDrive hardDrive, ILaptopBattery battery)
        {
            this.HardDrive = hardDrive;
            this.MotherBoard = motherboard;
            this.Battery = battery;
        }

        public ILaptopBattery Battery { get; set; }

        public IHardDrive HardDrive { get; set; }

        public IMotherBoard MotherBoard { get; set; }
    }
}