using System;
using System.Reflection;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestCalc.Framework.Utils;
using TestCalc.TestCalc.Apps;

namespace TestCalc.Steps
{
    [Binding]
    public class CalcSteps
    {
        private static Calculator _calc;
        protected static ILog Log = Logger.GetInstance();

        [BeforeFeature]
        public static void TestInit()
        {
            _calc = new Calculator(XmlReader.GetData("appPath"), XmlReader.GetData("windowName"));
        }

        [Given(@"Calculator is opened")]
        public void GivenCalculatorIsOpened()
        {
            Assert.IsNotNull(_calc);
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(string num)
        {
            _calc.Window.EnterNumber(num);
        }

        [Given(@"I have pressed add")]
        public void GivenIHavePressedAdd()
        {
            _calc.Window.ClickPlus();
        }

        [When(@"I press equal")]
        public void WhenIPressEqual()
        {
            _calc.Window.ClickEqual();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string num)
        {
            //Assert.AreEqual(num, _calc.Window.GetResult());
        }

        [Given(@"I have pressed memPlus")]
        public void GivenIHavePressedMemPlus()
        {
            _calc.Window.ClickMemPlus();
        }

        [Given(@"I have pressed memRecall")]
        public void GivenIHavePressedMemRecall()
        {
            _calc.Window.ClickMemRecall();
        }

        [AfterFeature]
        public static void TestTearDown()
        {
            _calc.Window.Close();
        }
    }
}
