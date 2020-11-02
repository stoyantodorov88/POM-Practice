using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedTesting.Pages
{
    public class HomePage
    {
        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement LoginButton => Driver.FindElement(By.LinkText("Login"));

        public IWebElement RegisterButton => Driver.FindElement(By.Id("registerLink"));

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public LoginPage NavigateToLoginPage() 
        {
            return new LoginPage(Driver);
        }

        public RegisterPage NavigateToRegisterPage()
        {
            return new RegisterPage(Driver);
        }
    }
}
