using System;

namespace Q7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] A = new int[3, 3];
            int[,] B = new int[3, 3];

            Console.WriteLine("Enter values for Matrix A:");
            ReadMatrix(A);
            Console.WriteLine("\nEnter values for Matrix B:");
            ReadMatrix(B);

            int[,] R = MultiplyMatrices(A, B);

            Console.WriteLine("\nResultant Matrix R: ");
            PrintMatrix(R);
        }
        static void ReadMatrix(int[,] m)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("Enter element at row {0}, column {1}: ", i + 1, j + 1);
                    m[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        static int[,] MultiplyMatrices(int[,] A, int[,] B)
        {
            int[,] R = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    R[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        R[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return R;
        }
        static void PrintMatrix(int[,] m)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}