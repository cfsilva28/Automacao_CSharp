using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using OpenQA.Selenium;
namespace Ailos.Test.Automation.Web.OnboardingPF.Pages
{
    public class MainPage : BasePage
    {
        MainModel idField;
        public MainPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<MainModel>(
                Constants.ELEMENTSDIRECTORY + @"\mainPage.json");
        }
        public MainPage expandirMenu()
        {
            click.ClickByCssSelector(idField.menuOnboarding);
            return this;
        }
        public IniciarAtendimentoPage clicarAdmissaoDoCooperado()
        {
            click.ClickByCssSelector(idField.admCooperado);
            return new IniciarAtendimentoPage(driver);
        }
        public MainPage clicarAdmissaoPessoaFisica()
        {
            click.ClickByCssSelector(idField.pessoaFisica);
            return this;
        }
        public IniciarAtendimentoPage acessarMenuOnboardingPf()
        {
            expandirMenu();
            clicarAdmissaoDoCooperado();
            clicarAdmissaoPessoaFisica();
            return new IniciarAtendimentoPage(driver);
        }
    }
}
