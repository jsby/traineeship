﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkApi.FrameWork;
using VkApi.FrameWork.Utils;
using VkApi.TestVK.Pages;

namespace VkApi.TestVK.Test
{
    [TestClass]
    public class TestKpc : BaseTest
    {
        [TestMethod]
        public void TestMethod()
        {
            /* HomePage homePage = new HomePage();
             homePage.LogIn(XmlReader.GetData("email"), XmlReader.GetData("password"));
             NewsPage newsPage = new NewsPage();
             newsPage.GoToMyWall();*/
            string randomStr = StringUtils.RandomString(5);
            Log.Info(randomStr);
            VkApiUtil.MakePost(randomStr);
        }
    }
}
