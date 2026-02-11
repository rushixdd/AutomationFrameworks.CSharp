using Framework.Driver;

namespace Framework.Pages
{
    public class LoginPage
    {
        private readonly IDriverSession _driver;

        public LoginPage(IDriverSession driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            _driver.Navigate("/login");
        }

        public void LoginWithValidCredentials(string user, string pass)
        {
            _driver.Find("#userName").SendKeys(user);
            _driver.Find("#password").SendKeys(pass);
            _driver.Find("#login").Click();
        }
    }
}
