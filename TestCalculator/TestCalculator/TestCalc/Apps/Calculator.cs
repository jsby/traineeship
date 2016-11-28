using TestCalculator.Framework.Apps;
using TestCalculator.TestCalc.Forms;

namespace TestCalculator.TestCalc.Apps
{
    public class Calculator : BaseApp
    {
        public Calculator(string appPath)
        {
            Run(appPath);
            Form = new MainForm();
        }

        public MainForm Form { get; }
    }
}
