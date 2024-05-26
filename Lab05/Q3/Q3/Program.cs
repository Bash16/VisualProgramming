using System;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter any string(sentence): ");
            string s = Console.ReadLine();

            string[] arrayS = Extract(s);

            Console.Write("Words of length between 4 to 5 and contains vowels: " );
            for (int i = 0; i < arrayS.Length; i++)
            {
                Console.Write(arrayS[i] + "{0}", i < arrayS.Length - 1 ? ", " : "");
            }
            Console.WriteLine();
        }
        private static string[] Extract(string s)
        {
            string[] words = s.Split();
            string[] result = new string[words.Length];

            int j = 0;
            for (int i = 0; i < words.Length; i++)
            {
                int count = 0;
                int vowelCount = 0;
                
                foreach(char c in words[i])
                {
                    count++;
                    if(c == 'a' || c =='e' || c=='i' || c=='o' || c=='u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                        vowelCount++;
                }

                if (vowelCount > 0 && (count == 5 || count == 4))
                {
                    result[j] = words[i];
                    j = j + 1;
                }
            }

            string[] finalResult = new string[j];
            Array.Copy(result, finalResult, j);

            return finalResult;
        }
    }
}