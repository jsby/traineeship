using System;
using System.Collections.Generic;
using KasperskyTest.FrameWork.Utils;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace KasperskyTest.FrameWork.Elements
{
    public abstract class BaseElement
    {
        protected IWebElement Element;
        protected By Locator;
        protected string Description;
        protected static IWebDriver Driver = Browser.GetInstance();
        protected static ILog Log = Logger.GetInstance();
        protected static List<IWebElement> List;
        private readonly WebDriverWait _wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(double.Parse(XmlReader.GetData("wait"))));

        protected BaseElement(By locator, string description)
        {
            Locator = locator;
            Description = description;
        }

        protected void WaitElement()
        {
            Element = _wait.Until(ExpectedConditions.ElementIsVisible(Locator));
            if (Driver.FindElements(Locator).Count > 1)
            {
                List = new List<IWebElement>(_wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(Locator)));
            }
        }

        public void Click()
        {
            WaitElement();
            Element = _wait.Until(ExpectedConditions.ElementToBeClickable(Locator));
            Element.Click();
            Log.Info(Description + ": click");
        }

        public string GetText()
        {
            WaitElement();
            return Element.Text;
        }

        /// <summary>
        /// return a particular line of element's text
        /// </summary>
        /// <param name="index">line index</param>
        /// <returns>line</returns>
        public string GetText(int index)
        {
            string[] lines = GetText().Split('\n');
            return lines[index];
        }

        public bool IsDisplayed()
        {
            WaitElement();
            return Element.Displayed;
        }

        public string GetCssAttribute(string cssAttribute)
        {
            WaitElement();
            return Element.GetCssValue(cssAttribute);
        }

        public string GetAttribute(string attributeName)
        {
            WaitElement();
            return Element.GetAttribute(attributeName);
        }

        public bool IsSelected()
        {
            WaitElement();
            return Element.Selected;
        }

        public bool IsEnabled()
        {
            WaitElement();
            return Element.Enabled;
        }

        public IWebElement FindElement(By by)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public List<IWebElement> FindElements(By by)
        {
            List = new List<IWebElement>(_wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by)));
            return List;
        }

        public IWebElement GetWebElement()
        {
            WaitElement();
            return Element;
        }

        public List<IWebElement> GetWebElementsList()
        {
            return List;
        }

        public void MoveToElement()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(Element);
            actions.Build().Perform();
        }
    }
}
