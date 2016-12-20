using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotePadTest.Framework.Elements;
using NotePadTest.Framework.Entities;
using NotePadTest.Framework.Utils;
using NotePadTest.TestNotePad.Forms;
using TechTalk.SpecFlow;
using TestStack.White.WindowsAPI;

namespace NotePadTest.TestNotePad.Steps
{
    [Binding]
    public class FeatureSteps
    {
        [Given(@"Notepad is opened")]
        public void GivenNotepadIsOpened()
        {
            Scope.Application = MApplication.Launch(XmlReader.GetData("appPath"));
            Scope.MainWindow = Scope.Application.MainWindow;
            Assert.IsTrue(!Scope.MainWindow.Window.IsClosed);
        }

        [When(@"I press ""(.*)"" from Edit menu")]
        public void WhenIPressFromEditMenu(string subMenu)
        {
            MainView.MenuEdit.UiItem.SubMenu(subMenu).Click();
        }


        [Given(@"I have opened Font modal window")]
        public void GivenIHaveOpenedFontModalWindow()
        {
            MainView.MenuFormat.UiItem.SubMenu("Font...").Click();
            Assert.IsTrue(!MainView.WindowFont.Window.IsClosed);
        }

        [Given(@"I have entered font properties from xml")]
        public void GivenIHaveEnteredFontPropertiesFromXml()
        {
            FontView.ComboBoxFontType.EnterText(XmlReader.GetData("font"));
            FontView.ComboBoxFontSize.EnterText(XmlReader.GetData("size"));
            FontView.ComboBoxScript.Select(XmlReader.GetData("script"));
        }

        [When(@"I press F5 on keyboard")]
        public void WhenIPressF5Keyboard()
        {
            MWindow.PressSpecialKey(KeyboardInput.SpecialKeys.F5);
        }

        [When(@"I press OK")]
        public void WhenIPressOK()
        {
            FontView.ButtonOk.Click();
        }

        [When(@"I open Font modal window")]
        public void WhenIOpenFontModalWindow()
        {
            MainView.MenuFormat.UiItem.SubMenu("Font...").Click();
        }

        [Then(@"the date on the screen should be equal to today's date")]
        public void ThenTheDateOnTheScreenShouldBeEqualToTodaySDate()
        {
            Assert.IsTrue(MainView.Document.Text.Contains(DateTime.Today.ToString("dd.MM.yyyy")));
        }

        [Then(@"font properties on the screen should be equal to properties from xml")]
        public void ThenFontPropertiesOnTheScreenShouldBeEqualToPropertiesFromXml()
        {
            Assert.IsTrue(FontView.ComboBoxFontType.SelectedItemText.Equals(XmlReader.GetData("font")));
            Assert.IsTrue(FontView.ComboBoxFontSize.SelectedItemText.Equals(XmlReader.GetData("size")));
            Assert.IsTrue(FontView.ComboBoxScript.SelectedItemText.Equals(XmlReader.GetData("script")));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Scope.Application.Close();
        }
    }
}
