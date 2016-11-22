using OpenQA.Selenium;
using TestCars.bin.Debug.FrameWork.Elements;

namespace TestCars.bin.Debug.TestCars.Pages
{
    class HomePage:CarsParentPage
    {
        private Label lblMain = new Label(By.XPath("//div[@class='hero']"), "main label");
        public HomePage()
        {
            lblMain.IsDisplayed();
        }
    }
}
