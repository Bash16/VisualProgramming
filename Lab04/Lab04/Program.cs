using System;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExploringNumbers();
            //AssignLocalVariables();
            //RefDataType();
            //PointerDataType();
            //CastIntAndDoubles();
            //ConvertToString();
            //ParseToNumbersAndDates();
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
        }

        private static void ExploringNumbers()
        {
            Console.WriteLine($" int uses {sizeof(int)} bytes and can store numbers in the range: \n\n" + $"{int.MinValue:N0} to {int.MaxValue:N0}. \n");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($" double uses {sizeof(double)} bytes and can store numbers in the range: \n\n" + $"{double.MinValue:N0} to {double.MaxValue:N0}. \n");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($" decimal uses {sizeof(decimal)} bytes and can store numbers in the range: \n\n" + $"{decimal.MinValue:N0} to {decimal.MaxValue:N0}. \n");
                
        }

        private static void AssignLocalVariables()
        {
            int population = 66_000_000;
            double weight = 1.88;
            decimal price = 4.99M;
            string fruit = "Apples";
            char letter = 'Z';
            bool happy = true;
        }

        private static void RefDataType()
        {
            string a = " Salam";

            a += " for ";
            a = a + "All";
            Console.WriteLine(a);

            object obj;
            obj = 20;
            Console.WriteLine(obj);

            Console.WriteLine(obj.GetType());
        }

        private static void PointerDataType()
        {
            unsafe
            {
                int n = 10;
                int* p = &n;

                Console.WriteLine(" Value: {0}", n);
                Console.WriteLine(" Address: {0}", (int)p);
            }
        }

        private static void CastIntAndDoubles()
        {
            int a = 10;

            // Implicit Type Casting
            double b = a;
            Console.WriteLine(" {0}", b);

            double c = 9.8;
            // Explicit Type Casting
            int d = (int)c;
            
            long e = 10;
            int f = (int)e;
            
            Console.WriteLine($" e is {e} and f is {f}");

            e = long.MaxValue;
            f = (int)e;
            Console.WriteLine($" e is {e} and f is {f}");
        }

        private static void ConvertToString()
        {
            int number = 12;
            Console.WriteLine(number.ToString());

            bool boolean = true;
            Console.WriteLine(boolean.ToString());

            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString());

            object me = new object();
            Console.WriteLine(me.ToString());
        }

        private static void ParseToNumbersAndDates()
        {
            int age = int.Parse(" 27");
            DateTime birthday = DateTime.Parse("4 July 1980");

            Console.WriteLine($" I was born {age} years ago.");
            Console.WriteLine($" My Birthday is {birthday}.");
            Console.WriteLine($" My Birthday is {birthday:D}.");
        }
    }
}
