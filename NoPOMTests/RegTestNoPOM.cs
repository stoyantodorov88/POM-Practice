using AutoFixture;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using AutomationPractice;

namespace AutomationPractice
{
    [TestFixture]
    public class Class1
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        Actions _actions;
        UserRegProp _user;
       
        

       

        [SetUp]
        public void SetUp() 
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            _driver.Url = "http://automationpractice.com/index.php";
            _actions = new Actions(_driver);
            _user = new UserRegProp();
            _driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void tearDown() 
        {
            _driver.Quit();
        }

        [Test]
        public void RegisterTest() 
        {
            _user.City = "Colorado";
            var signInButton = _driver.FindElement(By.ClassName("login"));
            signInButton.Click();

           
            var emailField = _wait.Until(d => d.FindElement(By.Id("email_create")));          
            emailField.SendKeys(_user.Email);
            Console.WriteLine(_user.Email);
            var radioButton = _wait.Until(d => d.FindElement(By.Id("id_gender1")));
            radioButton.Click();

            var firstNameField = _driver.FindElement(By.Id("customer_firstname"));
            firstNameField.SendKeys(_user.FirstName);

            var lastNameField = _driver.FindElement(By.Id("customer_lastname"));
            lastNameField.SendKeys(_user.LastName);

            var passwordField = _driver.FindElement(By.Id("passwd"));
            passwordField.SendKeys("asdfg");

            var daysOfBirthField = _driver.FindElement(By.Id("days"));
            daysOfBirthField.SendKeys(_user.Day);

            var monthsOfBirthField = _driver.FindElement(By.Id("months"));
            monthsOfBirthField.SendKeys(_user.Month);

            var yearOfBirthField = _driver.FindElement(By.Id("years"));
            yearOfBirthField.SendKeys(_user.Year);

            var addressField = _driver.FindElement(By.Id("address1"));
            addressField.SendKeys("Rila 10 street");

            var cityField = _driver.FindElement(By.Id("city"));
            cityField.SendKeys(_user.City);

            var stateField = _driver.FindElement(By.Id("id_state"));
            stateField.SendKeys("Colorado");

            var postCodeField = _driver.FindElement(By.Id("postcode"));
            postCodeField.SendKeys("12345");

            var mobilePhoneField = _driver.FindElement(By.Id("phone_mobile"));
            mobilePhoneField.SendKeys(_user.Phone.ToString());

            var addressAliasField = _driver.FindElement(By.Id("alias"));
            addressAliasField.Clear();
            addressAliasField.SendKeys("Bratya Miladinovi");
            
            var registerButton = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[4]/button/span"));
            registerButton.Click();
            
        }

        [Test]
        public void NegativeTestNoPhone()
        {

            var fixture = new Fixture();
            var mail = fixture.Create<String>();

            var signInButton = _driver.FindElement(By.ClassName("login"));
            signInButton.Click();

            var emailField = _wait.Until(d => d.FindElement(By.Id("email_create")));
            emailField.SendKeys($"{mail}@gmail.com" + Keys.Enter);

            var radioButton = _wait.Until(d => d.FindElement(By.Id("id_gender1")));
            radioButton.Click();

            var firstNameField = _driver.FindElement(By.Id("customer_firstname"));
            firstNameField.SendKeys("Stoyan");

            var lastNameField = _driver.FindElement(By.Id("customer_lastname"));
            lastNameField.SendKeys("Todorov");

            var passwordField = _driver.FindElement(By.Id("passwd"));
            passwordField.SendKeys("asdfg");

            var daysOfBirthField = _driver.FindElement(By.Id("days"));
            daysOfBirthField.SendKeys("15");

            var monthsOfBirthField = _driver.FindElement(By.Id("months"));
            monthsOfBirthField.SendKeys("February");

            var yearOfBirthField = _driver.FindElement(By.Id("years"));
            yearOfBirthField.SendKeys("1988");

            var addressField = _driver.FindElement(By.Id("address1"));
            addressField.SendKeys("Rila 10 street");

            var cityField = _driver.FindElement(By.Id("city"));
            cityField.SendKeys("Sofia");

            var stateField = _driver.FindElement(By.Id("id_state"));
            stateField.SendKeys("Colorado");

            var postCodeField = _driver.FindElement(By.Id("postcode"));
            postCodeField.SendKeys("12345");

            var addressAliasField = _driver.FindElement(By.Id("alias"));
            addressAliasField.Clear();
            addressAliasField.SendKeys("Bratya Miladinovi");

            var registerButton = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[4]/button/span"));
            registerButton.Click();

            var noPhoneErrorMessage = _driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li"));
            Assert.IsTrue(noPhoneErrorMessage.Displayed);
            
        }

