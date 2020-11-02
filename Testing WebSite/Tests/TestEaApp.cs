using AutomatedTesting.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;



namespace AutomatedTesting
{
    public class TestEaApp : BaseTest
    {
        HomePage HomePage;
        LoginPage LoginPage;
        RegisterPage RegisterPage;
        UserRegProp user;

        public override string Url => "http://eaapp.somee.com/";

        [SetUp]

        public void Setup()
        {
            Initialize(Url);
            HomePage = new HomePage(Driver);
            LoginPage = new LoginPage(Driver);
            RegisterPage = new RegisterPage(Driver);
            user = UserFactory.CreateUser();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile($@"C:\Users\barsy\source\repos\AutomatedTesting\AutomatedTesting\Tests\Screenshots\{TestContext.CurrentContext.Test.Name}.png", ScreenshotImageFormat.Png);
            }
            
            Driver.Quit();
        }

        void OpenLoginPage()
        {
            HomePage.ClickLoginButton();
            HomePage.NavigateToLoginPage();
            LoginPage.LogInUser("admin", "password");
        }

        [Test]
        public void RegistrationFormTest()
        {
            HomePage.RegisterButton.Click();
            HomePage.NavigateToRegisterPage();
            RegisterPage.FillForm(user);
            Assert.IsTrue(RegisterPage.HelloGreeting.Displayed);
        }

        [Test]
        public void LoginTest()
        {
            OpenLoginPage();
            Assert.IsTrue(LoginPage.HelloAdmin.Displayed);   
        }

        [Test]
        public void OpenEmployeeListTest()
        {
            OpenLoginPage();
            LoginPage.EmployeeList.Click();
            Assert.IsTrue(LoginPage.NameField.Displayed);
        }

    }
}