using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Driver
{
    public sealed class DriverSession : IDriverSession
    {
        public IWebDriver WebDriver { get; }

        private readonly string _baseUrl;

        public DriverSession(IWebDriver webDriver, string baseUrl)
        {
            WebDriver = webDriver;
            _baseUrl = baseUrl.TrimEnd('/');
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void Navigate(string relativeUrl)
        {
            WebDriver.Navigate().GoToUrl($"{_baseUrl}{relativeUrl}");
        }

        public IWebElement Find(string selector)
        {
            return WebDriver.FindElement(By.CssSelector(selector));
        }

        public IReadOnlyCollection<IWebElement> FindAll(string selector)
        {
            return WebDriver.FindElements(By.CssSelector(selector));
        }

        public void Dispose()
        {
            WebDriver.Quit();
        }
    }

}
