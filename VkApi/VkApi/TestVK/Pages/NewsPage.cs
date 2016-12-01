using OpenQA.Selenium;
using VkApi.FrameWork.Elements;

namespace VkApi.TestVK.Pages
{
    public class NewsPage : VkParentPage
    {
        private readonly Button _btnMyPage = new Button(By.XPath("//li[@id='l_pr']//span[contains(@class,'left_label')]"), "Button <My page>");

        public NewsPage()
        {
            _btnMyPage.IsDisplayed();
        }

        public void GoToMyWall()
        {
            _btnMyPage.Click();
        }
    }
}
