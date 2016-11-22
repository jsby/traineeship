using OpenQA.Selenium;
using TestCars.bin.Debug.FrameWork.Pages;
using TestCars.bin.Debug.TestCars.Elements;

namespace TestCars.bin.Debug.TestCars.Pages
{
    class CarsParentPage : BasePage
    {
        private MainMenu menu = new MainMenu(By.XPath("//div[@class='max-width-container']"), "Main Menu");

        public MainMenu GetMainMenu()
        {
            return menu;
        }
    }
}
