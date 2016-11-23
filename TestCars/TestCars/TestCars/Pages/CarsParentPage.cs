using OpenQA.Selenium;
using TestCars.FrameWork.Pages;
using TestCars.TestCars.Elements;

namespace TestCars.TestCars.Pages
{
    class CarsParentPage : BasePage
    {
        private MainMenu menu = new MainMenu(By.XPath("//div[@class='max-width-container']"), "Main Menu");

        public CarsParentPage()
        {
            log.Info(GetPageTitle() + " is opened");
        }

        public MainMenu GetMainMenu()
        {
            return menu;
        }
    }
}
