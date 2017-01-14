namespace Computers.Core.Interfaces
{
    public interface IManufacturer
    {
        IComputer LapTop { get; set; }

        IComputer Pc { get; set; }

        IComputer Server { get; set; }
    }
}