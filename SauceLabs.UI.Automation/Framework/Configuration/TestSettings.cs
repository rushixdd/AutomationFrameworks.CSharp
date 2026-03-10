namespace Framework.Configuration
{
    public class TestSettings
    {
        public string BaseUrl { get; init; }
        public string Browser { get; init; }
        public int TimeoutSeconds { get; init; }

        public TestSettings(string baseUrl, string browser, int timeoutSeconds)
        {
            BaseUrl = baseUrl;
            Browser = browser;
            TimeoutSeconds = timeoutSeconds;
        }
    }
}
