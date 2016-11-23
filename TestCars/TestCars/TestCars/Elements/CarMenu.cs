using OpenQA.Selenium;
using TestCars.FrameWork.Elements;

namespace TestCars.TestCars.Elements
{
    class CarMenu : BaseElement
    {
        private string xpathItemCarMenu = "//a[contains(@class,'menu-item') and contains(@href,'{0}')]";

        public CarMenu(By locator, string description) : base(locator, description)
        {
        }

        public void GetItem(string carItemItem)
        {
            Button btnItemCarMenu = new Button(By.XPath(string.Format(xpathItemCarMenu, carItemItem.ToLower())), "Car Menu item");
            btnItemCarMenu.Click();
        }
    }
}
