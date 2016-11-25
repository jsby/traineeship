using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
namespace KasperskyTest.FrameWork.Utils
{
    public class BrowserFactory
    {
        private static readonly ILog Log = Logger.GetInstance();
        private static readonly string DriversPath = XmlReader.GetData("driversPath");

        internal static IWebDriver GetDriver(string name)
        {
            IWebDriver driver = null;
            switch (name)
            {
                case "Firefox":
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(DriversPath, "geckodriver.exe");
                    driver = new FirefoxDriver(service);
                    break;
                case "Chrome":
                    driver = new ChromeDriver(DriversPath);
                    break;
            }
            Log.Info("Browser: " + name);
            return driver;
        }
    }
}
