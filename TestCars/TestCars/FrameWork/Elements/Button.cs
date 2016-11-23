using System.Threading;
using OpenQA.Selenium;

namespace TestCars.FrameWork.Elements
{
    class Button : BaseElement
    {
        public Button(By locator, string description) : base(locator, description)
        {
        }
        public void WaitAndClick()
        {
            Thread.Sleep(3000);
            WaitElement();
            element.Click();
        }
    }
}
