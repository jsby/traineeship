using System.Xml;
using log4net;
using Newtonsoft.Json;
using VkApi.TestVK.Models;

namespace VkApi.FrameWork.Utils
{
    public class VkApiUtil
    {
        protected static ILog Log = Logger.GetInstance();
        private static readonly string Api = XmlReader.GetData("apiLink");
        private static readonly string Token = "&access_token=" + XmlReader.GetData("token");
        private static string _postId;

        public static void Smth()
        {
            //string token = XmlReader.GetData("token");
            // string requestToGetServer = "https://api.vk.com/method/photos.getWallUploadServer.xml?access_token=" + _token;
            /*string result = HttpsUtils.Get(request);
            Log.Info(result);*/

            XmlDocument doc = HttpsUtils.GetXml(Api + "photos.getWallUploadServer.xml?" + Token);
            string serverUrl = XmlReader.GetDataFrom(doc, "upload_url");

            string result = HttpsUtils.UploadFile(serverUrl, XmlReader.GetData("imagePath"), "photo", "image/jpeg");

            UploadResult uploadResult = JsonConvert.DeserializeObject<UploadResult>(result);

            int server = uploadResult.Server;
            string photo = uploadResult.Photo;
            string hash = uploadResult.Hash;

            /* Log.Info(uploadResult.Server);
             Log.Info(uploadResult.Photo);
             Log.Info(uploadResult.Hash);*/

            /*string requestToSave = "https://api.vk.com/method/photos.saveWallPhoto?server=" + server + "&photo=" + HttpUtility.UrlEncode(photo) + "&hash=" + hash + "&access_token=" + token;
            string res = HttpsUtils.Get(requestToSave);
            Log.Info(res);
            ImageValues imageValues = JsonConvert.DeserializeObject<ImageValues>(res);


            string requestToPost = "https://api.vk.com/method/wall.post?message=happiness&attachment=" + imageValues.Response[0].Id + "&access_token=" + token;
            string reslt = HttpsUtils.Get(requestToPost);
            Log.Info(reslt);*/
        }

        public static void MakePost(string text)
        {
            string result = HttpsUtils.Get(Api + "wall.post.xml?message=" + text + Token);
            Log.Info(result);
            //   _postId = XmlReader.GetDataFrom(HttpsUtils.GetXml(Api + "wall.post.xml?message=" + text + Token), "post_id");
        }

        public static void EditPost(string postId, string text)
        {
            string result = HttpsUtils.Get(Api + "wall.edit.xml?message=" + text + Token);
            Log.Info(result);
        }

        public static void AddImageToPost(string postId, string imagePath)
        {
            // HttpsUtils.UploadFile()
        }

        public static string GetWallUploadServer()
        {
            XmlDocument doc = HttpsUtils.GetXml(Api + "photos.getWallUploadServer.xml?" + Token);
            string url = XmlReader.GetDataFrom(doc, "upload_url");
            Log.Info(url);
            return url;
        }
    }
}
