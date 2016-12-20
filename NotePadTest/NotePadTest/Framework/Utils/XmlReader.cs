using System;
using System.Xml;

namespace NotePadTest.Framework.Utils
{
    public class XmlReader
    {
        private static XmlTextReader _reader;

        public static string GetData(string data)
        {
            _reader = new XmlTextReader(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\" + "FrameWork\\Resources\\TestData.xml");
            while (_reader.Read())
            {
                if (_reader.Name.Equals(data))
                {
                    return _reader.ReadString();
                }
            }
            _reader.Close();
            return null;
        }
    }
}