using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace POMPractice
{
    public class SearchPage : PageBase
    {
        public SearchPage(IWebDriver driver)
            :base(driver)
        {
        }

        public IWebElement ElementsSection => Wait.Until(d => d.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1) > div > div.card-up")));

        public IWebElement RadioButton => Wait.Until(d => d.FindElement(By.XPath("//*[@id='item-2']/span")));

        public IWebElement ImpressiveButton => Wait.Until(d => d.FindElement(By.ClassName("custom-control-label")));

        public IWebElement H1TitleApeears => Wait.Until(d => d.FindElement(By.ClassName("mt-3")));

        public IWebElement IterationsSection => Wait.Until(d => d.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(5) > div > div.card-body")));

        public IWebElement IterationsField => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[5]")));

        public IWebElement DragableBox => Wait.Until(d => d.FindElement(By.Id("dragBox")));

    }
}
