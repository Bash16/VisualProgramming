using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            SaySomething("Rey");
        }

        // Overloading
        static void SaySomething() 
        {
            Console.WriteLine("I don't even know your name. Don't order me.");
        }
        static void SaySomething(string first) 
        {
            Console.WriteLine($"Cheers, {first}");
        }
        static void SaySomething(string first, string last) 
        {
            Console.WriteLine($"Cheers, {first} {last}");
        }
    }
}
