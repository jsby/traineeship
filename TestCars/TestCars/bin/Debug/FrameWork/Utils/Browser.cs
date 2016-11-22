using OpenQA.Selenium;

namespace TestCars.bin.Debug.FrameWork.Utils
{
    class Browser
    {
        private static IWebDriver _instance = null;

        public static IWebDriver GetInstance()
        {
            return _instance ?? (_instance = BrowserFactory.GetDriver(ReadXML.GetData("browser")));
        }
    }
}
