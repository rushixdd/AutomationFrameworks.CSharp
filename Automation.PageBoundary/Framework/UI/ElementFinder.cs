using OpenQA.Selenium;

namespace Framework.UI
{
    public class ElementFinder
    {
        private readonly IWebDriver driver;

        public ElementFinder(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Find(By locator)
        {
            return driver.FindElement(locator);
        }
    }
}
