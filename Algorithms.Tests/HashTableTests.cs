using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class HashTableTests
    {
        private HashTable<string, string> HashTable { get; set; }

        [SetUp]
        public void SetUp()
        {
            HashTable = new HashTable<string, string>();
        }
        
        [Test]
        public void PutAndGet()
        {
            HashTable.Put("John Smith", "john.smith@gmail.com");
            HashTable.Put("Jack Bale", "jack.bale@gmail.com");
            HashTable.Put("Christian Lapboard", "c.lapboard@gmail.com");


            Assert.That(HashTable.Get("John Smith"), Is.EqualTo("john.smith@gmail.com"));
            Assert.That(HashTable.Get("Jack Bale"), Is.EqualTo("jack.bale@gmail.com"));
            Assert.That(HashTable.Get("Christian Lapboard"), Is.EqualTo("c.lapboard@gmail.com"));
        }
    }
}
