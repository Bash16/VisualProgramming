using System;

namespace Q6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] courseMarks = new int[5, 10];
            int[] avg = new int[10];

            for (int i = 0; i < courseMarks.GetLength(1); i++)  
            {
                int sum = 0;
                Console.WriteLine("Enter marks of Student {0}: ", i + 1);
                for (int j = 0; j < courseMarks.GetLength(0); j++) 
                {
                    Console.Write("For Test {0}: ", j + 1);
                    courseMarks[j, i] = int.Parse(Console.ReadLine());
                    sum += courseMarks[j, i];
                }
                avg[i] = sum/courseMarks.GetLength(0);
                Console.WriteLine();
            }

            Console.Write("Student\t\t");
            for (int i = 0; i < courseMarks.GetLength(1); i++)
                Console.Write("{0}\t", i + 1);
            Console.WriteLine();

            Console.WriteLine("\t   -------------------------------------------------------------------------------------");

            for (int i = 0; i < courseMarks.GetLength(0); i++)
            {
                Console.Write("Test {0}:\t\t", i + 1);
                for (int j = 0; j < courseMarks.GetLength(1); j++)
                    Console.Write("{0}\t", courseMarks[i, j]);
                Console.WriteLine();
            }

            Console.WriteLine("\t   -------------------------------------------------------------------------------------");

            Console.Write(" Avg.  \t\t");
            for (int i = 0; i < courseMarks.GetLength(1); i++)
                Console.Write("{0}\t", avg[i]);
            Console.WriteLine();
        }
    }
}