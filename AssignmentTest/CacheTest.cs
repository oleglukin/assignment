using System;
using Assignment;
using Xunit;

namespace AssignmentTest
{
    public class CacheTest
    {
        private int? val;
        private bool found;
        private ICache<string, int?> cache;

        public CacheTest()
        {
            int maximumNumberOfElements = 4;
            Console.WriteLine("Creating cache with maximum of {0} elements.", maximumNumberOfElements);
            this.cache = new Cache<string, int?>(maximumNumberOfElements);
        }

        [Fact]
        public void TestGettingValues()
        {
            // Try to get value that is not in the cache
            found = cache.TryGetValue("invalid key", out val);
            Assert.Null(val);
            Assert.False(found);

            // Add 4 values to the cache
            cache.AddOrUpdate("one", 1);
            cache.AddOrUpdate("two", 2);
            cache.AddOrUpdate("three", 3);
            cache.AddOrUpdate("four", 4);

            // Try to get first element from the cache, make sure it exists there
            found = cache.TryGetValue("one", out val);
            Assert.True(val == 1);
            Assert.True(found);

            // Try to get second element, it also should be there
            found = cache.TryGetValue("two", out val);
            Assert.True(val == 2);
            Assert.True(found);

            // Try to get element that doesn't exist, make sure it's not there
            found = cache.TryGetValue("five", out val);
            Assert.Null(val);
            Assert.False(found);
        }

        [Fact]
        public void TestAddOrUpdate()
        {
            // When this test run there can be some values in the cache already
            // Add or update those values
            cache.AddOrUpdate("one", 1);
            cache.AddOrUpdate("two", 2);
            cache.AddOrUpdate("three", 3);
            cache.AddOrUpdate("four", 4);

            // Add one new element (5) and update an existing element (2)
            cache.AddOrUpdate("five", 5);
            cache.AddOrUpdate("two", 22);

            // Try to get value that should not longer be there as it is the oldest one (should be evicted)
            found = cache.TryGetValue("one", out val);
            Assert.Null(val);
            Assert.False(found);

            // Try to get value that has been updated (2 => 22)
            found = cache.TryGetValue("two", out val);
            Assert.True(val == 22);
            Assert.True(found);

            // Try to get newly added value (5)
            found = cache.TryGetValue("five", out val);
            Assert.True(val == 5);
            Assert.True(found);
        }
    }
}
