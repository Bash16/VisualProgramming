using System;

namespace Example7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 10, 20, 30, 40 };

            for (int i = 0; i < intList.Count; i++)
                Console.WriteLine(intList[i]);
        }
    }
}