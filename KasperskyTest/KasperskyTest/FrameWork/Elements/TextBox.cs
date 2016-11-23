using OpenQA.Selenium;
using TestCars.FrameWork.Elements;

namespace KasperskyTest.FrameWork.Elements
{
    class TextBox : BaseElement
    {
        public TextBox(By locator, string description) : base(locator, description)
        {
        }

        public void SendKeys(string text)
        {
            element.SendKeys(text);
        }

        public void Submit()
        {
            element.Submit();
        }
    }
}
