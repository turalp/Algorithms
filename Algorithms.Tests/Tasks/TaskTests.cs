using Algorithms.Tasks;
using NUnit.Framework;

namespace Algorithms.Tests.Tasks
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void HasUniqueCharacter()
        {
            Assert.That(Task.HasUniqueCharacter("abc"), Is.True);
            Assert.That(Task.HasUniqueCharacter("aa"), Is.False);
            Assert.That(Task.HasUniqueCharacter("abcdefgh"), Is.True);
        }

        [Test]
        public void IsPermutation()
        {
            Assert.That(Task.IsPermutation("abc", "cba"), Is.True);
            Assert.That(Task.IsPermutation("abc", "xyz"), Is.False);
        }

        [Test]
        public void URLify()
        {
            Assert.That(Task.URLify("My Home Page       ", 16), Is.EqualTo("My%20Home%20Page"));
        }
    }
}
