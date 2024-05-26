using System;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(@"C:\test\test.txt");
                sw.WriteLine("Hello");
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sw.Close();
            }
            Console.WriteLine("Done");
        }
    }
}