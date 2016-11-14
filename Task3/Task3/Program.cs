
using System;

namespace Task3
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Enter a path");
            string path = Console.ReadLine();
            Console.WriteLine("Enter a number of lines");
            int linesNum = Convert.ToInt32(Console.ReadLine());
            string resPath = TestCaseReader.Read(path, linesNum);
            Console.WriteLine(resPath);
        }
    }
}
