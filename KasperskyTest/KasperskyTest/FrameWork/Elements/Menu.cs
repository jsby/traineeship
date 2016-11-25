﻿using System;
using OpenQA.Selenium;

namespace KasperskyTest.FrameWork.Elements
{
    public class Menu : BaseElement
    {
        private readonly string _xpathItemMainMenu;
        private readonly string _xpathItemMainSubMenu;

        public Menu(By locator, string description, string xpathItemMainMenu) : base(locator, description)
        {
            _xpathItemMainMenu = xpathItemMainMenu;
        }

        public Menu(By locator, string description, string xpathItemMainMenu, string xpathItemMainSubMenu) : base(locator, description)
        {
            _xpathItemMainMenu = xpathItemMainMenu;
            _xpathItemMainSubMenu = xpathItemMainSubMenu;
        }

        public void GetItem(string mainMenuItem)
        {
            Button btnItemMainMenu = new Button(By.XPath(String.Format(_xpathItemMainMenu, mainMenuItem)), "Button (Main menu item) <" + mainMenuItem + ">");
            btnItemMainMenu.Click();
        }

        public void GetSubItem(string mainMenuItem, string mainSubMenuItem)
        {
            GetItem(mainMenuItem);
            Button btnItemMainSubMenu = new Button(By.XPath(String.Format(_xpathItemMainSubMenu, mainSubMenuItem)), "Button (Main sub menu item) <" + mainSubMenuItem + ">");
            btnItemMainSubMenu.Click();
        }
    }
}
