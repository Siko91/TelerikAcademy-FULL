namespace Computers.Core.Manufacrorers
{
    using System.Collections.Generic;
    using Computers;
    using Interfaces;
    using Parts;
    using Parts.Cpu;
    using Parts.HardDrive;
    using Parts.Ram;
    using Parts.VideoCard;
    
    public class Lenovo : IManufacturer
    {
        public Lenovo()
        {
            this.Pc = this.MakePc();
            this.Server = this.MakeServer();
            this.LapTop = this.MakeLaptop();
        }

        public IComputer LapTop { get; set; }

        public IComputer Pc { get; set; }

        public IComputer Server { get; set; }

        private IComputer MakeLaptop()
        {
            MotherBoard board = new MotherBoard(
                new Cpu64(2),
                new Ram(16),
                new MultychromeVideoCard());
            return new LapTop(board, new Hdd(1000), new ALaptopBattery());
        }

        private IComputer MakePc()
        {
            MotherBoard board = new MotherBoard(
                new Cpu64(2),
                new Ram(4),
                new MonochromeVideoCard());
            return new Pc(board, new Hdd(2000));
        }

        private IComputer MakeServer()
        {
            MotherBoard board = new MotherBoard(
                new Cpu128(2),
                new Ram(8),
                new MonochromeVideoCard());
            RaidHddSystem hdds = new RaidHddSystem(new List<Hdd> { new Hdd(500), new Hdd(500) });
            return new Server(board, hdds);
        }
    }
}