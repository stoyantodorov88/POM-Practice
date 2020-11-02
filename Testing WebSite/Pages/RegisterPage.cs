using AutomatedTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AutomatedTesting.Pages
{
    public class RegisterPage : HomePage
    {
        public RegisterPage(IWebDriver driver) :base(driver)
        {
        }

        public IWebElement UserNameField => Driver.FindElement(By.Id("UserName"));
        public IWebElement PasswordField => Driver.FindElement(By.Id("Password"));
        public IWebElement ConfirmPasswordField => Driver.FindElement(By.Id("ConfirmPassword"));
        public IWebElement EmailField => Driver.FindElement(By.Id("Email"));
        public IWebElement Register => Driver.FindElement(By.XPath("//*[@type='submit']"));
        public IWebElement HelloGreeting => Driver.FindElement(By.XPath("//*[@title='Manage']"));

        public void FillForm(UserRegProp user)
        {
            UserNameField.SendKeys(user.FirstName);
            PasswordField.SendKeys($"{ user.Password}1Z*");
            ConfirmPasswordField.SendKeys($"{ user.Password}1Z*");
            EmailField.SendKeys($"{user.Email}@gmail.com");
            Register.Submit();
        }
    }
}
