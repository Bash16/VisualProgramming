using System;

namespace Example9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 10, 20, 30, 40 };

            intList.Insert(1, 11);

            foreach(var el in intList)
                Console.WriteLine(el);
        }
    }
}