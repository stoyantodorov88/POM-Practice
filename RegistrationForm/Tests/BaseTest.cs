﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;


namespace AutomationPractice.registrationForm.Tests
{
   public class BaseTest
    {

        protected IWebDriver Driver { get; set; }

        protected Actions Builder { get; set; }

       // public UserRegProp user = new UserRegProp();

        public void Initialize()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
     
            Builder = new Actions(Driver);
        }
    }
}
