using OpenQA.Selenium;

namespace Frameworks.Driver
{
    public interface IDriverFactory
    {
        IWebDriver CreateDriver();
        string Name { get; }
    }
}