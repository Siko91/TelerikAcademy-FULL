namespace Computers.Core.Parts.Cpu
{
    public class Cpu32 : Cpu
    {
        public Cpu32(byte numberOfCores) : base(numberOfCores, 32)
        {
        }

        public override string SquareNumber(int data)
        {
            if (data < 0)
            {
                return "Number too low.";
            }
            else if (data > 500)
            {
                return "Number too high.";
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                return string.Format("Square of {0} is {1}.", data, value);
            }
        }
    }
}