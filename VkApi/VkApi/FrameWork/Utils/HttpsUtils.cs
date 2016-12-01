using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Xml;
using log4net;

namespace VkApi.FrameWork.Utils
{
    public class HttpsUtils
    {
        //private static readonly ILog Log = Logger.GetInstance();

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

        public static string UploadFile(string url, string file, string paramName, string contentType)
        {
            string boundary = "------";
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            Stream requestStream = request.GetRequestStream();

            requestStream.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

            requestStream.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            requestStream.Write(trailer, 0, trailer.Length);
            requestStream.Close();

            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string Out = streamReader.ReadToEnd();
            streamReader.Close();
            return Out;
        }
    }
}
