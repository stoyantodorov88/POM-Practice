using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedTesting.Pages
{
    public class LoginPage : HomePage
    {

        public LoginPage(IWebDriver driver) :base(driver)
        {
        }

        public IWebElement UserNameField => Driver.FindElement(By.Id("UserName"));
        public IWebElement PasswordField => Driver.FindElement(By.Id("Password"));
        public IWebElement RememberMeCheckBox => Driver.FindElement(By.Name("RememberMe"));
        public IWebElement LogIn => Driver.FindElement(By.XPath("//input[@value='Log in']"));
        public IWebElement HelloAdmin => Driver.FindElement(By.LinkText("Hello admin!"));
        public IWebElement EmployeeList => Wait.Until(d => d.FindElement(By.LinkText("Employee Details")));  
        public IWebElement NameField => Driver.FindElement(By.XPath("//table//tr//th"));

        public void LogInUser(string username, string password) 
        {
            UserNameField.SendKeys(username);
            PasswordField.SendKeys(password);
            RememberMeCheckBox.Click();
            LogIn.Submit();
        }

        public void OpenEmployeeList() 
        {
            EmployeeList.Click();
        }

        
    }
}
