namespace Computers.Core.Tests
{
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Parts;

    [TestClass]
    public class BatteryChatgeTests
    {
        public ILaptopBattery GetBattery()
        {
            return new ALaptopBattery();
        }

        [TestMethod]
        public void InitialBatteryChargeIs50()
        {
            ILaptopBattery battery = this.GetBattery();
            Assert.AreEqual(50, battery.Percentage);
        }

        [TestMethod]
        public void NegativeChargeWorks()
        {
            ILaptopBattery battery = this.GetBattery();
            battery.Charge(-10);
            Assert.AreEqual(40, battery.Percentage);
        }

        [TestMethod]
        public void NegativeSuperChargeWorks()
        {
            ILaptopBattery battery = this.GetBattery();
            battery.Charge(-1000);
            Assert.AreEqual(0, battery.Percentage);
        }

        [TestMethod]
        public void PositiveChargeWorks()
        {
            ILaptopBattery battery = this.GetBattery();
            battery.Charge(10);
            Assert.AreEqual(60, battery.Percentage);
        }

        [TestMethod]
        public void PositiveSuperChargeWorks()
        {
            ILaptopBattery battery = this.GetBattery();
            battery.Charge(1000);
            Assert.AreEqual(100, battery.Percentage);
        }
    }
}