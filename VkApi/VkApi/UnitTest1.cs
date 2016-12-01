using System;
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
            string token = XmlReader.GetData("token");
            ILog Log = Logger.GetInstance();
            string requestToGetServer =
                "https://api.vk.com/method/photos.getWallUploadServer.xml?access_token=" + token;
            /*string result = HttpsUtils.Get(request);
            Log.Info(result);*/

            XmlDocument doc = HttpsUtils.GetXml(requestToGetServer);
            string url = XmlReader.GetDataFrom(doc, "upload_url");
            Log.Info(url);

            //result = HttpsUtils.UploadImage(url, XmlReader.GetData("imagePath"), "photo", "image/jpeg");
            NameValueCollection nvc = new NameValueCollection();
            string result = HttpsUtils.HttpUploadFile(url, XmlReader.GetData("imagePath"), "photo", "image/jpeg", nvc);
            Log.Info(result);

            UploadResult uploadResult = JsonConvert.DeserializeObject<UploadResult>(result);

            int server = uploadResult.Server;
            string photo = uploadResult.Photo;
            string hash = uploadResult.Hash;

            /* Log.Info(uploadResult.Server);
             Log.Info(uploadResult.Photo);
             Log.Info(uploadResult.Hash);*/

            string requestToSave = "https://api.vk.com/method/photos.saveWallPhoto?server=" + server + "&photo=" + HttpUtility.UrlEncode(photo) + "&hash=" + hash + "&access_token=" + token;
            string res = HttpsUtils.Get(requestToSave);
            Log.Info(res);
            ImageValues imageValues = JsonConvert.DeserializeObject<ImageValues>(res);


            string requestToPost = "https://api.vk.com/method/wall.post?message=happiness&attachment=" + imageValues.Response[0].Id + "&access_token=" + token;
            string reslt = HttpsUtils.Get(requestToPost);
            Log.Info(reslt);
        }
    }
}
