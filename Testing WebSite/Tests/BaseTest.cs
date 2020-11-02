using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;


namespace AutomatedTesting
{
    public class BaseTest
    {
       
        protected IWebDriver Driver { get; set; }
        public virtual string Url { get; set; }
        protected void Initialize(string Url)
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Url);  
        }

    }
}
