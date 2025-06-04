using NUnit.Framework;

namespace LfuCache.UnitTest
{
    [TestFixture]
    public class LfuCacheTests
    {
        private LfuCache<string, string> _lfuCache;

        [SetUp]
        public void BeforeEach()
        {
            _lfuCache = new LfuCache<string, string>(3); 
        }

        [Test]
        public void AddRetrieveToLfuCache()
        {
            // Arrange
            _lfuCache.Add("1", "one");
            _lfuCache.Add("2", "two");
            _lfuCache.Add("3", "three");

            // Act
            var one = _lfuCache.Get("1");
            var two = _lfuCache.Get("2");
            var three = _lfuCache.Get("3");

            // Assert
            Assert.That(one, Is.EqualTo("one"));
            Assert.That(two, Is.EqualTo("two"));
            Assert.That(three, Is.EqualTo("three"));
        }

        [Test]
        public void AddRetrieveToLfuCacheSizeOne()
        {
            _lfuCache = new LfuCache<string, string>(1);

            // Arrange
            _lfuCache.Add("1", "one");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Add("2", "two");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Get("2");

            // Act
            var one = _lfuCache.Get("1");
            var two = _lfuCache.Get("2");

            // Assert
            Assert.That(one, Is.Null);
            Assert.That(two, Is.EqualTo("two"));
        }

        [Test]
        public void AddRetrieveToLfuCacheWithEvicts()
        {
            // Arrange
            _lfuCache.Add("1", "one");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Add("2", "two");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Add("3", "three");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Add("4", "four");

            // Act
            var one = _lfuCache.Get("1");
            var two = _lfuCache.Get("2");
            var three = _lfuCache.Get("3");
            var four = _lfuCache.Get("4");

            // Assert
            Assert.That(one, Is.EqualTo("one"));
            Assert.That(two, Is.Null);
            Assert.That(three, Is.EqualTo("three"));
            Assert.That(four, Is.EqualTo("four"));
        }

#if DEBUG
        [Test]
        public void AddRetrieveToLfuCacheWithEvictsTestingUsingEvents()
        {
            _lfuCache.EvictEvent += delegate(string value)
            {
                Assert.That(value, Is.EqualTo("two"));
            };

            _lfuCache.Add("1", "one");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Add("2", "two");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Add("3", "three");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Add("4", "four");
        }
#endif
    }
}
