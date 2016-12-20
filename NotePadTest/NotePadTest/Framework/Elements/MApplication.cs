using System;
using System.Linq;
using TestStack.White;

namespace NotePadTest.Framework.Elements
{
    public class MApplication
    {
        public MApplication(Application application)
        {
            if (application == null)
            {
                throw new ArgumentNullException();
            }
            Application = application;
        }

        public Application Application { get; set; }

        public static MApplication Launch(string appPath)
        {
            var application = LaunchApplication(appPath);
            return new MApplication(application);
        }

        private static Application LaunchApplication(string appPath)
        {
            Application application = Application.Launch(appPath);
            return application;
        }

        public MWindow MainWindow
        {
            get
            {
                var window = Application.GetWindows().FirstOrDefault();
                return new MWindow(window);

            }
        }

        public void Close()
        {
            Application.Close();
        }
    }
}
