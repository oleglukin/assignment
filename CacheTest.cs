using System;
using Xunit;

namespace assignment
{
    public class CacheTest
    {
        private readonly ICache<string, int?> cache;
        private readonly int maximumNumberOfElements = 4;

        public CacheTest()
        {
            cache = new Cache<string, int?>(maximumNumberOfElements);
        }

        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            cache.AddOrUpdate("one", 1);
            cache.AddOrUpdate("two", 2);
            cache.AddOrUpdate("three", 3);
            cache.AddOrUpdate("four", 4);

            int? val = 0;
            bool found = cache.TryGetValue("one", out val);
            Console.WriteLine("Found value {0}: {1}", val, found);

            found = cache.TryGetValue("two", out val);
            Console.WriteLine("Found value {0}: {1}", val, found);

            found = cache.TryGetValue("five", out val);
            Console.WriteLine("Found value {0}: {1}", val, found);


            cache.AddOrUpdate("five", 5);
            cache.AddOrUpdate("two", 22);

            found = cache.TryGetValue("one", out val);
            Console.WriteLine("Found value {0}: {1}", val, found);

            found = cache.TryGetValue("two", out val);
            Console.WriteLine("Found value {0}: {1}", val, found);

            found = cache.TryGetValue("five", out val);
            Console.WriteLine("Found value {0}: {1}", val, found);
        }
    }
}