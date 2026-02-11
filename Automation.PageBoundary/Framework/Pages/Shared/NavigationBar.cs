using Framework.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages.Shared
{
    public class NavigationBar
    {
        private readonly ElementFinder elementFinder;
        private readonly By ProfileLink = By.Id("item-3");

        public NavigationBar(IWebDriver driver)
        {
            this.elementFinder = new ElementFinder(driver);
        }

        public ProfilePage GoToProfile(IWebDriver driver)
        {
            elementFinder.Find(ProfileLink).Click();
            return new ProfilePage(driver);
        }
    }
}
