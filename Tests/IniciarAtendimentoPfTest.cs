using Ailos.Test.Automation.Web.OnboardingPF;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using Ailos.Test.Automation.Web.OnboardingPF.Pages;
using Ailos.Test.Automation.Web.OnboardingPF.Pages.Onboarding;
using Ailos.Test.Automation.Web.OnboardingPF.Utils;
using NUnit.Core;
using NUnit.Framework;
using System;
namespace Ailos.Test.Automation.Web.OnboardingPJ.Tests
{
    [TestFixture]
    public class IniciarAtendimentoPfTest : Initialize
    {
        LoginModel login;
        public IniciarAtendimentoPfTest()
        {
            login = util.ConvertJsonToObject<LoginModel>(
                Constants.DATADIRECTORY + @"\loginData.json");
        }
        [TestCase(TestName = "Fluxo Conta Salário")]
        [Obsolete]
        public void IniciarAtendimentoOnboardingNovoUsuario()
        {
            IdentificacaoTitularPage titular = new IdentificacaoTitularPage(driver);
            DocumentosAsssinaturasModel validacaoCriacaoDeConta = new LoginPage(driver)
           .fazerlogin(login.username, login.password)
           .acessarMenuOnboardingPf()
           .iniciarAtendimento()
           .coletaDeDocumentos()
           .identificacaoDoTitular()
           .enderecosContatos()
           .profissionalFincanceiro()
           .informacaoDaConta()
           .senhasLimites()
           .clicarEmConcluir()
           .valicacaoNomeResumoDaConta();
            Assert.AreEqual(Global.nomeTitular, validacaoCriacaoDeConta.nomeCard, "Verificar nome do Card de Criação de Conta");
            Assert.AreEqual(Constants.TEXT_ABERTURA_DE_CONTA, validacaoCriacaoDeConta.textAberturaDeContaModal);
            Assert.AreEqual(validacaoCriacaoDeConta.nomeCard, validacaoCriacaoDeConta.nomeModal);
            Assert.AreEqual(validacaoCriacaoDeConta.numContaCard, validacaoCriacaoDeConta.numContaModal);
            Assert.AreEqual(validacaoCriacaoDeConta.atualData, validacaoCriacaoDeConta.dataContaModal);
        }
    }
}
