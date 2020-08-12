using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice
{
    public class BasePage
    {
               
            public IWebDriver Driver { get; }

            public WebDriverWait Wait { get; }

            public BasePage(IWebDriver driver)
            {

                Driver = driver;
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(4));
              
            }


        public void Scroll(IWebElement element) 
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
