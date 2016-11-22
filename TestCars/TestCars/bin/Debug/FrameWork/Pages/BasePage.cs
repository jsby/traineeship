using OpenQA.Selenium;
using TestCars.bin.Debug.FrameWork.Utils;

namespace TestCars.bin.Debug.FrameWork.Pages
{
    abstract class BasePage
    {
        static IWebDriver BROWSER = Browser.GetInstance();

        public string GetPageTitle()
        {
            return BROWSER.Title;
        }
    }
}
