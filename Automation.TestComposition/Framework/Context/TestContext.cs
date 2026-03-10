using Framework.Configurations;
using Framework.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Context
{
    public sealed class TestContext : IDisposable
    {
        public IDriverSession Driver { get; }
        public TestSettings Settings { get; }

        public TestContext(IDriverSession driver, TestSettings settings)
        {
            Driver = driver;
            Settings = settings;
        }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
