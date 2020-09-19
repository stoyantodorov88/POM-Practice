using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace POMPractice
{
    class AutoSearchTest : BaseTests
    {
        public SearchPage searchPage;

        [SetUp]
        public void SetUp() 
        {
            Initialize();
            Driver.Manage().Window.Maximize();
            Driver.Url = "https://www.demoqa.com/";
            searchPage = new SearchPage(Driver);
        }

        [TearDown]
        public void TearDown() 
        {
            Driver.Quit();
        }

        [Test]

        public void RadioButtonsCheck() 
        {
            searchPage.ElementsSection.Click();
            searchPage.RadioButton.Click();
            searchPage.ImpressiveButton.Click();
            Assert.That(searchPage.H1TitleApeears.Displayed);
            
        }

        [Test]

        public void Iterations() 
        {
            searchPage.IterationsSection.Click();
            ScrollTo(searchPage.IterationsField);
            searchPage.IterationsField.Click();
            var positionBefore = searchPage.DragableBox.Location.X;
            Builder.DragAndDropToOffset(searchPage.DragableBox, 15, 20).Perform();
            var positionAfter = searchPage.DragableBox.Location.X;
            Assert.AreNotEqual(positionBefore, positionAfter);
        }
    }
}
