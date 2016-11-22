using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCars.bin.Debug.FrameWork.Utils;
using OpenQA.Selenium;

namespace TestCars.bin.Debug.FrameWork.BaseTest
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver = Browser.GetInstance();

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
