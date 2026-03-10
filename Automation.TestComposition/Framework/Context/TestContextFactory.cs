using Framework.Configurations;
using Framework.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Context
{
    public class TestContextFactory
    {
        private readonly IDriverSessionFactory _driverFactory;

        public TestContextFactory()
        {
            _driverFactory = new DriverSessionFactory();
        }

        public TestContext Create()
        {
            var settings = TestSettings.Load();

            var driverSession = _driverFactory.Create(
                settings.Browser,
                settings.BaseUrl);

            return new TestContext(driverSession, settings);
        }
    }

}
