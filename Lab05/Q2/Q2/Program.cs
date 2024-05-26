using System;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = { "Hello ", "and ", "welcome ", "to ", "this ", "demo! " };
            string contS = Merger(s);

            Console.WriteLine("Merged String: {0}" , contS);
        }
        private static string Merger(string[] s)
        {
            string a = string.Empty;
            for(int i = 0; i < s.Length; i++)
            {
                a += s[i];
            }
            return a;
        }
    }
}