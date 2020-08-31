using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace POMPractice
{
    public class PageBase
    {
        public IWebDriver Driver { get; set; }

        public WebDriverWait Wait { get; set; }

        public PageBase(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

    }
}
