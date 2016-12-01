using System;
using OpenQA.Selenium;
using VkApi.FrameWork.Elements;

namespace VkApi.TestVK.Elements
{
    public class MainMenu : BaseElement
    {
        private string xpathItemMainMenu = "//ul[@class='main-menu']//li//a[contains(text(),'{0}')]";

        public MainMenu(By locator, string description) : base(locator, description)
        {
        }

        public void GetItem(string mainMenuItem)
        {
            Button btnItemMainMenu = new Button(By.XPath(String.Format(xpathItemMainMenu, mainMenuItem)), $"Button (Main menu item) <{ mainMenuItem }>");
            btnItemMainMenu.Click();
        }
    }
}
