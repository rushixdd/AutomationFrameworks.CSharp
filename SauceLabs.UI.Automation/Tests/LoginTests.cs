using Framework.Wait;
using OpenQA.Selenium;

namespace Tests;

[TestFixture]
public partial class LoginTests : TestBase
{
    [Test]
    [Order(1)]
    public void VerifyLogin()
    {
        this.Driver.WaitForElementUntilVisible(userNameInput).FindElement(userNameInput).SendKeys(username);
        this.Driver.WaitForElementUntilVisible(passwordInput).FindElement(passwordInput).SendKeys(password);
        this.Driver.WaitForElementUntilClickable(loginButton).FindElement(loginButton).Click();
        IWebElement ele = this.Driver.WaitForElementUntilClickable(loginSuccessRespDiv).FindElement(loginSuccessRespDiv);
        Assert.IsTrue(ele.Displayed);
    }

    [Test]
    [Order(2)]
    public void VerifyLogout()
    {
        this.Driver.WaitForElementUntilClickable(expandMenuBtn).FindElement(expandMenuBtn).Click();
        this.Driver.WaitForElementUntilClickable(logoutButton).FindElement(logoutButton).Click();
        IWebElement ele = this.Driver.WaitForElementUntilClickable(userNameInput).FindElement(userNameInput);
        Assert.IsTrue(ele.Displayed);
    }
}
