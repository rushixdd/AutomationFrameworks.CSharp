using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Driver
{
    public interface IDriverSession : IDisposable
    {
        IWebDriver WebDriver { get; }

        void Navigate(string relativeUrl);

        IWebElement Find(string selector);

        IReadOnlyCollection<IWebElement> FindAll(string selector);
    }

}
