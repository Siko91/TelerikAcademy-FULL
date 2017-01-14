namespace Computers.Core.Interfaces
{
    public interface IComputer
    {
        IHardDrive HardDrive { get; set; }

        IMotherBoard MotherBoard { get; set; }
    }
}