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

        public IWebElement Song => Driver.FindElement(By.Id("video-title"));
        
        public PlaySong()
        {
            Song.Click();
        }

        public ChannelPage NavigateToChannelPage()
        {
           return new ChannelPage(Driver);
        }
    }
}
