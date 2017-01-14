namespace Computers.Core.Interfaces
{
    public interface IHardDrive
    {
        string LoadData(int address);

        void SaveData(int address, string data);
    }
}