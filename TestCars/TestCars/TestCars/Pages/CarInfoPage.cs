using OpenQA.Selenium;
using TestCars.FrameWork.Elements;
using TestCars.TestCars.Elements;

namespace TestCars.TestCars.Pages
{
    class CarInfoPage : CarsParentPage
    {
        private CarMenu menu = new CarMenu(By.XPath("//div[@class='menu']"), "Car Menu");
        private Button btnViewDetails = new Button(By.XPath("//div[@class='cars-container']//div[contains(@class,'footer_section')]/a"), "View Details");
        private Label lblNumOfTrims = new Label(By.XPath("//section[@id='mmyDashboard']//b[contains(text(),'Trims')]/.."), "Num of trims");
        private By locatorCheckBoxCompare = By.XPath("//div[@class='checkbox']");
        private By locatorBtnCompare = By.XPath("//button[@class='cui-button']");

        public CarInfoPage()
        {
            lblNumOfTrims.IsDisplayed();
        }

        public CarMenu GetCarMenu()
        {
            return menu;
        }

        public void GetCarDetails()
        {
            btnViewDetails.WaitAndClick();
        }

        public int GetNumOfTrims()
        {
            string[] lines = lblNumOfTrims.GetText().Split('\n');
            char[] symbols = lines[1].ToCharArray();
            if (!char.IsNumber(symbols[0]))
            {
                return 0;
            }
            return int.Parse(lines[1]);
        }

        public void GoToCompare()
        {
            CheckBox chbCompare = new CheckBox(locatorCheckBoxCompare, "Compare checkbox");
            chbCompare.Click();
            Button btnCompare = new Button(locatorBtnCompare, "Button compare");
            btnCompare.Click();
        }
    }
}
