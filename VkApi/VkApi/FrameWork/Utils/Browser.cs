using OpenQA.Selenium;

namespace VkApi.FrameWork.Utils
{
    public class Browser
    {
        private static IWebDriver _instance;

        public static IWebDriver GetInstance()
        {
            return _instance ?? (_instance = BrowserFactory.GetDriver(XmlReader.GetData("browser")));
        }
    }
}
