using AutoFixture;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace AutomationPractice
{
    [TestFixture]
    public class Class2
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        Actions _actions;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            _actions = new Actions(_driver);
        }

        [TearDown]
        public void tearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void dragElement() 
        {
            _driver.Url = "https://demoqa.com/dragabble";
            var sorceBox = _driver.FindElement(By.Id("dragBox"));

            var xPositionBefore = _driver.FindElement(By.Id("dragBox")).GetCssValue("left");

            _actions
                .DragAndDropToOffset(sorceBox, 150, 300)
                .Perform();

            var xPositionAfter = _driver.FindElement(By.Id("dragBox")).GetCssValue("left");

            Assert.AreNotEqual(xPositionBefore, xPositionAfter);
            
        }

        [Test]
        public void elementNotDragged()
        {
            _driver.Url = "https://demoqa.com/dragabble";
            var sorceBox = _driver.FindElement(By.Id("dragBox"));

            var positionOfElementBefore = sorceBox.Location.Y;
            _actions.DragAndDropToOffset(sorceBox, 0, 0).Perform();
            var positionOfElementAfter = sorceBox.Location.Y;

            Assert.AreEqual(positionOfElementBefore, positionOfElementAfter);
        }

        [Test]
        public void droppable() 
        {
            _driver.Url = "https://demoqa.com/droppable";
            Thread.Sleep(2000);
            var sorceBox = _driver.FindElement(By.Id("draggable"));
            var targetBox = _driver.FindElement(By.Id("droppable"));

            var colorBefore = targetBox.GetCssValue("background-color");

            _actions.DragAndDrop(sorceBox, targetBox).Perform();

            var colorAfter = targetBox.GetCssValue("background-color");

            Assert.AreNotEqual(colorBefore, colorAfter);
        }

        [Test]
        public void droppableTestTwo()
        {
            _driver.Url = "https://demoqa.com/droppable";
            Thread.Sleep(2000);
            var sorceBox = _driver.FindElement(By.Id("draggable"));
            var targetBox = _driver.FindElement(By.Id("droppable"));

            var colorBefore = targetBox.GetCssValue("background-color");

            _actions.DragAndDropToOffset(sorceBox, 20, 200).Perform();

            var colorAfter = targetBox.GetCssValue("background-color");

            Assert.AreEqual(colorBefore, colorAfter);
        }

        [Test]
        public void resizableOne()
        {
            _driver.Url = "https://demoqa.com/resizable";

            var resizableBoxPointer = _driver.FindElement(By.XPath("//*[@id='resizableBoxWithRestriction']/span"));
            
            var resizableBoxSizeBefore = resizableBoxPointer.Location.X;

            _actions.ClickAndHold(resizableBoxPointer).MoveByOffset(100, 100).Perform();

            var resizableBoxSizeAfter = resizableBoxPointer.Location.X;

            Assert.AreNotEqual(resizableBoxSizeBefore, resizableBoxSizeAfter);
            ;
        }

        [Test]
        public void resizableTwo()
        {
            _driver.Url = "https://demoqa.com/resizable";

            var resizableBoxPointer = _driver.FindElement(By.XPath("//*[@id='resizableBoxWithRestriction']/span"));

            var resizableBoxSizeBefore = resizableBoxPointer.Location.X;

            _actions.ClickAndHold(resizableBoxPointer).MoveByOffset(0, 0).Perform();

            var resizableBoxSizeAfter = resizableBoxPointer.Location.X;

            Assert.AreEqual(resizableBoxSizeBefore, resizableBoxSizeAfter);
            ;
        }

        [Test]
        public void selectable()
        {
            _driver.Url = "https://demoqa.com/selectable";
            var fieldToClick = _driver.FindElement(By.XPath("//*[@id='verticalListContainer']/li[1]"));

            var fieldToClickColourBefore = fieldToClick.GetCssValue("background-color");

            _actions.MoveToElement(fieldToClick).Click().Perform();

            var fieldToClickColourAfter = fieldToClick.GetCssValue("background-color");

            Assert.AreNotEqual(fieldToClickColourBefore, fieldToClickColourAfter);
        }

        [Test]
        public void sortable()
        {
            _driver.Url = "https://demoqa.com/sortable";

            var sortableElement = _wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]")));

            _actions.ClickAndHold(sortableElement).DragAndDropToOffset(sortableElement, 0, 80).Perform();

            var elementAfterDragAndDrop = _wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[3]")));

            Assert.IsTrue(elementAfterDragAndDrop.Text.Contains("One"));
            ;
        }
    }
}
