using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace POMPractice.YoutubePOM.ObjectPages
{
    public class ChannelPage : BasePageYT
    {
        public ChannelPage(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement TrackTitle => Driver.FindElement(By.CssSelector("#container > h1"));

    }
}
