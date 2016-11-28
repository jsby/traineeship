using Ranorex;

namespace TestCalculator.Framework.Apps
{
    public class BaseApp
    {
        protected static void Run(string appPath)
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Report.Log(ReportLevel.Info, "Application", "Run application '" + appPath + "' with arguments '' in normal mode.");
            Host.Local.RunApplication(appPath, "", appPath, false);
            Delay.Milliseconds(0);
        }
    }
}
