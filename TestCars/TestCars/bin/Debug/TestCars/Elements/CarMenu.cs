using OpenQA.Selenium;
using TestCars.bin.Debug.FrameWork.Elements;

namespace TestCars.bin.Debug.TestCars.Elements
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
