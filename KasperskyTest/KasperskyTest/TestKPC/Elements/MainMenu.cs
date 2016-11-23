using System;
using OpenQA.Selenium;
using TestCars.FrameWork.Elements;

namespace KasperskyTest.TestKPC.Elements
{
    class MainMenu : BaseElement
    {
        private string xpathItemMainMenu = "//ul[@class='main-menu']/li/a[contains(text(),'{0}')]";
        private string xpathItemMainSubMenu = "";

        public MainMenu(By locator, string description) : base(locator, description)
        {
        }

        public void GetItem(string mainMenuItem)
        {
            Button btnItemMainMenu = new Button(By.XPath(String.Format(xpathItemMainMenu, mainMenuItem)), "Button (Main menu item) <" + mainMenuItem + ">");
            btnItemMainMenu.Click();
        }

        public void GetSubItem(string mainMenuItem, string mainSubMenuItem)
        {
            GetItem(mainMenuItem);
            Button btnItemMainSubMenu = new Button(By.XPath(String.Format(xpathItemMainSubMenu, mainSubMenuItem)), "Button (Main menu item) <" + mainSubMenuItem + ">");
            btnItemMainSubMenu.Click();
        }
    }
}
