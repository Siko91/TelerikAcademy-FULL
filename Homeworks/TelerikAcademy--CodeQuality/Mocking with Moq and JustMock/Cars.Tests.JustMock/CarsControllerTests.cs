namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void SearchTest1()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search("some string"));

            Assert.AreEqual(2, model.Count);

            var car = model.First();

            Assert.AreEqual("BMW", car.Make);
        }

        [TestMethod]
        public void SortByMakeTest()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));

            var car = model.First();

            Assert.AreEqual(1, car.Id);
            Assert.AreEqual("Audi", car.Make);
            Assert.AreEqual("A4", car.Model);
            Assert.AreEqual(2005, car.Year);
        }

        [TestMethod]
        public void SortByYearTest()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));

            var car = model.First();
            
            Assert.AreEqual(4, car.Id);
            Assert.AreEqual("Opel", car.Make);
            Assert.AreEqual("Astra", car.Model);
            Assert.AreEqual(2010, car.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortByUnknownTestShouldThorwException()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("SOME RANDOM STRING"));
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
