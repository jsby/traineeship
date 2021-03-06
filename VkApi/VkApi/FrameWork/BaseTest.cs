﻿using System;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using VkApi.FrameWork.Utils;

namespace VkApi.FrameWork
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver = Browser.GetInstance();
        protected ILog Log = Logger.GetInstance();

        [TestInitialize]
        public void TestInitialize()
        {
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(double.Parse(XmlReader.GetData("wait"))));
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(XmlReader.GetData("startUrl"));
        }

        [TestCleanup]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
