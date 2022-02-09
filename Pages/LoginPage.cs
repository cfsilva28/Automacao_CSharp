using Ailos.Test.Automation.Web.OnboardingPF.Model;
using Ailos.Test.Automation.Web.Core.Utils;
using OpenQA.Selenium;
namespace Ailos.Test.Automation.Web.OnboardingPF.Pages
{
    public class LoginPage : BasePage
    {
        LoginModel idField;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<LoginModel>(
                Constants.ELEMENTSDIRECTORY + @"\loginPage.json");
        }
        public LoginPage inserirEmail(string login)
        {
            write.WriteByXpath(idField.username, login);
            return this;
        }
        public LoginPage clicarAvancar()
        {
            click.ClickByXpath(idField.avancar);
            return this;
        }
        public LoginPage inserirSenha(string password)
        {
            write.WriteByXpath(idField.password, password);
            return this;
        }
        public MainPage loginEntrar()
        {
            click.ClickByXpath(idField.signInButton);
            return new MainPage(driver);
        }
        public MainPage modalKeepConect()
        {
            click.ClickByXpath(idField.continuarConectado);
            return new MainPage(driver);
        }
        public MainPage fazerlogin(string username, string password)
        {
            inserirEmail(username);
            clicarAvancar();
            inserirSenha(password);
            loginEntrar();
            modalKeepConect();
            return new MainPage(driver);
        }

    }
}
