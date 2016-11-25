using KasperskyTest.FrameWork.Elements;
using KasperskyTest.TestKPC.Elements;
using KasperskyTest.TestKPC.Models;
using OpenQA.Selenium;

namespace KasperskyTest.TestKPC.Pages
{
    public class ProductPage : StorePage
    {
        private readonly Label _lblProductName = new Label(By.XPath("//div[contains(@class,'js-buyBox')]//h3"), "Label <Product name>");
        private readonly OptionsList _optionsList = new OptionsList(By.XPath("//div[contains(@class,'discount-badge')]"), "Options list");

        public ProductPage()
        {
            _lblProductName.IsDisplayed();
        }

        public Product GetProduct()
        {
            return new Product(_lblProductName.GetText(), _optionsList.GetOptions());
        }
    }
}
