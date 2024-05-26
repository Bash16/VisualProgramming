using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteStatement();
        }

        private static void WriteStatement()
        {
            var FirstName = "James";
            var LastName = "Bond";
            var FullName = FirstName + " " + LastName;

            Console.WriteLine("My Name is: " +  FullName);
        }
    }
}
