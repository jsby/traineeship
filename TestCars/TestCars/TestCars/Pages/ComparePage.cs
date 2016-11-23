using OpenQA.Selenium;
using TestCars.FrameWork.Elements;
using TestCars.TestCars.Models;

namespace TestCars.TestCars.Pages
{
    class ComparePage : CarsParentPage
    {
        private Button btnAddCar = new Button(By.XPath("//div[@id='icon-div']"), "Button add car");
        private Button btnCustomizeCompare = new Button(By.XPath("//button[@class='customize-compare-button']"), "Button customize compare");
        private Button btnDone = new Button(By.XPath("//button[@class='ng-binding']"), "Button done");
        private ComboBox comboBoxMake = new ComboBox(By.XPath("//select[@id='make-dropdown']"), "Make comboBox");
        private ComboBox comboBoxModel = new ComboBox(By.XPath("//select[@id='model-dropdown']"), "Model comboBox");
        private ComboBox comboBoxYear = new ComboBox(By.XPath("//select[@id='year-dropdown']"), "Year comboBox");
        private Label lblfirstEngine = new Label(By.XPath("//cars-compare-compare-info[contains(.,'Engine')]//div[@class='info-column']/span/p"), "Label first engine");
        private Label lblsecondEngine = new Label(By.XPath("//cars-compare-compare-info[contains(.,'Engine')]//div[@class='info-column']//span[@index='0']//ng-switch//p"), "Label second engine");

        public ComparePage()
        {
            btnCustomizeCompare.IsDisplayed();
        }

        public void AddCar(Car car)
        {
            btnAddCar.WaitAndClick();
            comboBoxMake.ChooseByText(car.GetMake());
            comboBoxModel.ChooseByText(car.GetModel());
            comboBoxYear.ChooseByText(car.GetYear());
            btnDone.Click();
        }

        public string GetFirstEngine()
        {
            return lblfirstEngine.GetText();
        }
        public string GetSecondEngine()
        {
            return lblsecondEngine.GetText();
        }
    }
}
