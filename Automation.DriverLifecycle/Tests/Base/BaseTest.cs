using Frameworks.Driver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Base
{
    internal abstract class BaseTest
    {
        protected DriverSession DriverSession { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            DriverSession = new DriverSession(new ChromeDriverFactory());
            DriverSession.NavigateTo("https://demoqa.com/");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            DriverSession.Dispose();
        }
    }
}
