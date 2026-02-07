using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Frameworks.Driver
{
    public class ChromeDriverFactory : IDriverFactory
    {
        public string Name => "Chrome";

        public IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            return new ChromeDriver(options);
        }
    }
}
