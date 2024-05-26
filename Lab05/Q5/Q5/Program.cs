using System;

namespace Q5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("What do you want to do?\n1-Convert Decimal number to Binary number\n2-Convert Binary number to Decimal number");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch(choice) 
            {
                case 1:
                    Console.Write("\nEnter a decimal number: ");
                    int dec = int.Parse(Console.ReadLine());
                    DecimalToBinary(dec);
                    break;

                case 2:
                    Console.Write("\nEnter a binary number: ");
                    int bin = int.Parse(Console.ReadLine());
                    BinaryToDecimal(bin);
                    break;

                default:
                    Console.WriteLine("\nInvalid input. Run the program again and enter a valid input!");
                    break;

            }

        }
        static void DecimalToBinary(int dec)
        {
            int[] bin = new int[32];
            int i = 0;

            while (dec > 0)
            {
                bin[i] = dec % 2;
                dec = dec / 2;
                i++;
            }

            if (i == 0)
                Console.WriteLine("Binary equivalent = 0");
            else
            {
                Console.Write("Binary equivalent = ");
                for (int j = i - 1; j >= 0; j--)
                {
                    Console.Write(bin[j]);
                }
                Console.WriteLine();
            }
        }
        static void BinaryToDecimal(int bin) 
        {
            int rem,
                bse = 1,
                dec = 0;

            while (bin > 0) 
            {
                rem = bin % 10;
                dec = dec + rem * bse;
                bse = bse * 2;
                bin = bin / 10;
            }

            Console.WriteLine("Decimal equivalent = {0}", dec);
        }
    }
}