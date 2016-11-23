using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestCars.FrameWork.Elements
{
    class ComboBox : BaseElement
    {
        private SelectElement comboBoxSelect;
        private Random random = new Random();
        private string selectedValue = "";

        public ComboBox(By locator, string description) : base(locator, description)
        {
        }

        public void ChooseByValueAndClick(string value)
        {
            comboBoxSelect = new SelectElement(GetWebElement());
            comboBoxSelect.SelectByValue(value);
            element.Click();
        }
        public void ChooseByIndexAndClick(int index)
        {
            comboBoxSelect = new SelectElement(GetWebElement());
            comboBoxSelect.SelectByIndex(index);
            element.Click();
        }
        public void ChooseRandomOption()
        {
            comboBoxSelect = new SelectElement(GetWebElement());
            IList<IWebElement> options = comboBoxSelect.Options;
            int index = random.Next(1, options.Count);
            IWebElement option = options[index];
            selectedValue = option.Text;
            comboBoxSelect.SelectByIndex(index);
            log.Info(description + ": choose " + selectedValue);
            element.Click();
        }

        public void ChooseByText(string text)
        {
            comboBoxSelect = new SelectElement(GetWebElement());
            IList<IWebElement> options = comboBoxSelect.Options;
            foreach (var option in options)
            {
                if (option.Text.Contains(text))
                {
                    log.Info(description + ": choose " + option.Text);
                    option.Click();
                }
            }
        }

        public string GetSelectedValue()
        {
            return selectedValue;
        }
    }
}
