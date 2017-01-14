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

    public class Hp : IManufacturer
    {
        public Hp()
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
                new Ram(4),
                new MultychromeVideoCard());
            return new LapTop(board, new Hdd(500), new ALaptopBattery());
        }

        private IComputer MakePc()
        {
            MotherBoard board = new MotherBoard(
                new Cpu32(2),
                new Ram(2),
                new MultychromeVideoCard());
            return new Pc(board, new Hdd(500));
        }

        private IComputer MakeServer()
        {
            MotherBoard board = new MotherBoard(
                new Cpu32(4),
                new Ram(32),
                new MonochromeVideoCard());
            RaidHddSystem hdds = new RaidHddSystem(new List<Hdd> { new Hdd(1000), new Hdd(1000) });
            return new Server(board, hdds);
        }
    }
}