using Framework.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class ProfilePage
    {
        private readonly ElementFinder elementFinder;
        private readonly By UserNameLabel = By.Id("userName-value");

        public ProfilePage(IWebDriver driver)
        {
            this.elementFinder = new ElementFinder(driver);
        }

        public bool IsUserLoggedIn()
        {
            return elementFinder.Find(UserNameLabel).Displayed;
        }
    }
}
