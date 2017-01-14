namespace Computers.Core.Computers
{
    using System;
    using Interfaces;
    using Parts.VideoCard;

    public class Server : IComputer
    {
        private IMotherBoard motherBoard;

        public Server(IMotherBoard motherboard, IHardDrive hardDrive)
        {
            this.HardDrive = hardDrive;
            this.MotherBoard = motherboard;
        }

        public IHardDrive HardDrive { get; set; }

        public IMotherBoard MotherBoard
        {
            get
            {
                return this.motherBoard;
            }

            set
            {
                if (!(value.VideoCard is MonochromeVideoCard))
                {
                    throw new ArgumentException("Server can only use a monochrome video card");
                }

                this.motherBoard = value;
            }
        }
    }
}