using System;

namespace assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int maximumNumberOfElements = 4;
            Console.WriteLine("Creating cache with maximum of {0} elements.", maximumNumberOfElements);
            ICache<string, int> cache = new Cache<string, int>(maximumNumberOfElements);


            Console.WriteLine("Press Enter...");
            Console.ReadLine();
        }
    }
}
