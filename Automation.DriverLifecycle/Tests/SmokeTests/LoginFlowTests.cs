using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Base;

namespace Tests.SmokeTests
{
    [TestFixture]
    internal class LoginFlowTests : BaseTest
    {
        [SetUp]
        public void RegisterToBookStore()
        {
            //this.DriverSession.NavigateTo("https://demoqa.com/register");
            //this.DriverSession.FindElement(By.Id("firstname")).SendKeys("Test");
            //this.DriverSession.FindElement(By.Id("lastname")).SendKeys("User");
            //this.DriverSession.FindElement(By.Id("userName")).SendKeys("testuser");
            //this.DriverSession.FindElement(By.Id("password")).SendKeys("cGFzc3dvcmQ$");
            //this.DriverSession.SwitchToChildIFrame(By.XPath("//iframe[@title='reCAPTCHA']")).FindElement(By.Id("recaptcha-anchor")).Click();
            //this.DriverSession.SwitchToParentIFrame();
            //this.DriverSession.FindElement(By.Id("register")).Click();
            //Thread.Sleep(5000); // Wait for the alert to appear)
            //this.DriverSession.SwitchToAlert();
            //this.DriverSession.AlertText().Should().Contain("User Register Successfully.");
            //this.DriverSession.AcceptAlert();
        }

        [Test]
        public void LoginTest()
        {
            this.DriverSession.NavigateTo("https://demoqa.com/login");
            this.DriverSession.FindElement(By.Id("userName")).SendKeys("testuser");
            this.DriverSession.FindElement(By.Id("password")).SendKeys("cGFzc3dvcmQ$");
            this.DriverSession.FindElement(By.Id("login")).Click();
            Thread.Sleep(5000);
            this.DriverSession.FindElement(By.XPath("//button[text()='Delete Account']")).Displayed.Should().BeTrue();
        }

        [TearDown]
        public void DeleteUser()
        {
            //this.DriverSession.FindElement(By.XPath("//button[text()='Delete Account']")).Click();
            //this.DriverSession.FindElement(By.Id("closeSmallModal-ok")).Click();
            //Thread.Sleep(5000); // Wait for the alert to appear)
            //this.DriverSession.SwitchToAlert();
            //this.DriverSession.AlertText().Should().Contain("User deleted.");
            //this.DriverSession.AcceptAlert();
        }
    }
}
