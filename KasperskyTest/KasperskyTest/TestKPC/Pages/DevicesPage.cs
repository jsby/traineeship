using KasperskyTest.FrameWork.Elements;
using OpenQA.Selenium;

namespace KasperskyTest.TestKPC.Pages
{
    public class DevicesPage : KpcParentPage
    {
        private readonly Label _lblHelp = new Label(By.XPath("//nav[contains(@class,'js-devices')]//a"), "Label <Help>");

        public DevicesPage()
        {
            _lblHelp.IsDisplayed();
        }
    }
}
