using OpenQA.Selenium;

namespace VkApi.FrameWork.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, string description) : base(locator, description)
        {
        }

        public void SendKeys(string text)
        {
            WaitElement();
            Log.Info(Description + ": set " + text);
            Element.SendKeys(text);
        }

        public void Submit()
        {
            WaitElement();
            Log.Info(Description + ": submit");
            Element.Submit();
        }
    }
}
