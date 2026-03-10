using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Wait
{
    public static class Waiter
    {
        private const int DefaultTimeoutSeconds = 30;

        public static IWebElement WaitForElementUntilVisible(this IWebDriver driver, By locator, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        public static IWebElement WaitForElementUntilClickable(this IWebDriver driver, By locator, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return (element.Displayed && element.Enabled) ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }
    }
}
