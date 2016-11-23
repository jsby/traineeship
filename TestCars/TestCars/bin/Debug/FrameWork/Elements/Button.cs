﻿using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using TestCars.bin.Debug.FrameWork.Utils;

namespace TestCars.bin.Debug.FrameWork.Elements
{
    class Button : BaseElement
    {
        public Button(By locator, string description) : base(locator, description)
        {
        }
        public void WaitAndClick()
        {
            Thread.Sleep(3000);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            /*Func<IWebDriver, bool> jsReady = webDriver => js.ExecuteScript("return document.readyState").ToString().Equals("complete");
            wait.Until(jsReady);*/
            WaitElement();
            element.Click();
        }
    }
}
