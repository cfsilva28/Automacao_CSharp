using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using Ailos.Test.Automation.Web.OnboardingPF.Pages.Onboarding;
using Bogus;
using Bogus.Extensions.Brazil;
using OpenQA.Selenium;
namespace Ailos.Test.Automation.Web.OnboardingPF.Pages
{
    public class IniciarAtendimentoPage : BasePage
    {
        IniciarAtendimentoModel idField;
        IniciarAtendimentoModel idData;
        public IniciarAtendimentoPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<IniciarAtendimentoModel>(
                Constants.ELEMENTSDIRECTORY + @"\iniciarAtendimentoPage.json");
            idData = util.ConvertJsonToObject<IniciarAtendimentoModel>(
                Constants.DATADIRECTORY + @"\infoCpfData.json");
        }
        public IniciarAtendimentoPage digitarCpf(string cpf)
        {
            write.WriteByCssSelector(idField.campoCpf, cpf);
            System.Threading.Thread.Sleep(300);
            return this;
        }
        public IniciarAtendimentoPage consultaCpf()
        {
            click.ClickByCssSelector(idField.consultarCpf);
            return this;
        }
        public ColetaDeDocumentosPage novaAdmissão()
        {
            click.ClickByCssSelector(idField.iniciarAdmissao);
            return new ColetaDeDocumentosPage(driver);
        }
        public ColetaDeDocumentosPage fecharConsultaAtual()
        {
            click.ClickByCssSelector(idField.limparCpf);
            return new ColetaDeDocumentosPage(driver);
        }
        public ColetaDeDocumentosPage iniciarAtendimento()
        {
            new LoginPage(driver);
            var faker = new Faker("pt_BR");
            digitarCpf(faker.Person.Cpf());
            consultaCpf();
            var situacao = get.GetInnerTextByCssSelector(idField.situacaoDoCpf);
            if (situacao == idData.naoInformado)
            {
                novaAdmissão();
            }
            else if
               (situacao == idData.regular)
            {
                novaAdmissão();
            }
            else
            {
                fecharConsultaAtual();
                digitarCpf(faker.Person.Cpf());
                iniciarAtendimento();
            }
            return new ColetaDeDocumentosPage(driver);
        }
    }
}
