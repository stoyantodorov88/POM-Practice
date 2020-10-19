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

        public IWebElement ElementsSection => Wait.Until(d => d.FindElement(By.XPath("//div[@class='category-cards']")));

        public IWebElement RadioButton => Driver.FindElement(By.XPath("//*[@id='item-2']/span"));

        public IWebElement ImpressiveButton => Driver.FindElement(By.ClassName("custom-control-label"));

        public IWebElement H1TitleApeears => Driver.FindElement(By.ClassName("mt-3"));

        public IWebElement InteractionsSection => Driver.FindElement(By.XPath("//span[text()='Dragabble']"));

        public IWebElement InteractionsField => Driver.FindElement(By.Id("item-4"));

        public IWebElement DragableBox => Driver.FindElement(By.Id("dragBox"));

    }
}
