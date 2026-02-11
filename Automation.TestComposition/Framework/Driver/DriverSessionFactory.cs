using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Driver
{
    public sealed class DriverSessionFactory : IDriverSessionFactory
    {
        public IDriverSession Create(string browser, string baseUrl)
        {
            IWebDriver webDriver = browser.ToLower() switch
            {
                "chrome" => CreateChrome(),
                "firefox" => CreateFirefox(),
                _ => throw new ArgumentException($"Unsupported browser: {browser}")
            };

            return new DriverSession(webDriver, baseUrl);
        }

        private IWebDriver CreateChrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }

        private IWebDriver CreateFirefox()
        {
            var options = new FirefoxOptions();
            return new FirefoxDriver(options);
        }
    }

}
