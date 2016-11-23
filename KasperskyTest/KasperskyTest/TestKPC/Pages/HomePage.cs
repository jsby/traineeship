using KasperskyTest.FrameWork.Elements;
using OpenQA.Selenium;
using TestCars.FrameWork.Elements;

namespace KasperskyTest.TestKPC.Pages
{
    class HomePage
    {
        private Button btnGoToSignIn = new Button(By.XPath("//div[@class='signin-invite']//button"), "Button <Go to sign in>");
        private TextBox txtbEmail = new TextBox(By.XPath("//form[@class='js-signin-form']//input[@type='text']"), "TextBox <Email>");
        private TextBox txtbPassword = new TextBox(By.XPath("//form[@class='js-signin-form']//input[@type='password']"), "TextBox <Password>");
        private Button btnSignIn = new Button(By.XPath("//form[@class='js-signin-form']//button[contains(@class,'js-btn-signin')]"), "Button <Sign in>");

        public HomePage()
        {
            btnGoToSignIn.IsDisplayed();
        }

        public void LogIn(string email, string password)
        {
            btnGoToSignIn.Click();
            txtbEmail.SendKeys(email);
            txtbPassword.SendKeys(password);
            btnSignIn.Click();
        }
    }
}
