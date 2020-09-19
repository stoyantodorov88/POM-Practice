using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace POMPractice
{
    public class PracticeTest : BaseTest
    {
        protected PracticePage practicePage;

        [SetUp]
        public void SetUp() 
        {
            Initialize();
            Driver.Url = "https://www.google.com/";
            practicePage = new PracticePage(Driver);
        }

        [TearDown]
        public void TearDown() 
        {
            Driver.Quit();
        }

        [Test]
        public void GoogleSearch() 
        {
            practicePage.GoogleSearchBar.SendKeys("Selenium");
            practicePage.GoogleSearchBar.SendKeys(Keys.Enter);
            practicePage.SearchResult.Click();

            Assert.That(practicePage.SeleniumLogo.Displayed);
            ;
        }
    }
}
