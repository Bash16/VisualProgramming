using System;

namespace Example11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 10, 20, 30, 40 };

            bool res = intList.TrueForAll(el => el % 2 == 0);
            Console.WriteLine(res);
        }
    }
}