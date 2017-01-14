namespace Computers.Core.Tests
{
    using System;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Parts.Cpu;

    [TestClass]
    public class CpuGetRandomNumberTests
    {
        public ICpu GetCpu()
        {
            return new Cpu64(4);
        }

        [TestMethod]
        public void RandomNumberShoulBeInRange()
        {
            var cpu = this.GetCpu();
            int number = cpu.GetRandomNumber(1, 1000);

            Assert.IsTrue(1 <= number);
            Assert.IsTrue(1000 >= number);
        }

        [TestMethod]
        public void RandomNumberShouldBeInRange2()
        {
            var cpu = this.GetCpu();
            int number = cpu.GetRandomNumber(1, 2);

            Assert.IsTrue(1 <= number);
            Assert.IsTrue(2 >= number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RandomNumberShouldThrowErrorIfInvalidRangeIsGiven()
        {
            var cpu = this.GetCpu();
            int number = cpu.GetRandomNumber(100, 2);
        }
    }
}