using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using POMPractice.YoutubePOM.Tests;
using System;

namespace POMPractice.YoutubePOM.ObjectPages
{
    public class BasePageYT
    {
        public IWebDriver Driver { get; }
        public WebDriverWait Wait { get; }
        

        public BasePageYT(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
         
        }

    }
}
