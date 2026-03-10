using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.Drivers
{
    public class DriverFactory
    {
        public IWebDriver Create(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => CreateChrome(),
                "firefox" => CreateFirefox(),
                _ => throw new ArgumentException($"Unsupported browser: {browser}")
            };
        }

        private IWebDriver CreateChrome()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }

        private IWebDriver CreateFirefox()
        {
            return new FirefoxDriver();
        }
    }

}
