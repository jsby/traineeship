﻿using log4net;

namespace TestCalc.Framework.Utils
{
    public class Logger
    {
        private static ILog _instance;
        public static ILog GetInstance()
        {
            return _instance ?? (_instance = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));
        }
    }
}
