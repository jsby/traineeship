using System;
using Ranorex;
using Ranorex.Core;
using TestCalculator.FrameWork.Utils;

namespace TestCalculator.Framework.Elements
{
    public class BaseElement
    {
        protected Element Element;
        protected string Name;
        protected RxPath RxPath;
        protected readonly int Wait = Convert.ToInt32(XmlReader.GetData("wait"));

        public BaseElement(string name, RxPath rxPath)
        {
            Name = name;
            RxPath = rxPath;
            Element = Host.Local.FindSingle(rxPath);
        }

        public string GetName()
        {
            return Name;
        }
    }
}
