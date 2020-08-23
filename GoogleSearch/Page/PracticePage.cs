using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace POMPractice
{
   public class PracticePage : BasePage
    {
        public PracticePage(IWebDriver driver)
            :base(driver)
        {
        }

        public IWebElement GoogleSearchBar => Driver.FindElement(By.Name("q"));

        public IWebElement SearchResult => Wait.Until(d => d.FindElement(By.CssSelector("#rso > div:nth-child(1) > div > div.r > a > h3")));

        public IWebElement SeleniumLogo => Wait.Until(d => d.FindElement(By.XPath("//*[@id='header']/a[1]/img[1]")));
     
    }
}
