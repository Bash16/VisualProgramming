using System;

namespace Example12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 10, 20, 30, 40 };

            bool res = intList.TrueForAll(isPositiveInt);
            Console.WriteLine(res);
        }
        static bool isPositiveInt(int i)
        {
            return i > 0;
        }
    }
}