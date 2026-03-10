using Framework.Context;
using Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Authentication
{
    public class LoginScenarios
    {
        [Test]
        public void User_can_login_and_see_profile()
        {
            var contextFactory = new TestContextFactory();

            using var context = contextFactory.Create();

            var loginPage = new LoginPage(context.Driver);
            var profilePage = new ProfilePage(context.Driver);

            loginPage.Open();
            loginPage.LoginWithValidCredentials("testuser", "Password123!");

            Assert.That(profilePage.IsUserLoggedIn(), Is.True);

        }

    }
}
