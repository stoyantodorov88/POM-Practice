using OpenQA.Selenium;
using POMPractice.YoutubePOM.ObjectPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace POMPractice.YoutubePOM
{
    public class ResultPage : BasePageYT
    {
        public ResultPage(IWebDriver driver)
            :base(driver)
        {
           
        }

        public IWebElement Track => Driver.FindElement(By.Id("video-title"));

        public ChannelPage NavigateToChannelPage()
        {
            Track.Click();
            return new ChannelPage(Driver);
        }
    }
}
