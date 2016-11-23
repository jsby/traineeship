using log4net;

namespace TestCars.FrameWork.Utils
{
    class Logger
    {
        private static ILog _instance = null;
        public static ILog GetInstance()
        {
            return _instance ?? (_instance = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));
        }
    }
}
