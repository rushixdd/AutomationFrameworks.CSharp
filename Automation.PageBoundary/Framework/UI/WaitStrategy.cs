using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.UI
{
    public class WaitStrategy
    {
        private readonly WebDriverWait wait;
        public WaitStrategy(IWebDriver driver, TimeSpan timeout)
        {
            this.wait = new WebDriverWait(driver, timeout);
        }

        public void WaitForElement(By locator)
        {
            wait.Until(driver => driver.FindElement(locator).Displayed);
        }
    }
}
