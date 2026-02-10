using Framework.Driver;
using Framework.Pages;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Authentication
{
    public class LoginScenarios
    {
        IWebDriver driver;
        IConfiguration config;
        [SetUp]
        public void SetUp()
        {
            DriverSetup driverSetup = new DriverSetup(config);
            driver = driverSetup.driver;
        }

        [Test]
        public void Valid_user_can_login()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Open();
            var profilePage = loginPage.LoginWithValidCredentials("testuser", "Password123!");
            Assert.IsTrue(profilePage.IsUserLoggedIn(), "User should be logged in with valid credentials.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
