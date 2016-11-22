using OpenQA.Selenium;
using TestCars.bin.Debug.FrameWork.Elements;

namespace TestCars.bin.Debug.TestCars.Pages
{
    class CurrentCarReviewsPage : CarsParentPage
    {
        private Button btnModelDetails = new Button(By.XPath("//div[@class='model-details']"), "Model details");

        public CurrentCarReviewsPage()
        {
            btnModelDetails.IsDisplayed();
        }

        public void GoToModelDetails()
        {
            btnModelDetails.Click();
        }
    }
}
