using OpenQA.Selenium;
using TestCars.FrameWork.Elements;

namespace TestCars.TestCars.Pages
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
