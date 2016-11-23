using KasperskyTest.TestKPC.Elements;
using OpenQA.Selenium;
using TestCars.FrameWork.Pages;

namespace KasperskyTest.TestKPC.Pages
{
    class KpcParentPage : BasePage
    {
        private MainMenu mainMenu = new MainMenu(By.ClassName("//ul[@class='main-menu']"), "Main menu");

        public KpcParentPage()
        {
            log.Info(GetPageTitle() + " is opened");
        }

        public MainMenu GetMainMenu()
        {
            return mainMenu;
        }
    }
}
