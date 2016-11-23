using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestCars.bin.Debug.FrameWork.Elements
{
    class ComboBox : BaseElement
    {
        private SelectElement comboBoxSelect;
        private Random random = new Random();
        private string selectedValue = "";

        public ComboBox(By locator, string description) : base(locator, description)
        {
            comboBoxSelect = new SelectElement(GetWebElement());
        }
        public void ChooseByValueAndClick(string value)
        {
            comboBoxSelect.SelectByValue(value);
            element.Click();
        }
        public void ChooseByIndexAndClick(int index)
        {
            comboBoxSelect.SelectByIndex(index);
            element.Click();
        }
        public void ChooseRandomOption()
        {
            IList<IWebElement> options = comboBoxSelect.Options;
            System.Diagnostics.Trace.WriteLine(options.Count);
            int index = random.Next(1, options.Count);
            System.Diagnostics.Trace.WriteLine(index);
            IWebElement option = options[index];
            selectedValue = option.Text;
            comboBoxSelect.SelectByIndex(index);
            element.Click();
        }

        public string GetSelectedValue()
        {
            return selectedValue;
        }
    }
}
