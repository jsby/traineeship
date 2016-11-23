using OpenQA.Selenium;
using TestCars.FrameWork.Elements;

namespace KasperskyTest.TestKPC.Pages
{
    class DevicesPage : KpcParentPage
    {
        private Label lblHelp = new Label(By.XPath("//nav[contains(@class,'js-devices')]//a"), "Label <Help>");
        public DevicesPage()
        {
            lblHelp.IsDisplayed();
        }
    }
}
