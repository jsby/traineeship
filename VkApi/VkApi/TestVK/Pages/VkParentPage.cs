using OpenQA.Selenium;
using VkApi.FrameWork;
using VkApi.TestVK.Elements;

namespace VkApi.TestVK.Pages
{
    public class VkParentPage : BasePage
    {
        //private readonly MainMenu _mainMenu = new MainMenu(By.ClassName("//ul[@class='main-menu']"), "Main menu");

        public VkParentPage()
        {
            Log.Info(GetPageTitle() + " is opened");
        }

        /*public MainMenu GetMainMenu()
        {
            return _mainMenu;
        }*/
    }
}
