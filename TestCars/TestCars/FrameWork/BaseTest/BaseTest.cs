using System;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestCars.FrameWork.Utils;

namespace TestCars.FrameWork.BaseTest
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver = Browser.GetInstance();
        protected ILog log = Logger.GetInstance();

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(double.Parse(ReadXML.GetData("wait"))));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ReadXML.GetData("startUrl"));
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
