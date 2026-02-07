using OpenQA.Selenium;

namespace Frameworks.Driver
{
    public interface IDriverSession : IDisposable
    {
        Guid SessionId { get; }
        DateTimeOffset CreatedAt { get; }
        string BrowserName { get; }

        void NavigateTo(string url);
        string Url { get; }
        string Title { get; }

        IWebElement FindElement(By by);
        IReadOnlyCollection<IWebElement> FindElements(By by);

        /// <summary>
        /// Executes JavaScript when the underlying driver supports it.
        /// Throws NotSupportedException otherwise.
        /// </summary>
        object ExecuteScript(string script, params object[] args);
    }
}