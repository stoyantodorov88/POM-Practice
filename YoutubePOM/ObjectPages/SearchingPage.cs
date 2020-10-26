using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using POMPractice.YoutubePOM.ObjectPages;

namespace POMPractice.YoutubePOM
{
    public class SearchingPage : BasePageYT
    {
        public SearchingPage(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement SignInNoThanksButton => Wait.Until(d => d.FindElement(By.CssSelector("#dismiss-button")));

        public IWebElement CookiesAgreeButton => Wait.Until(d => d.SwitchTo().ActiveElement().FindElement(By.XPath("//*[@id='introAgreeButton']")));

        public IWebElement SearchBox => Driver.FindElement(By.Id("search"));

        public void SearchForSong()
        {   
            SearchBox.SendKeys("Depeche Mode - Its no good") ;
            SearchBox.SendKeys(Keys.Enter);
        }

        public ResultPage NavigateToResultPage()
        {
            return new ResultPage(Driver);
        }
    }
}
