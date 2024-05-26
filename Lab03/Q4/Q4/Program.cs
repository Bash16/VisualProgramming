using System;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayOutput();
        }
        private static void DisplayOutput()
        {
            var population = 66_000_000;
            var weight = 1.88;
            var price = 4.99M;
            var fruit = "Apples";

            Console.WriteLine($"The UK population is {population}.");
            Console.Write($"The UK population is {population:N0}. ");
            Console.WriteLine($"{weight}kg of {fruit} costs {price:C}.");
        }
    }
}
