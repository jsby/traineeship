using System.Xml;

namespace TestCars.bin.Debug.FrameWork.Utils
{
    internal class ReadXML
    {
        private static XmlTextReader reader;

        public static string GetData(string data)
        {
            reader = new XmlTextReader("FrameWork\\Resources\\TestData.xml");
            while (reader.Read())
            {
                if (reader.Name.Equals(data))
                {
                    return reader.ReadString();
                }
            }
            reader.Close();
            return "";
        }
    }
}