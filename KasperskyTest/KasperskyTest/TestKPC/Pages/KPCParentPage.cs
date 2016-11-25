using KasperskyTest.FrameWork;
using KasperskyTest.TestKPC.Elements;
using OpenQA.Selenium;

namespace KasperskyTest.TestKPC.Pages
{
    public class KpcParentPage : BasePage
    {
        private readonly MainMenu _mainMenu = new MainMenu(By.ClassName("//ul[@class='main-menu']"), "Main menu");

        public KpcParentPage()
        {
            Log.Info(GetPageTitle() + " is opened");
        }

        public MainMenu GetMainMenu()
        {
            return _mainMenu;
        }
    }
}
