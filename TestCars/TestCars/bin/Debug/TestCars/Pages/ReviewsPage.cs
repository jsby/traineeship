using System.Threading;
using OpenQA.Selenium;
using TestCars.bin.Debug.FrameWork.Elements;
using TestCars.bin.Debug.TestCars.Models;

namespace TestCars.bin.Debug.TestCars.Pages
{
    class ReviewsPage : CarsParentPage
    {
        /*private string xpathComboBoxMake = "//div[@class='select']//select[@name='makeDropDown']";
        private string xpathComboBoxModel = "//div[@class='select']//select[@name='modelDropDown']";
        private string xpathComboBoxYear = "//div[@class='select']//select[@name='yearDropDown']";*/
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
            //ComboBox comboBoxMake = new ComboBox(By.XPath(xpathComboBoxMake), "Make comboBox");
            comboBoxMake.ChooseRandomOption();
            //ComboBox comboBoxModel = new ComboBox(By.XPath(xpathComboBoxModel), "Model comboBox");
            comboBoxModel.ChooseRandomOption();
            //ComboBox comboBoxYear = new ComboBox(By.XPath(xpathComboBoxYear), "Year comboBox");
            comboBoxYear.ChooseRandomOption();
            btnSearch.Click();
            return new Car(comboBoxMake.GetSelectedValue(), comboBoxModel.GetSelectedValue(), comboBoxYear.GetSelectedValue());
        }
    }
}
