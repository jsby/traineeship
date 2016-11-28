using System;
using TestCalculator.FrameWork.Utils;
using TestCalculator.TestCalc.Apps;

namespace TestCalculator.TestCalc.Test
{
    public class TestCalc
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Calculator calc = new Calculator(XmlReader.GetData("appPath"));
            calc.Form.AddNumbers(XmlReader.GetData("num1"), XmlReader.GetData("num2"));
            calc.Form.SaveMemory();
            calc.Form.AddWithMemory(XmlReader.GetData("num3"));
        }
    }
}
