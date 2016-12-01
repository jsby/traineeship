using OpenQA.Selenium;
using VkApi.FrameWork.Elements;

namespace VkApi.TestVK.Pages
{
    public class HomePage
    {
        private readonly TextBox _txtbEmail = new TextBox(By.XPath("//input[@id='index_email']"), "TextBox <Email>");
        private readonly TextBox _txtbPassword = new TextBox(By.XPath("//input[@id='index_pass']"), "TextBox <Password>");
        private readonly Button _btnLogIn = new Button(By.XPath("//button[@id='index_login_button']"), "Button <Log in>");

        public HomePage()
        {
            _btnLogIn.IsDisplayed();
        }

        public void LogIn(string email, string password)
        {
            _txtbEmail.SendKeys(email);
            _txtbPassword.SendKeys(password);
            _btnLogIn.Click();
        }
    }
}
