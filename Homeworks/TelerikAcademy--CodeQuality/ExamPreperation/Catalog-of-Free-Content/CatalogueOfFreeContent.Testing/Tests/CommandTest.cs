using CatalogueOfFreeContent.Enumerations;
using CatalogueOfFreeContent.Testing.TestsData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CatalogueOfFreeContent.Testing.Tests
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void CommandConstructorTest1()
        {
            CommandTestsData data = new CommandTestsData();

            Assert.AreEqual(CommandTestsData.CommandName, data.Command.Name, "Name is not equal");
            CollectionAssert.AreEqual(CommandTestsData.FullParamsOfCommand, data.Command.Parameters, "Parameters are not Equal");
        }

        [TestMethod]
        public void CommandConstructorTest2()
        {
            CommandTestsData data = new CommandTestsData();
            Command command = data.CreateCommand(CommandTestsData.CommandName + ": " + CommandTestsData.SingleParamOfCommand);

            Assert.AreEqual(CommandTestsData.CommandName, command.Name, "Name is not equal");
            Assert.AreEqual(1, command.Parameters.Length, "Parameter length is not equal");
            Assert.AreEqual(CommandTestsData.SingleParamOfCommand, command.Parameters[0], "Parameter are not Equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CommandConstructorTest3()
        {
            CommandTestsData data = new CommandTestsData();
            Command command = data.CreateCommand(CommandTestsData.CommandName + ":   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommandConstructorTest4()
        {
            CommandTestsData data = new CommandTestsData();
            Command command = data.CreateCommand(" : " + string.Join("; ", CommandTestsData.FullParamsOfCommand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommandConstructorTest5()
        {
            CommandTestsData data = new CommandTestsData();
            Command command = data.CreateCommand(string.Empty);
        }

        [TestMethod]
        public void GetCommandNameEndIndexTests()
        {
            CommandTestsData data = new CommandTestsData();
            string testString = "Name : Params";
            int expectedIndex = testString.IndexOf(":") - 1;
            Assert.AreEqual(expectedIndex, data.Command.GetCommandNameEndIndex(testString), "Indexes do not match");
        }

        [TestMethod]
        public void ParseCommandTypeTest()
        {
            CommandTestsData data = new CommandTestsData();
            data.Command = data.CreateCommand("Add movie: title; author; size; url");
            Assert.AreEqual(
                ExistingCommandType.AddMovie,
                data.Command.ParseCommandType(),
                "CommandTypes do not match");
        }

        [TestMethod]
        public void ParseNameTest()
        {
            CommandTestsData data = new CommandTestsData();
            Assert.AreEqual(
                "Add movie",
                data.Command.ParseName("Add movie: title; author; size; url"),
                "Names do not match");
        }

        [TestMethod]
        public void ParseParametersTest()
        {
            CommandTestsData data = new CommandTestsData();
            string[] expected = { "title", "auaaaaathor", "size", "url" };
            string[] actual = data.Command.ParseParameters("someName : " + string.Join(";", expected));

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(expected[i].Equals(actual[i]), "Params do not match (expected '" + expected[i] + "' to equal '" + actual[i] + "')");
            }
        }

        [TestMethod]
        public void ToStringTest()
        {
            CommandTestsData data = new CommandTestsData();
            Assert.AreEqual(
                CommandTestsData.CommandName + " " + string.Join(" ", CommandTestsData.FullParamsOfCommand),
                data.Command.ToString(),
                "Strings do not match");
        }
    }
}