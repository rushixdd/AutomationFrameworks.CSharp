using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Driver
{
    public class DriverSetup
    {
        public IWebDriver driver;
        public DriverSetup(IConfiguration config) { 
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
    }
}