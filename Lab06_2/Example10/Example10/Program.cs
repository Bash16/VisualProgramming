using System;

namespace Example10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 10, 20, 30, 40 };

            intList.Remove(10);
            intList.RemoveAt(2);

            foreach (var el in intList)
                Console.WriteLine(el);
        }
    }
}