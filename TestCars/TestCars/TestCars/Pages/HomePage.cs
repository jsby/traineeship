using OpenQA.Selenium;
using TestCars.FrameWork.Elements;

namespace TestCars.TestCars.Pages
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
