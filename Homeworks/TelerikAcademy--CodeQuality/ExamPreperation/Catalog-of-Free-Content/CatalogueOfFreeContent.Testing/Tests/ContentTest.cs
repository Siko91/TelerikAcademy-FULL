using CatalogueOfFreeContent.Enumerations;
using CatalogueOfFreeContent.Testing.TestsData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CatalogueOfFreeContent.Testing.Tests
{
    [TestClass]
    public class ContentTest
    {
        [TestMethod]
        public void CompareToTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void ContentConstructorTest1()
        {
            Content data = new ContentTestsData().CreateContent();

            Assert.AreEqual(data.Title, data.Title);
            Assert.AreEqual(data.Author, data.Author);
            Assert.AreEqual(data.Size, data.Size);
            Assert.AreEqual(data.Url, data.Url);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContentConstructorTest2()
        {
            ContentTestsData dataMaker = new ContentTestsData();
            string[] parameters = dataMaker.Parameters;
            parameters[(int)ConsoleInputParsingIndexes.Title] = string.Empty;
            Content data = dataMaker.CreateContent(parameters);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContentConstructorTest3()
        {
            ContentTestsData dataMaker = new ContentTestsData();
            string[] parameters = dataMaker.Parameters;
            parameters[(int)ConsoleInputParsingIndexes.Author] = string.Empty;
            Content data = dataMaker.CreateContent(parameters);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContentConstructorTest4()
        {
            ContentTestsData dataMaker = new ContentTestsData();
            string[] parameters = dataMaker.Parameters;
            parameters[(int)ConsoleInputParsingIndexes.Size] = string.Empty;
            Content data = dataMaker.CreateContent(parameters);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContentConstructorTest5()
        {
            ContentTestsData dataMaker = new ContentTestsData();
            string[] parameters = dataMaker.Parameters;
            parameters[(int)ConsoleInputParsingIndexes.Url] = string.Empty;
            Content data = dataMaker.CreateContent(parameters);
        }

        [TestMethod]
        public void TextRepresentationTest()
        {
            ContentTestsData dataMaker = new ContentTestsData();
            Content data = dataMaker.CreateContent("Add book: title; author; 5; url");
            string expected = "Book: title; author; 5; url";
            Assert.AreEqual(expected, data.TextRepresentation);
        }
    }
}