using OpenQA.Selenium;
using TestCars.FrameWork.Elements;
using TestCars.TestCars.Models;

namespace TestCars.TestCars.Pages
{
    class ReviewsPage : CarsParentPage
    {
        private ComboBox comboBoxMake = new ComboBox(By.XPath("//div[@class='select']//select[@name='makeDropDown']"), "Make comboBox");
        private ComboBox comboBoxModel = new ComboBox(By.XPath("//div[@class='select']//select[@name='modelDropDown']"), "Model comboBox");
        private ComboBox comboBoxYear = new ComboBox(By.XPath("//div[@class='select']//select[@name='yearDropDown']"), "Year comboBox");
        private Button btnSearch = new Button(By.XPath("//div[@class='search-button']"), "Search");

        public ReviewsPage()
        {
            btnSearch.IsDisplayed();
        }

        public Car SearchCar()
        {
            comboBoxMake.ChooseRandomOption();
            comboBoxModel.ChooseRandomOption();
            comboBoxYear.ChooseRandomOption();
            btnSearch.Click();
            return new Car(comboBoxMake.GetSelectedValue(), comboBoxModel.GetSelectedValue(), comboBoxYear.GetSelectedValue());
        }
    }
}
