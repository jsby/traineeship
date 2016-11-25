using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KasperskyTest.FrameWork.Elements
{
    public class ComboBox : BaseElement
    {
        private SelectElement _comboBoxSelect;
        private readonly Random _random = new Random();
        private string _selectedValue = "";

        public ComboBox(By locator, string description) : base(locator, description)
        {
        }

        public void ChooseByValueAndClick(string value)
        {
            _comboBoxSelect = new SelectElement(GetWebElement());
            _comboBoxSelect.SelectByValue(value);
            Element.Click();
        }

        public void ChooseByIndexAndClick(int index)
        {
            _comboBoxSelect = new SelectElement(GetWebElement());
            _comboBoxSelect.SelectByIndex(index);
            Element.Click();
        }

        public void ChooseRandomOption()
        {
            _comboBoxSelect = new SelectElement(GetWebElement());
            IList<IWebElement> options = _comboBoxSelect.Options;
            int index = _random.Next(1, options.Count);
            IWebElement option = options[index];
            _selectedValue = option.Text;
            _comboBoxSelect.SelectByIndex(index);
            Log.Info(Description + ": choose " + _selectedValue);
            Element.Click();
        }

        public void ChooseByText(string text)
        {
            _comboBoxSelect = new SelectElement(GetWebElement());
            IList<IWebElement> options = _comboBoxSelect.Options;
            foreach (var option in options)
            {
                if (option.Text.Contains(text))
                {
                    Log.Info(Description + ": choose " + option.Text);
                    option.Click();
                }
            }
        }

        public string GetSelectedValue()
        {
            return _selectedValue;
        }
    }
}
