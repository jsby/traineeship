using System.Threading;
using OpenQA.Selenium;

namespace KasperskyTest.FrameWork.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator, string description) : base(locator, description)
        {
        }

        public void WaitAndClick()
        {
            Thread.Sleep(3000);
            WaitElement();
            Element.Click();
        }
    }
}
