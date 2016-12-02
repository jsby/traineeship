using System.Diagnostics;
using TestStack.White;
using TestStack.White.UIItems;

namespace TestCalc.Framework.Apps
{
    public class BaseApp
    {
        protected static Application App;

        public static UIItemContainer MainWindow { get; protected set; }

        protected static void Run(string appPath)
        {
            Application.Launch(appPath);
        }

        protected static void RunWinApp(string appPath, string mainWindowName)
        {
            Application.Launch(appPath).Process.WaitForExit();
            foreach (var proc in Process.GetProcesses())
            {
                if (proc.MainWindowTitle.Equals(mainWindowName))
                {
                    App = Application.Attach(proc.ProcessName);
                }
            }
            MainWindow = App.GetWindow(mainWindowName);
        }
    }
}
