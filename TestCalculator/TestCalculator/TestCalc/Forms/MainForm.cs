using System;
using System.Collections.Generic;
using TestCalculator.Framework.Elements;
using Button = TestCalculator.Framework.Elements.Button;

namespace TestCalculator.TestCalc.Forms
{
    public class MainForm
    {
        private readonly Button _btnNum0 = new Button("Num0", "//button[@automationid='num0Button']");
        private readonly Button _btnNum1 = new Button("Num1", "//button[@automationid='num1Button']");
        private readonly Button _btnNum2 = new Button("Num2", "//button[@automationid='num2Button']");
        private readonly Button _btnNum3 = new Button("Num3", "//button[@automationid='num3Button']");
        private readonly Button _btnNum4 = new Button("Num4", "//button[@automationid='num4Button']");
        private readonly Button _btnNum5 = new Button("Num5", "//button[@automationid='num5Button']");
        private readonly Button _btnNum6 = new Button("Num6", "//button[@automationid='num6Button']");
        private readonly Button _btnNum7 = new Button("Num7", "//button[@automationid='num7Button']");
        private readonly Button _btnNum8 = new Button("Num8", "//button[@automationid='num8Button']");
        private readonly Button _btnNum9 = new Button("Num9", "//button[@automationid='num9Button']");

        private readonly List<Button> _btnsNums = new List<Button>();

        private readonly Button _btnPlus = new Button("Plus", "//button[@automationid='plusButton']");
        private readonly Button _btnEqual = new Button("Equal", "//button[@automationid = 'equalButton']");

        private readonly Button _btnMemPlus = new Button("MemPlus", "//button[@automationid = 'MemPlus']");
        private readonly Button _btnRecallMem = new Button("Equal", "//button[@automationid='MemRecall']");

        private readonly TextField _txtResult = new TextField("Result", "//text[@automationid='CalculatorResults']");

        public MainForm()
        {
            _btnsNums.Add(_btnNum0);
            _btnsNums.Add(_btnNum1);
            _btnsNums.Add(_btnNum2);
            _btnsNums.Add(_btnNum3);
            _btnsNums.Add(_btnNum4);
            _btnsNums.Add(_btnNum5);
            _btnsNums.Add(_btnNum6);
            _btnsNums.Add(_btnNum7);
            _btnsNums.Add(_btnNum8);
            _btnsNums.Add(_btnNum9);
        }

        public void AddNumbers(string num1, string num2)
        {
            EnterNumber(num1);
            _btnPlus.Click();
            EnterNumber(num2);
            _btnEqual.Click();
        }

        public void SaveMemory()
        {
            _btnMemPlus.Click();
        }

        public void AddWithMemory(string num)
        {
            EnterNumber(num);
            _btnPlus.Click();
            _btnRecallMem.Click();
            _btnEqual.Click();
        }

        public void EnterNumber(string num)
        {
            char[] digits = num.ToCharArray();
            foreach (var digit in digits)
            {
                foreach (var btnNum in _btnsNums)
                {
                    if (btnNum.GetName().Contains(digit.ToString()))
                    {
                        btnNum.Click();
                    }
                }
            }
        }
    }
}
