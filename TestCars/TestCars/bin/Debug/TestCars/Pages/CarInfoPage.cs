using System;
using OpenQA.Selenium;
using TestCars.bin.Debug.FrameWork.Elements;
using TestCars.bin.Debug.TestCars.Elements;

namespace TestCars.bin.Debug.TestCars.Pages
{
    class CarInfoPage : CarsParentPage
    {
        private CarMenu menu = new CarMenu(By.XPath("//div[@class='menu']"), "Car Menu");
        private Button btnViewDetails = new Button(By.XPath("//div[@class='cars-container']//div[contains(@class,'footer_section')]/a"), "View Details");
        private Label lblNumOfTrims = new Label(By.XPath("//section[@id='mmyDashboard']//b[contains(text(),'Trims')]/.."), "Num of trims");

        public CarMenu GetCarMenu()
        {
            return menu;
        }

        public void GetCarDetails()
        {
            btnViewDetails.WaitAndClick();
        }
        public bool AbleToViewDetails()
        {
            Console.WriteLine(lblNumOfTrims.GetText());
            return int.Parse(lblNumOfTrims.GetText()) > 0;
        }
        public bool AbleToCompare()
        {
            return int.Parse(lblNumOfTrims.GetText()) > 1;
        }
    }
}
