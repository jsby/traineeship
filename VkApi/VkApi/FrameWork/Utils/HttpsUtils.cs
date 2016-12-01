using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;

namespace VkApi.FrameWork.Utils
{
    public class HttpsUtils
    {
        public static string Get(string requestText)
        {
            WebRequest request = WebRequest.Create(requestText);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string Out = streamReader.ReadToEnd();
            streamReader.Close();
            return Out;
        }

        public static XmlDocument GetXml(string request)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(request);
            return xmlDoc;
        }

        public static string UploadImage(string url, string file, string paramName, string contentType)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data";
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            Stream requestStream = request.GetRequestStream();

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            requestStream.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();
            requestStream.Close();

            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string Out = streamReader.ReadToEnd();
            streamReader.Close();
            return Out;
        }

        public static string SomeDo()
        {
            string token = "";
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            WebRequest post_request2 = WebRequest.Create("https://api.vkontakte.ru/method/photos.getWallUploadServer?access_token=" + token);
            WebResponse post_request_response2 = post_request2.GetResponse();
            Stream post_request_stream2 = post_request_response2.GetResponseStream();
            StreamReader post_request_stream_reader2 = new StreamReader(post_request_stream2);
            string post_request_answer2 = post_request_stream_reader2.ReadToEnd();
            string[] words_empty = post_request_answer2.Split('"');
            string s = words_empty[5];

            s = s.Replace("\\/", "/");
            s = s.Replace("\\/", "/");
            s = s.Replace("\\/", "/");

            string serverAdress = s;


            //отправка файла на полученый сервер
            NameValueCollection nvc = new NameValueCollection();
            //nvc.Add("user", "user");
            //nvc.Add("passwd", "passwd");
            string s9;
            s9 = HttpUploadFile(s, XmlReader.GetData("imagePath"), "photo", "image/jpeg", nvc);
            return s9;

            serverAdress = s9;

            char[] delimiterChars = { ':', ',' };
            string[] parameters = s9.Split(delimiterChars);
            string server = parameters[1];

            char[] delimiterChars2 = { ':' };
            string[] parameters2 = s9.Split(delimiterChars2);
            string hash = parameters2[7];

            char[] delimiterChars3 = { '"' };
            string[] parameters3 = hash.Split(delimiterChars3);
            hash = parameters3[1];

            string photo = s9.Substring(s9.IndexOf("photo") + 8, s9.IndexOf("hash") - s9.IndexOf("photo") - 11);

            photo = photo.Replace("\\\"", "\"");



            //сохранение фотографии на сервере
            string url3 = "https://api.vk.com/method/photos.saveWallPhoto?server=" + server + "&photo=" + HttpUtility.UrlEncode(photo) + "&hash=" + hash + "&access_token=" + token;
            serverAdress = serverAdress + " ---------- " + url3;

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            System.Net.WebRequest post_request3 = System.Net.WebRequest.Create(url3);
            System.Net.WebResponse post_request_response3 = post_request3.GetResponse();
            System.IO.Stream post_request_stream3 = post_request_response3.GetResponseStream();
            System.IO.StreamReader post_request_stream_reader3 = new System.IO.StreamReader(post_request_stream3);
            string post_request_answer3 = post_request_stream_reader3.ReadToEnd();

            serverAdress = serverAdress + " ---------- " + post_request_answer3;
        }

        public static string HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            Console.WriteLine(string.Format("Uploading {0} to {1}", file, url));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            //wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string s3 = reader2.ReadToEnd();
                return s3;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error uploading file", ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string s3 = reader2.ReadToEnd();
                return s3;
            }
            finally
            {
                wr = null;
            }
        }
    }
}
