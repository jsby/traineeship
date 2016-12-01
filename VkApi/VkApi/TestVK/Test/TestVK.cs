using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkApi.FrameWork;
using VkApi.FrameWork.Utils;
using VkApi.TestVK.Pages;

namespace VkApi.TestVK.Test
{
    [TestClass]
    public class TestKpc : BaseTest
    {
        [TestMethod]
        public void TestMethod()
        {
            HomePage homePage = new HomePage();
            homePage.LogIn(XmlReader.GetData("email"), XmlReader.GetData("password"));
            NewsPage newsPage = new NewsPage();
            newsPage.GoToMyWall();
            //https://api.vk.com/method/wall.post?message=mesagabeznapriaga&access_token=1f88e8e99abc98ca3580dae086d8330ac36aede27734c82d0ec753bf5b5a0dea288d81d71beef3831edca
        }
    }
}
