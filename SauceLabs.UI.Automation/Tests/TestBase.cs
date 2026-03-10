using Framework.Configuration;
using Framework.Context;
using OpenQA.Selenium;

namespace Tests
{
    public abstract class TestBase
    {
        protected IWebDriver Driver { get; private set; }
        TestContextHolder context;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new TestContextHolder(ConfigurationManager.Settings);
            Driver = context.InitializeDriver();
            Driver.Navigate().GoToUrl(ConfigurationManager.Settings.BaseUrl);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            context.Dispose(Driver);
        }
    }
}
