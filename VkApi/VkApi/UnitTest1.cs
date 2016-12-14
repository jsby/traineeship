using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Json;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Xml;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using VkApi.FrameWork;
using VkApi.FrameWork.Utils;
using VkApi.TestVK.Models;
using XmlReader = VkApi.FrameWork.Utils.XmlReader;

namespace VkApi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ILog log = Logger.GetInstance();
            List<int> belarusMembers = new List<int>();
            List<int> members = VkApiUtil.GetMembers(XmlReader.GetData("group"));
            foreach (var memberId in members)
            {
                if (VkApiUtil.GetUserCountry(memberId) == 3)
                {
                    belarusMembers.Add(memberId);
                }
            }
            foreach (var blrMemberId in belarusMembers)
            {
                log.Info("https://vk.com/id" + blrMemberId);
            }
        }
    }
}
