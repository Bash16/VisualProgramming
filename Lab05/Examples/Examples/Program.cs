using System;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example 1: Create single-dimensional array and print it using foreach loop
            int[] numbers = { 1, 2, 3, 4, -7, 5, 6, 9 };
            Console.WriteLine("Output of Example 1: ");
            foreach (int i in numbers)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine();

            // Example 2: Creates an array called numbers and iterates through it with the foreach statement
            int[,] numbers2D = new int[3, 2] { { 7, 9 }, { 8, 10 }, { 1, 2 } };
            Console.WriteLine("Output of Example 2: ");
            foreach(int i in numbers2D)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine();

            // Example 3: Create single-dimensional, multidimensional, and jagged arrays
            int[] array1 = new int[5];                                      // Declare single dimensional array
            int[] array2 = new int[] { 7, 8, 9 };                           // Declare and set array element values
            int[] array3 = { 4, 7, 6, 2, 1 };                               // Alternative syntax
            int[,] multiDimensionalArray1 = new int[2, 3];                  // Declare two dimensional array 
            int[,] multiDimensionalArray2 = { { 1, 3, 5 }, { 2, 6, 3 } };   // Declare and set array element values
            int[][] jaggedArray = new int[6][];                             // Declare a jagged array
            jaggedArray[0] = new int[4] { 4, 3, 2, 1 };                     // Set the values of the first array in the jagged array structure
            // Example 3 has no output

            // Example 4: Initialize an array of strings ........Thu comes at 2nd index. 
            
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            Console.WriteLine("Output of example 4: ");
            PrintArray(weekDays);

            ChangeArray(weekDays);
            Console.WriteLine("Array weekDays after the call to ChangeArray: ");
            PrintArray(weekDays);
            Console.WriteLine();

            ChangeArrayElements(weekDays);
            Console.WriteLine("Array weekDays after the call to ChangeArrayElements: ");
            PrintArray(weekDays);
            Console.WriteLine();
        }
        private static void ChangeArrayElements(string[] weekDays)
        {
            weekDays[0] = "Sat";
            weekDays[1] = "Fri";
            weekDays[2] = "Thu";

            Console.WriteLine("arr[0] is {0} in ChangeArrayElements.", weekDays[0]);
        }
        private static void ChangeArray(string[] weekDays)
        {
            weekDays = (weekDays.Reverse()).ToArray();

            Console.WriteLine("arr[0] is {0} in ChangeArray.", weekDays[0]);
        }
        public static void PrintArray(string[] weekDays)
        {
            for (int i = 0; i < weekDays.Length; i++) 
            {
                Console.Write(weekDays[i] + "{0}", i < weekDays.Length - 1 ? " " : "");
            }
            Console.WriteLine();
        }
    }
}
