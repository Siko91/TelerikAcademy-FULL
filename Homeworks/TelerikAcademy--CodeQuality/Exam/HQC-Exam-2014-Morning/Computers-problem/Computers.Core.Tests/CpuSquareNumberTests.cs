namespace Computers.Core.Tests
{
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Parts.Cpu;

    [TestClass]
    public class CpuSquareNumberTests
    {
        public ICpu GetCpu()
        {
            return new Cpu64(4);
        }

        [TestMethod]
        public void SquaringABigNumberShouldReturnMessage()
        {
            ICpu cpu = this.GetCpu();
            string result = cpu.SquareNumber(99999);
            string expected = "Number too high.";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SquaringANegativeShouldReturnMessage()
        {
            ICpu cpu = this.GetCpu();
            string result = cpu.SquareNumber(-5);
            string expected = "Number too low.";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SquaringShouldBeCurrect()
        {
            ICpu cpu = this.GetCpu();
            string result = cpu.SquareNumber(5);
            string expected = string.Format("Square of {0} is {1}.", 5, 5 * 5);

            Assert.AreEqual(expected, result);
        }
    }
}