        [Test]
        public void NegativeTestInvalidPassword()
        {

            var fixture = new Fixture();
            var mail = fixture.Create<String>();

            var signInButton = _driver.FindElement(By.ClassName("login"));
            signInButton.Click();

            var emailField = _wait.Until(d => d.FindElement(By.Id("email_create")));
            emailField.SendKeys($"{mail}@gmail.com" + Keys.Enter);

            var radioButton = _wait.Until(d => d.FindElement(By.Id("id_gender1")));
            radioButton.Click();

            var firstNameField = _driver.FindElement(By.Id("customer_firstname"));
            firstNameField.SendKeys(_user.FirstName);

            var lastNameField = _driver.FindElement(By.Id("customer_lastname"));
            lastNameField.SendKeys("Todorov");

            var passwordField = _driver.FindElement(By.Id("passwd"));
            passwordField.SendKeys("asd");

            var daysOfBirthField = _driver.FindElement(By.Id("days"));
            daysOfBirthField.SendKeys("15");

            var monthsOfBirthField = _driver.FindElement(By.Id("months"));
            monthsOfBirthField.SendKeys("February");

            var yearOfBirthField = _driver.FindElement(By.Id("years"));
            yearOfBirthField.SendKeys("1988");

            var addressField = _driver.FindElement(By.Id("address1"));
            addressField.SendKeys("Rila 10 street");

            var cityField = _driver.FindElement(By.Id("city"));
            cityField.SendKeys("Sofia");

            var stateField = _driver.FindElement(By.Id("id_state"));
            stateField.SendKeys("Colorado");

            var postCodeField = _driver.FindElement(By.Id("postcode"));
            postCodeField.SendKeys("12345");

            var mobilePhoneField = _driver.FindElement(By.Id("phone_mobile"));
            var mobilePhoneFields = _actions.MoveToElement(mobilePhoneField);
            mobilePhoneFields.Perform();
            mobilePhoneField.SendKeys("0886870495");

            var addressAliasField = _driver.FindElement(By.Id("alias"));
            addressAliasField.Clear();
            addressAliasField.SendKeys("Bratya Miladinovi");

            var registerButton = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[4]/button/span"));
            registerButton.Click();

            var wrongPasswordMessage = _driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li/b"));
            Assert.IsTrue(wrongPasswordMessage.Text.Contains("passwd"));
            
        }

        [Test]
        public void NegativeTestAllFieldsAreEmpty()
        {

            var fixture = new Fixture();
            var mail = fixture.Create<String>();

            var signInButton = _driver.FindElement(By.ClassName("login"));
            signInButton.Click();

            var emailField = _wait.Until(d => d.FindElement(By.Id("email_create")));
            emailField.SendKeys($"{mail}@gmail.com" + Keys.Enter);

            /* var radioButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("id_gender1")));
             radioButton.Click();

             var firstNameField = _driver.FindElement(By.Id("customer_firstname"));
             firstNameField.SendKeys("Stoyan");

             var lastNameField = _driver.FindElement(By.Id("customer_lastname"));
             lastNameField.SendKeys("Todorov");

             var passwordField = _driver.FindElement(By.Id("passwd"));
             passwordField.SendKeys("asd");

             var daysOfBirthField = _driver.FindElement(By.Id("days"));
             daysOfBirthField.SendKeys("15");

             var monthsOfBirthField = _driver.FindElement(By.Id("months"));
             monthsOfBirthField.SendKeys("February");

             var yearOfBirthField = _driver.FindElement(By.Id("years"));
             yearOfBirthField.SendKeys("1988");

             var addressField = _driver.FindElement(By.Id("address1"));
             addressField.SendKeys("Rila 10 street");

             var cityField = _driver.FindElement(By.Id("city"));
             cityField.SendKeys("Sofia");

             var stateField = _driver.FindElement(By.Id("id_state"));
             stateField.SendKeys("Colorado");

             var postCodeField = _driver.FindElement(By.Id("postcode"));
             postCodeField.SendKeys("12345");

             var mobilePhoneField = _driver.FindElement(By.Id("phone_mobile"));
             var mobilePhoneFields = _actions.MoveToElement(mobilePhoneField);
             mobilePhoneFields.Perform();
             mobilePhoneField.SendKeys("0886870495");

             var addressAliasField = _driver.FindElement(By.Id("alias"));
             addressAliasField.Clear();
             addressAliasField.SendKeys("Bratya Miladinovi");*/

            var registerButton = _wait.Until(d => d.FindElement(By.XPath("//*[@id='submitAccount']/span")));        
            registerButton.Click();
            
            var wrongPasswordMessage = _driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/p"));
            Assert.IsTrue(wrongPasswordMessage.Text.Contains("There are 8 errors"));


           
        }
    }
}
