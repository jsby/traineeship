using System;
using System.Collections.Generic;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestCars.FrameWork.Utils;

namespace TestCars.FrameWork.Elements
{
    class BaseElement
    {
        protected IWebElement element;
        protected By locator;
        protected string description;
        protected static IWebDriver driver = Browser.GetInstance();
        protected static ILog log = Logger.GetInstance();

        public BaseElement(By locator, string description)
        {
            this.locator = locator;
            this.description = description;
        }
        protected void WaitElement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(double.Parse(ReadXML.GetData("wait"))));
            element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public void Click()
        {
            WaitElement();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(double.Parse(ReadXML.GetData("wait"))));
            element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
            log.Info(description + ": click");
        }
        public string GetText()
        {
            WaitElement();
            return element.Text;
        }
        public bool IsDisplayed()
        {
            WaitElement();
            return element.Displayed;
        }
        public string GetCssAttribute(string cssAttribute)
        {
            WaitElement();
            return element.GetCssValue(cssAttribute);
        }
        public string GetAttribute(string attributeName)
        {
            WaitElement();
            return element.GetAttribute(attributeName);
        }
        public bool IsSelected()
        {
            WaitElement();
            return element.Selected;
        }
        public bool IsEnabled()
        {
            WaitElement();
            return element.Enabled;
        }
        public IWebElement FindElement(By by)
        {
            WaitElement();
            return element.FindElement(by);
        }
        public List<IWebElement> FindElements(By by)
        {
            WaitElement();
            return new List<IWebElement>(element.FindElements(by));
        }
        public IWebElement GetWebElement()
        {
            WaitElement();
            return element;
        }
    }
}
