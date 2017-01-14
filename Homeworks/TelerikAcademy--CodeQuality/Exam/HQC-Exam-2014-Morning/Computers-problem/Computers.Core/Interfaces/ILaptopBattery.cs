namespace Computers.Core.Interfaces
{
    public interface ILaptopBattery
    {
        int Percentage { get; set; }

        void Charge(int p);
    }
}