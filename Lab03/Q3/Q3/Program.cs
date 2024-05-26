using System;
using Person;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Female female = new Female();
            female.Name = "Cindy";
            Console.WriteLine($"Her name is {female.Name}");
        }
    }
}

namespace Person
{
    public class Female
    {
        public string Name { get; set; }
    }
}
