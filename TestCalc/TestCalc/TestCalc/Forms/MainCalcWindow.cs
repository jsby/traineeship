using System.Collections.Generic;
using TestCalc.Framework.Apps;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Button = TestCalc.Framework.Elements.Button;

namespace TestCalc.TestCalc.Forms
{
    public class MainCalcWindow
    {
        private static readonly Window MainWindow = BaseApp.MainWindow as Window;

        private readonly Button _btnNum0 = new Button(MainWindow, "Num0", SearchCriteria.ByAutomationId("num0Button"));
        private readonly Button _btnNum1 = new Button(MainWindow, "Num1", SearchCriteria.ByAutomationId("num1Button"));
        private readonly Button _btnNum2 = new Button(MainWindow, "Num2", SearchCriteria.ByAutomationId("num2Button"));
        private readonly Button _btnNum3 = new Button(MainWindow, "Num3", SearchCriteria.ByAutomationId("num3Button"));
        private readonly Button _btnNum4 = new Button(MainWindow, "Num4", SearchCriteria.ByAutomationId("num4Button"));
        private readonly Button _btnNum5 = new Button(MainWindow, "Num5", SearchCriteria.ByAutomationId("num5Button"));
        private readonly Button _btnNum6 = new Button(MainWindow, "Num6", SearchCriteria.ByAutomationId("num6Button"));
        private readonly Button _btnNum7 = new Button(MainWindow, "Num7", SearchCriteria.ByAutomationId("num7Button"));
        private readonly Button _btnNum8 = new Button(MainWindow, "Num8", SearchCriteria.ByAutomationId("num8Button"));
        private readonly Button _btnNum9 = new Button(MainWindow, "Num9", SearchCriteria.ByAutomationId("num9Button"));

        private readonly List<Button> _btnsNums = new List<Button>();

        private readonly Button _btnPlus = new Button(MainWindow, "Plus", SearchCriteria.ByAutomationId("plusButton"));
        private readonly Button _btnEqual = new Button(MainWindow, "Equal", SearchCriteria.ByAutomationId("equalButton"));

        private readonly Button _btnMemPlus = new Button(MainWindow, "MemPlus", SearchCriteria.ByAutomationId("MemPlus"));
        private readonly Button _btnMemRecall = new Button(MainWindow, "Equal", SearchCriteria.ByAutomationId("MemRecall"));

        //private readonly TextField _txtResult = new TextField(MainWindow, "Result", SearchCriteria.ByAutomationId("CalculatorResults"));

        public MainCalcWindow()
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
            ClickPlus();
            EnterNumber(num2);
            ClickEqual();
        }

        public void AddWithMemory(string num)
        {
            EnterNumber(num);
            ClickPlus();
            _btnMemRecall.Click();
            ClickEqual();
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

        public void ClickPlus()
        {
            _btnPlus.Click();
        }

        public void ClickEqual()
        {
            _btnEqual.Click();
        }

        public void ClickMemPlus()
        {
            _btnMemPlus.Click();
        }

        public void ClickMemRecall()
        {
            _btnMemRecall.Click();
        }

        /*public string GetResult()
        {
            string result = null;
            foreach (var symbol in _txtResult.GetText().ToCharArray())
            {
                if (char.IsDigit(symbol))
                {
                    result = result + symbol;
                }
            }
            return result;
        }*/

        public void Close()
        {
            MainWindow.Close();
        }
    }
}
