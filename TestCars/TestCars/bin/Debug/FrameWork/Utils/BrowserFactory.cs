using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestCars.bin.Debug.FrameWork.Utils
{
    class BrowserFactory
    {
        internal static IWebDriver GetDriver(string name)
        {
            IWebDriver driver = null;
            switch (name)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
            }
            return driver;
        }
    }
}
