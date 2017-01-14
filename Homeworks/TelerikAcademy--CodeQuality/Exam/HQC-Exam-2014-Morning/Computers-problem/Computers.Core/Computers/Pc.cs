namespace Computers.Core.Computers
{
    using Interfaces;

    public class Pc : IComputer
    {
        public Pc(IMotherBoard motherboard, IHardDrive hardDrive)
        {
            this.HardDrive = hardDrive;
            this.MotherBoard = motherboard;
        }

        public IHardDrive HardDrive { get; set; }

        public IMotherBoard MotherBoard { get; set; }

        public string Play(int guess) 
        { 
            this.MotherBoard.GetRandomNumber(1, 11);
            int num = this.MotherBoard.Load();

            if (num == guess)
            {
                return "You win!";
            }
            else
            {
                return string.Format("You didn’t guess the number {0}.", num);
            }
        }
    }
}