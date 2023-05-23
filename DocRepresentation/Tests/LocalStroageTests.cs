using NUnit.Framework;
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
            // Create a test object
            testObject = new DocumentRepresentation()
            {
                Id = 1,
                Title = "Test Document",
                Content = "This is a test document."
            };
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
            Assert.AreEqual(testObject.Id, deserializedObject.Id);
            Assert.AreEqual(testObject.Title, deserializedObject.Title);
            Assert.AreEqual(testObject.Content, deserializedObject.Content);
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
            Assert.AreEqual(testObject.Id, loadedObject.Id);
            Assert.AreEqual(testObject.Title, loadedObject.Title);
            Assert.AreEqual(testObject.Content, loadedObject.Content);
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
