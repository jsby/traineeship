using System;
using System.Xml;

namespace VkApi.FrameWork.Utils
{
    public class XmlReader
    {
        private static XmlTextReader _reader;

        public static string GetData(string tag)
        {
            _reader = new XmlTextReader(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\FrameWork\\Resources\\TestData.xml");
            while (_reader.Read())
            {
                if (_reader.Name.Equals(tag))
                {
                    return _reader.ReadString();
                }
            }
            _reader.Close();
            return null;
        }

        public static string GetDataFrom(string filePath, string tag)
        {
            _reader = new XmlTextReader(filePath);
            while (_reader.Read())
            {
                if (_reader.Name.Equals(tag))
                {
                    return _reader.ReadString();
                }
            }
            _reader.Close();
            return null;
        }

        public static string GetDataFrom(XmlDocument doc, string tag)
        {
            if (doc.DocumentElement != null)
            {
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (node.Name.Equals(tag))
                    {
                        return node.InnerText;
                    }
                }
            }
            return null;
        }
    }
}