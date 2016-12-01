using log4net;
using OpenQA.Selenium;
using VkApi.FrameWork.Utils;

namespace VkApi.FrameWork
{
    public abstract class BasePage
    {
        protected static IWebDriver Driver = Browser.GetInstance();
        protected static ILog Log = Logger.GetInstance();

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
