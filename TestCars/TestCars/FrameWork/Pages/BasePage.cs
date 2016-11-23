using log4net;
using OpenQA.Selenium;
using TestCars.FrameWork.Utils;

namespace TestCars.FrameWork.Pages
{
    abstract class BasePage
    {
        protected static IWebDriver driver = Browser.GetInstance();
        protected static ILog log = Logger.GetInstance();

        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
