using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace DocRepresentation.Tests
{
    [TestFixture]
    public class LocalStorageTests
    {
        private string testFilePath = @"..\..\..\..\Files\test_db.json";
        private DocumentRepresentation testObject;
        private string filepath = "file1.txt";
        private string fileContent = "test file content";

        [SetUp]
        public void SetUp()
        {
            Dictionary<string, string> testDict = new Dictionary<string, string>();
            testDict.Add(filepath, fileContent);
            // Create a test object
            testObject = new DocumentRepresentation(testDict);         
        }

        [Test]
        public void SaveObjectToFile_SerializesObjectToJSONFile()
        {
            // Arrange
            new DocRepLocalStorage(testFilePath).SaveObjectToFile(testObject);

            // Assert
            Assert.IsTrue(File.Exists(testFilePath));
            string json = File.ReadAllText(testFilePath);
            DocumentRepresentation deserializedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<DocumentRepresentation>(json);
            Assert.AreEqual(testObject.mergedIndex.Count, deserializedObject.mergedIndex.Count);
            Assert.IsTrue(deserializedObject.mergedIndex.ContainsKey(testFilePath));
            Assert.AreEqual(testObject.FilePaths.Contains(filepath), deserializedObject.FilePaths.Contains(filepath));
        }

        [Test]
        public void LoadObjectFromFile_DeserializesObjectFromJSONFile()
        {
            // Arrange
            // Serialize the test object and save it to a JSON file
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(testObject);
            File.WriteAllText(testFilePath, json);

            // Act
            DocumentRepresentation loadedObject = new DocRepLocalStorage(testFilePath).LoadObjectFromFile();

            // Assert
            Assert.AreEqual(testObject.FilePaths.Count, loadedObject.FilePaths.Count);
            Assert.IsTrue(loadedObject.FilePaths.Contains(filepath));
            Assert.AreEqual(testObject.FilePaths.Contains(filepath), loadedObject.FilePaths.Contains(filepath));
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the test file
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
    }
}

