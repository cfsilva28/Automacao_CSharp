using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using Bogus;
using Bogus.Extensions.Brazil;
using OpenQA.Selenium;
namespace Ailos.Test.Automation.Web.OnboardingPF.Pages
{
    public class ProfissionalFincanceiroDoCooperadoPage : BasePage
    {
        ProfissionalFinanceiroDoCooperadoModel idField;
        ProfissionalFinanceiroDoCooperadoModel titular;
        public ProfissionalFincanceiroDoCooperadoPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<ProfissionalFinanceiroDoCooperadoModel>(
                Constants.ELEMENTSDIRECTORY + @"\profissionalFinanceiroDoCooperadoPage.json");

            titular = util.ConvertJsonToObject<ProfissionalFinanceiroDoCooperadoModel>(
                Constants.DATADIRECTORY + @"\profissionalData.json");
        }
        public ProfissionalFincanceiroDoCooperadoPage naturezaDaOcupacao(string naturezaOcupacao)
        {
            write.WriteByCssSelector(idField.naturezaOcupacao, naturezaOcupacao, true);
            return this;
        }
        public ProfissionalFincanceiroDoCooperadoPage tipoComprovacaoRenda(string comprovacaoRenda)
        {
            select.SelectTextByCssSelector(idField.comprovacaoRenda, comprovacaoRenda);
            return this;
        }
        public ProfissionalFincanceiroDoCooperadoPage rendaPrincipal(string rendaPrincipal)
        {
            write.WriteByCssSelector(idField.rendaPrincipal, rendaPrincipal);
            return this;
        }
        public ProfissionalFincanceiroDoCooperadoPage inserirOcupacao(string ocupacao)
        {
            write.WriteByCssSelector(idField.ocupacao, ocupacao, true);
            return this;
        }
        public ProfissionalFincanceiroDoCooperadoPage inserirCnpjEmpregador(string cnpj)
        {
            write.WriteByCssSelector(idField.cnpj, cnpj);
            return this;
        }
        public InformacaoDaContaPage clicarProximaPagina()
        {
            click.ClickByCssSelector(idField.proximo);
            System.Threading.Thread.Sleep(9000);
            return new InformacaoDaContaPage(driver);
        }
        public InformacaoDaContaPage profissionalFincanceiro()
        {
            var faker = new Faker("pt_BR");
            naturezaDaOcupacao(titular.naturezaOcupacao);
            tipoComprovacaoRenda(titular.comprovacaoRenda);
            rendaPrincipal(titular.rendaPrincipal);
            inserirOcupacao(titular.ocupacao);
            inserirCnpjEmpregador(faker.Company.Cnpj());
            clicarProximaPagina();
            return new InformacaoDaContaPage(driver);
        }

    }

}
