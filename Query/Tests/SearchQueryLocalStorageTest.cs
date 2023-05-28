using NUnit.Framework;
using System;

namespace Query.Tests
{
    [TestFixture]
    internal class SearchQueryLocalStorageTests
    {
        private static string testFilePath = @"..\..\..\..\Files\test_SQdb.json";
        FileStream fs = File.Create(testFilePath);
        private SearchQueryLocalStorage localStorage;

        [Setup]
        public void Setup()
        {
            localStorage = new SearchQueryLocalStorage(testFilePath);


        }

         [TearDown]
        public void TearDown()
        {
            // Delete the test file after each test
            File.Delete(testFilePath);
        }

        [Test]
        public void SaveObjectToFile_WithValidObject_SavesToFile()
        {
            // Arrange
            var searchQuery = new SearchQuery
            {
                previousSearchQueries = new List<string> { "query1", "query2" }
            };

            // Act
            localStorage.SaveObjectToFile(searchQuery);

            // Assert
            Assert.True(File.Exists(testFilePath));
        }

        [Test]
        public void LoadObjectFromFile_WithValidFile_ReturnsObject()
        {
            // Arrange
            var searchQuery = new SearchQuery
            {
                previousSearchQueries = new List<string> { "query1", "query2" }
            };
            localStorage.SaveObjectToFile(searchQuery);

            // Act
            var loadedObject = localStorage.LoadObjectFromFile();

            // Assert
            Assert.IsNotNull(loadedObject);
            Assert.IsInstanceOf<SearchQuery>(loadedObject);
            Assert.AreEqual(searchQuery.previousSearchQueries.Count, loadedObject.previousSearchQueries.Count);
            Assert.AreEqual(searchQuery.previousSearchQueries[0], loadedObject.previousSearchQueries[0]);
            Assert.AreEqual(searchQuery.previousSearchQueries[1], loadedObject.previousSearchQueries[1]);
        }

        [Test]
        public void AddQuery_WithExistingObject_AddsQueryToList()
        {
            // Arrange
            var searchQuery = new SearchQuery
            {
                previousSearchQueries = new List<string> { "query1" }
            };
            localStorage.SaveObjectToFile(searchQuery);

            // Act
            localStorage.AddQuery("query2");
            var loadedObject = localStorage.LoadObjectFromFile();

            // Assert
            Assert.IsNotNull(loadedObject);
            Assert.IsInstanceOf<SearchQuery>(loadedObject);
            Assert.AreEqual(2, loadedObject.previousSearchQueries.Count);
            Assert.AreEqual("query1", loadedObject.previousSearchQueries[0]);
            Assert.AreEqual("query2", loadedObject.previousSearchQueries[1]);
        }

        [Test]
        public void AddQuery_WithoutExistingObject_CreatesNewObjectWithQuery()
        {
            // Act
            localStorage.AddQuery("query1");
            var loadedObject = localStorage.LoadObjectFromFile();

            // Assert
            Assert.IsNotNull(loadedObject);
            Assert.IsInstanceOf<SearchQuery>(loadedObject);
            Assert.AreEqual(1, loadedObject.previousSearchQueries.Count);
            Assert.AreEqual("query1", loadedObject.previousSearchQueries[0]);
        }


    }
}