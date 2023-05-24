using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace DocRepresentation.Tests
{
    [TestFixture]
    public class LocalStorageTests
    {
        private string testFilePath = "test_db.json";
        private DocumentRepresentation testObject;

        [SetUp]
        public void SetUp()
        {
            Dictionary<string, string> testDict = new Dictionary<string, string>();
            testDict.Add(testFilePath, "test file content");
            // Create a test object
            testObject = new DocumentRepresentation(testDict);         
        }

        [Test]
        public void SaveObjectToFile_SerializesObjectToJSONFile()
        {
            // Arrange
            LocalStorage.SaveObjectToFile(testObject);

            // Assert
            Assert.IsTrue(File.Exists(testFilePath));
            string json = File.ReadAllText(testFilePath);
            DocumentRepresentation deserializedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<DocumentRepresentation>(json);
            Assert.AreEqual(testObject.mergedIndex.Count, deserializedObject.mergedIndex.Count);
            Assert.IsTrue(deserializedObject.mergedIndex.ContainsKey(testFilePath));
            Assert.AreEqual(testObject.FilePaths[testFilePath], deserializedObject.FilePaths[testFilePath]);
        }

        [Test]
        public void LoadObjectFromFile_DeserializesObjectFromJSONFile()
        {
            // Arrange
            // Serialize the test object and save it to a JSON file
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(testObject);
            File.WriteAllText(testFilePath, json);

            // Act
            DocumentRepresentation loadedObject = LocalStorage.LoadObjectFromFile();

            // Assert
            Assert.AreEqual(testObject.FilePaths.Count, loadedObject.FilePaths.Count);
            Assert.IsTrue(loadedObject.FilePaths.ContainsKey(testFilePath));
            Assert.AreEqual(testObject.FilePaths[testFilePath], loadedObject.FilePaths[testFilePath]);
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

