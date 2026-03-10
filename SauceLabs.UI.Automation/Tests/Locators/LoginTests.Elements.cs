using Framework.Wait;
using OpenQA.Selenium;

namespace Tests;

[TestFixture]
public partial class LoginTests : TestBase
{
    private By userNameInput = By.XPath("//input[@data-test='username']");
    private By passwordInput = By.XPath("//input[@data-test='password']");
    private By loginButton = By.XPath("//input[@data-test='login-button']");
    private By loginSuccessRespDiv = By.XPath("//span[text()='Products']");
    private By expandMenuBtn = By.XPath("//button[@id='react-burger-menu-btn']");
    private By logoutButton = By.XPath("//a[@data-test='logout-sidebar-link']");
    private string username = "standard_user";
    private string password = "secret_sauce";
}
