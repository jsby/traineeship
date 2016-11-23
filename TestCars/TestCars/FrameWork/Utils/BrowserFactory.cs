using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestCars.FrameWork.Utils
{
    class BrowserFactory
    {
        protected static ILog log = Logger.GetInstance();
        internal static IWebDriver GetDriver(string name)
        {
            IWebDriver driver = null;
            switch (name)
            {
                case "Firefox":
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(ReadXML.GetData("driversPath"), "geckodriver.exe");
                    driver = new FirefoxDriver(service);
                    break;
                case "Chrome":
                    driver = new ChromeDriver(ReadXML.GetData("driversPath"));
                    break;
            }
            log.Info("Browser: " + name);
            return driver;
        }
    }
}
