using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Configurations
{
    public sealed class TestSettings
    {
        public string BaseUrl { get; init; }
        public string Browser { get; init; }

        public static TestSettings Load()
        {
            return new TestSettings
            {
                BaseUrl = "https://demoqa.com",
                Browser = "Chrome"
            };
        }
    }

}
