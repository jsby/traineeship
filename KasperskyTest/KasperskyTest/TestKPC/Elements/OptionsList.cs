using System.Collections.Generic;
using KasperskyTest.FrameWork.Elements;
using KasperskyTest.TestKPC.Models;
using OpenQA.Selenium;

namespace KasperskyTest.TestKPC.Elements
{
    class OptionsList : BaseElement
    {
        private readonly By _locatorDevices = By.XPath("//div[contains(@class,'js-buyBox')]//table//tr//td//input/..");
        private readonly By _locatorYear = By.XPath("//div[contains(@class,'js-buyBox')]//table//tr//td[contains(text(),'year')]");
        private readonly By _locatorCurrency = By.XPath("//div[contains(@class,'js-buyBox')]//table//tr//td//span[contains(@class,'price-currency-wrap')]");
        private readonly By _locatorPriceInteger = By.XPath("//div[contains(@class,'js-buyBox')]//table//tr//td//span[contains(@class,'js-price-integer')]");
        private readonly By _locatorPriceCents = By.XPath("//div[contains(@class,'js-buyBox')]//table//tr//td//span[contains(@class,'js-price-cents')]");
        private readonly List<Option> _options = new List<Option>();

        public OptionsList(By locator, string description) : base(locator, description)
        {
        }

        public List<Option> GetOptions()
        {
            List<IWebElement> devices = FindElements(_locatorDevices);
            List<IWebElement> years = FindElements(_locatorYear);
            List<IWebElement> currencies = FindElements(_locatorCurrency);
            List<IWebElement> priceInteger = FindElements(_locatorPriceInteger);
            List<IWebElement> priceCents = FindElements(_locatorPriceCents);
            for (int i = 0; i < devices.Count; i++)
            {
                _options.Add(new Option(devices[i].Text, years[i].Text,
                    currencies[i].Text + priceInteger[i].Text + priceCents[i].Text));
            }
            return _options;
        }
    }
}
