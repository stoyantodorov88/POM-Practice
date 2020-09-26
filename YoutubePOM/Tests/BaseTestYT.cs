

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using POMPractice.YoutubePOM.ObjectPages;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace POMPractice.YoutubePOM.Tests
{
    public class BaseTestYT
    {
        public IWebDriver driver;
        public SearchingPage searchingPage;
        public ResultPage resultPage;
        public ChannelPage channelPage;

        [SetUp]
        public void StartUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.youtube.com/";
            searchingPage = new SearchingPage(driver);
            resultPage = new ResultPage(driver);
            channelPage = new ChannelPage(driver);
        }

        [TearDown]
        public void CloseAndQuit()
        {
            driver.Close();
            driver.Quit();
        }

        public void hoverAndClick(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            element.Click();
        }


        public void Click(IWebElement element)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }



    }
}
