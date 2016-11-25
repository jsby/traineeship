using System;
using KasperskyTest.FrameWork.Elements;
using OpenQA.Selenium;

namespace KasperskyTest.TestKPC.Elements
{
    public class StoreMenu : BaseElement
    {
        private readonly string _xpathItemMainMenu = "//div[@class='container']//ul[contains(@class,'b-header-submenu')]//li//span[contains(text(),'{0}')]";
        private readonly string _xpathItemMainSubMenu = "//div[@class='container']//ul[contains(@class,'b-header-submenu')]//li//span[contains(text(),'{0}')]//following-sibling::span//a[contains(text(),'{1}')]";

        public StoreMenu(By locator, string description) : base(locator, description)
        {
        }

        public void GetItem(string mainMenuItem)
        {
            Button btnItemMainMenu = new Button(By.XPath(String.Format(_xpathItemMainMenu, mainMenuItem)), $"Button (Store menu item) <{ mainMenuItem }>");
            btnItemMainMenu.Click();
        }

        public void GetSubItem(string mainMenuItem, string mainSubMenuItem)
        {
            GetItem(mainMenuItem);
            Button btnItemMainSubMenu = new Button(By.XPath(String.Format(_xpathItemMainSubMenu, mainMenuItem, mainSubMenuItem)), $"Button (Store sub menu item) <{ mainSubMenuItem } >");
            btnItemMainSubMenu.Click();
        }
    }
}
