using System;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers2D = new int[3, 2] { { 7, 9 }, { 8, 10 }, { 1, 2 } };
            Print2DArray(numbers2D);
        }
        private static void Print2DArray(int[,] numbers2D)
        {
            Console.Write("Elements in array: ");
            foreach (int i in numbers2D)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}