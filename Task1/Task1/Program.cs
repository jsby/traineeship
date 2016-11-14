using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        private static void Main()
        {
            int sec = 10;
            Console.WriteLine("Enter a path");
            string path = Console.ReadLine();
            Console.WriteLine("Enter an extention");
            string extention = Console.ReadLine();
            if (path != null)
            {
                string[] files = Directory.GetFiles(path);
                List<string> foundFiles = files.Where(file => Path.GetExtension(file) == extention).ToList();

                foundFiles.Sort((a, b) => File.GetCreationTime(b).CompareTo(File.GetCreationTime(a)));
                foreach (string file in foundFiles)
                {
                    TimeSpan difference = File.GetCreationTime(foundFiles[0]) - File.GetCreationTime(file);
                    if (!(difference.TotalSeconds < sec)) continue;
                    Console.WriteLine(file);
                    Console.WriteLine(File.GetCreationTime(file));
                }
            }
            Console.ReadLine();
        }
    }
}
