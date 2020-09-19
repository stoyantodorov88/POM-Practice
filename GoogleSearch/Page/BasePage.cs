using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace POMPractice
{
    public class BasePage
    {
       public IWebDriver Driver { get; }

        public WebDriverWait Wait { get; }

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

    }
}
 