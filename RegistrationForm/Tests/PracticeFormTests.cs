
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading;

namespace AutomationPractice.registrationForm.Tests
{
    public class PracticeFormTests : BaseTest
    {
        internal PracticeFormPage practiceFormPage;

        public UserRegProp _user;


        [SetUp]      
        public void Setup() 
        {
            Initialize();
            Driver.Url = "https://demoqa.com/automation-practice-form";
            practiceFormPage = new PracticeFormPage(Driver);
            _user = UserFactory.GetValidUser();
        }

        [TearDown]

        public void TearDown() 
        {
            Driver.Quit();
        }

        [Test]

        public void FillForm() 
        {      
            
            practiceFormPage.FirstName.SendKeys(_user.FirstName);
            practiceFormPage.LastName.SendKeys(_user.LastName);
            practiceFormPage.Email.SendKeys($"{_user.Email}@gmail.com");
            practiceFormPage.Phone.SendKeys(_user.Phone.ToString());
            practiceFormPage.Gender[0].Click();
            practiceFormPage.Scroll(practiceFormPage.SubmitButton);
            practiceFormPage.SubmitButton.Click();
            ;
        }
    }
}
