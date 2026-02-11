using Framework.Driver;

namespace Framework.Pages
{
    public class ProfilePage
    {
        private readonly IDriverSession _driver;

        public ProfilePage(IDriverSession driver)
        {
            this._driver = driver;
        }

        public bool IsUserLoggedIn()
        {
            return _driver.Find("#userName-value").Displayed;
        }
    }
}
