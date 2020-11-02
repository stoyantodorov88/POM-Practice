using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using System.Collections.Generic;

namespace AutomationPractice.registrationForm
{
    public class PracticeFormPage : BasePage
    {

        public PracticeFormPage(IWebDriver driver) 
            : base(driver)
        {            
        }

        public IWebElement FirstName => Wait.Until(d => d.FindElement(By.Id("firstName")));

        public IWebElement LastName => Wait.Until(d => d.FindElement(By.Id("lastName")));

        public IWebElement Email => Wait.Until(d => d.FindElement(By.Id("userEmail")));

        public IWebElement Phone => Driver.FindElement(By.Id("userNumber"));
        public List<IWebElement> Gender => Wait.Until(d => d.FindElements(By.CssSelector("div.custom-radio"))).ToList();
       
        public IWebElement SubmitButton => Driver.FindElement(By.Id("submit"));

      
    }
}
