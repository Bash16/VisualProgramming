using System;

namespace Example6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 10, 20, 30, 40 };

            Console.Write("Total elements: {0}", intList.Count);
        }
    }
}