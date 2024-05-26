using System;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInput();
        }
        private static void GetInput()
        {
            Console.Write("Type your first name and press ENTER: ");
            string firstName = Console.ReadLine();
            Console.Write("Type the page number you are on annd press ENTER: ");
            string pg = Console.ReadLine();
            Console.WriteLine($"Hello {firstName}, your page number is {pg}.");
        }
    }
}
