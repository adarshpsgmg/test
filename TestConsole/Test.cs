using System;

namespace TestConsole
{
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Test");

                var a = Console.ReadLine();
                var b = Console.Read();
                var c = Console.ReadKey();
                Console.WriteLine();

                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c.Key);

                Console.Write("Press any key to close...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
