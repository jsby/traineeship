using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        private static void Main()
        {
            string[] names = { "Alex", "Dima", "Kate", "Galina", "Ivan" };
            string[] otherNames = { "Dima", "Ivan", "Kate" };
            string[] namesRes = new string[0];
            foreach (string name in names)
            {
                int k = otherNames.Count(otherName => otherName == name);
                if (k != 0) continue;
                Array.Resize(ref namesRes, namesRes.Length + 1);
                namesRes[namesRes.Length - 1] = name;
            }
            Console.WriteLine("===Array===");
            foreach (string name in namesRes)
            {
                Console.WriteLine(name);
            }

            List<string> listNames = new List<string> { "Alex", "Dima", "Kate", "Galina", "Ivan" };
            List<string> otherListNames = new List<string> { "Dima", "Ivan", "Kate" };
            foreach (string otherName in otherListNames)
            {
                if (listNames.Contains(otherName))
                {
                    listNames.Remove(otherName);
                }
            }
            Console.WriteLine("===List===");
            foreach (string name in listNames)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }
    }
}
