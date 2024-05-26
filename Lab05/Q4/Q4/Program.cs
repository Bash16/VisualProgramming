using System;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            // We take sample data (this is the responses of 40 students)
            int[] responses = { 1, 2, 3, 4, 5, 5, 5, 2, 1, 2, 4, 2, 5, 3, 2, 1, 4, 1, 4, 3, 5, 1, 2, 3, 4, 1, 2, 3, 4, 5, 2, 3, 1, 5, 4, 4, 3, 3, 2, 1 };
      
            int[] frequencyOfResponses = { 0, 0, 0, 0, 0 }; 

            for (int i = 0; i < responses.Length; i++) 
            {
                if (responses[i] == 1)
                    frequencyOfResponses[0]++;
                else if (responses[i] == 2)
                    frequencyOfResponses[1]++;
                else if (responses[i] == 3)
                    frequencyOfResponses[2]++;
                else if (responses[i] == 4)
                    frequencyOfResponses[3]++;
                else
                    frequencyOfResponses[4]++;  
            }

            for (int i = 0; i < frequencyOfResponses.Length; i++)
            {
                Console.WriteLine("Response {0} given by: {1} people", i + 1, frequencyOfResponses[i]);
            }

        }
    }
}