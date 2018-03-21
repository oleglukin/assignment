using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int maximumNumberOfElements = 4;
            Console.WriteLine("Creating cache with maximum of {0} elements.", maximumNumberOfElements);
            ICache<string, int?> cache = new Cache<string, int?>(maximumNumberOfElements);

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
            

            Console.WriteLine("Press Enter...");
            Console.ReadLine();
        }
    }
}
