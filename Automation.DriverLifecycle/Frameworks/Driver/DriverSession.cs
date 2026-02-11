using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace Frameworks.Driver
{
    public class DriverSession : IDriverSession
    {
        private readonly IWebDriver _driver;
        public Guid SessionId { get; }
        public DateTimeOffset CreatedAt { get; }
        public string BrowserName { get; }

        public DriverSession(IDriverFactory factory, IConfiguration config)
        {
            config ??= new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: false).Build(); 
            string browser = config["Browser"] ?? "chrome";
            if (factory is null) throw new ArgumentNullException(nameof(factory));
            _driver = factory.CreateDriver() ?? throw new InvalidOperationException("Factory returned null driver.");
            SessionId = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
            BrowserName = factory.Name ?? "unknown";
        }

        public void NavigateTo(string url) => _driver.Navigate().GoToUrl(url);
        public string Url => _driver.Url;
        public string Title => _driver.Title;

        public IWebElement FindElement(By by)
        {
            var e = _driver.FindElement(by);
            return e;
        }

        public IWebDriver SwitchToChildIFrame(By by)
        {
            return _driver.SwitchTo().Frame(FindElement(by));
        }

        public IWebDriver SwitchToParentIFrame()
        {
            return _driver.SwitchTo().ParentFrame();
        }

        public IWebDriver SwitchToDefaultContent()
        {
            return _driver.SwitchTo().DefaultContent();
        }

        public void SwitchToAlert()
        {
            _driver.SwitchTo().Alert();
        }

        public string AlertText()
        {
            return _driver.SwitchTo().Alert().Text;
        }

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public void SwitchToWindow(string windowHandle)
        {
            _driver.SwitchTo().Window(windowHandle);
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var list = _driver.FindElements(by).Select(e => (IWebElement)e).ToList();
            return list.AsReadOnly();
        }

        public object ExecuteScript(string script, params object[] args)
        {
            if (_driver is IJavaScriptExecutor js) return js.ExecuteScript(script, args);
            throw new NotSupportedException("Underlying driver does not support JavaScript execution.");
        }

        public void Dispose()
        {
            try
            {
                _driver?.Quit();
                _driver?.Dispose();
            }
            catch
            {
                // Best-effort disposal - swallow exceptions to avoid hiding test failures.
            }
        }
    }
}