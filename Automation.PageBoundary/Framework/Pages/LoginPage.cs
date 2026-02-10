using Framework.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly ElementFinder elementFinder;
        private readonly WaitStrategy waitStrategy;
        private readonly By Username = By.Id("userName");
        private readonly By Password = By.Id("password");
        private readonly By LoginButton = By.Id("login");
        private readonly By ErrorMessage = By.Id("name");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.elementFinder = new ElementFinder(driver);
            this.waitStrategy = new WaitStrategy(driver, TimeSpan.FromSeconds(10));
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/login");
        }

        public ProfilePage LoginWithValidCredentials(string user, string pass)
        {
            EnterCredentials(user, pass);
            SubmitLogin();

            return new ProfilePage(driver);
        }

        public void AttemptLoginWithInvalidCredentials(string user, string pass)
        {
            EnterCredentials(user, pass);
            SubmitLogin();
        }

        private void EnterCredentials(string user, string pass)
        {
            waitStrategy.WaitForElement(Username);
            elementFinder.Find(Username).SendKeys(user);
            elementFinder.Find(Password).SendKeys(pass);
        }

        private void SubmitLogin()
        {
            elementFinder.Find(LoginButton).Click();
        }
    }
}
