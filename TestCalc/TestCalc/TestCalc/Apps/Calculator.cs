using TestCalc.Framework.Apps;
using TestCalc.TestCalc.Forms;

namespace TestCalc.TestCalc.Apps
{
    public class Calculator : BaseApp
    {
        public Calculator(string appPath)
        {
            Run(appPath);
            Window = new MainCalcWindow();
        }

        public Calculator(string appPath, string mainWindowName)
        {
            RunWinApp(appPath, mainWindowName);
            Window = new MainCalcWindow();
        }

        public MainCalcWindow Window { get; set; }
    }
}
