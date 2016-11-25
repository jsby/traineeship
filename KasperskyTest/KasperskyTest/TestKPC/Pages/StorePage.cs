using KasperskyTest.TestKPC.Elements;
using OpenQA.Selenium;

namespace KasperskyTest.TestKPC.Pages
{
    public class StorePage : KpcParentPage
    {
        private readonly StoreMenu _storeMenu = new StoreMenu(By.ClassName("//ul[@class='main-menu']"), "Main menu");

        public StoreMenu GetStoreMenu()
        {
            return _storeMenu;
        }
    }
}
