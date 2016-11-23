using System;
using OpenQA.Selenium;
using TestCars.FrameWork.Elements;

namespace TestCars.TestCars.Elements
{
    class MainMenu : BaseElement
    {
        private string xpathItemMainMenu = "//ul[contains(@class,'navbar-list')]//li[contains(@class,'navbar-item')]//span[contains(text(),'{0}')]";
        private string xpathItemMainSubMenu = "//ul[contains(@class,'navbar-list')]//li[contains(@class,'navbar-item')]//div[contains(@class,'submenu')]//a[contains(text(),'{0}')]";

        public MainMenu(By locator, string description) : base(locator, description)
        {
        }

        public void GetItem(string mainMenuItem, string mainSubMenuItem)
        {
            Button btnItemMainMenu = new Button(By.XPath(String.Format(xpathItemMainMenu, mainMenuItem)), "Main Menu item");
            btnItemMainMenu.WaitAndClick();
            Button btnItemMainSubMenu = new Button(By.XPath(String.Format(xpathItemMainSubMenu, mainSubMenuItem)), "Main Sub menu item");
            btnItemMainSubMenu.Click();
        }
    }
}
