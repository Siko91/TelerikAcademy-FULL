namespace Computers.Core.Interfaces
{
    public interface IRam
    {
        int LoadValue();

        void SaveValue(int newValue);
    }
}