using KasperskyTest.FrameWork.Elements;
using OpenQA.Selenium;

namespace KasperskyTest.TestKPC.Pages
{
    public class HomePage
    {
        private readonly Button _btnGoToSignIn = new Button(By.XPath("//div[@class='signin-invite']//button"), "Button <Go to sign in>");
        private readonly TextBox _txtbEmail = new TextBox(By.XPath("//form[@class='js-signin-form']//input[@type='text']"), "TextBox <Email>");
        private readonly TextBox _txtbPassword = new TextBox(By.XPath("//form[@class='js-signin-form']//input[@type='password']"), "TextBox <Password>");
        private readonly Button _btnSignIn = new Button(By.XPath("//form[@class='js-signin-form']//button[contains(@class,'js-btn-signin')]"), "Button <Sign in>");

        public HomePage()
        {
            _btnGoToSignIn.IsDisplayed();
        }

        public void LogIn(string email, string password)
        {
            _btnGoToSignIn.Click();
            _txtbEmail.SendKeys(email);
            _txtbPassword.SendKeys(password);
            _btnSignIn.Click();
        }
    }
}
