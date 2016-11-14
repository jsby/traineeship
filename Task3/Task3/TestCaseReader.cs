using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task3
{
    internal class TestCaseReader
    {
        private const int DefaultLinesNum = 10;
        private static int _linesNum = DefaultLinesNum;

        public static string Read(string path)
        {
            var lines = File.ReadAllLines(path).Skip(1);
            Random rand = new Random();
            string resPath = path.Replace(".txt", "_res.txt");

            if (File.Exists(resPath))
            {
                File.Delete(resPath);
            }
            List<string> linesList = lines.ToList();
            for (int i = 0; linesList.Count != 0 & i < _linesNum; i++)
            {
                int index = rand.Next(0, linesList.Count);
                File.AppendAllText(resPath, linesList[index] + Environment.NewLine, Encoding.UTF8);
                linesList.RemoveAt(index);
            }
            File.Delete(path);
            File.AppendAllLines(path, linesList);
            return resPath;
        }
        public static string Read(string path, int newLinesNum)
        {
            _linesNum = newLinesNum;
            string resPath = Read(path);
            _linesNum = DefaultLinesNum;
            return resPath;
        }
    }
}
