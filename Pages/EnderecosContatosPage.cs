using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace Ailos.Test.Automation.Web.OnboardingPF.Pages.Onboarding
{
    public class EnderecosContatosPage : BasePage
    {
        EnderecosContatosModel idField;
        EnderecosContatosModel titular;
        public EnderecosContatosPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<EnderecosContatosModel>(
                Constants.ELEMENTSDIRECTORY + @"\enderecosContatosPage.json");

            titular = util.ConvertJsonToObject<EnderecosContatosModel>(
                Constants.DATADIRECTORY + @"\enderecosContatosData.json");
        }
        public EnderecosContatosPage inserirCep(string cep)
        {
            write.WriteByCssSelector(idField.cep, cep);
            return this;
        }
        [Obsolete]
        public EnderecosContatosPage esperaCep()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 1, 40));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(idField.esperaCep)));
            return this;
        }
        public EnderecosContatosPage inserirTipodeResidencia(string tipoDeResidencia)
        {
            select.SelectTextByCssSelector(idField.radioButtonTipoResidencia, tipoDeResidencia);
            System.Threading.Thread.Sleep(6000);
            return this;
        }
        public EnderecosContatosPage inserirNumero(string numeroResidencia)
        {
            write.WriteByCssSelector(idField.numeroResidencia, Keys.Home + numeroResidencia);
            return this;
        }
        public EnderecosContatosPage inserirTelefonePrincipal(string telefone)
        {
            write.WriteByCssSelector(idField.telefonePrincipal, telefone);
            return this;
        }
        public EnderecosContatosPage tipoDoContato(string tipoContato)
        {
            select.SelectTextByCssSelector(idField.tipoContato, tipoContato);
            return this;
        }
        public EnderecosContatosPage checkBoxSePossuiWhatsapp(string possuiWhasapp)
        {
            radio.SelectRadioByCssSelector(idField.radioButtonWhatsapp, possuiWhasapp);
            return this;
        }
        public EnderecosContatosPage inserirEmail(string email)
        {
            write.WriteByCssSelector(idField.email, email);
            System.Threading.Thread.Sleep(4000);
            return this;
        }
        public EnderecosContatosPage preferenciaDeContato(string preferenciaContato)
        {
            select.SelectTextByCssSelector(idField.preferenciaContato, preferenciaContato);
            return this;
        }
        public EnderecosContatosPage checkBoxComunicacaoInstitucionalPromocional(string aceiteContrato)
        {
            radio.SelectRadioByCssSelector(idField.radioButtonAceiteContato, aceiteContrato);
            return this;
        }
        public ProfissionalFincanceiroDoCooperadoPage clicarEmProximo()
        {
            click.ClickByCssSelector(idField.botaoProximo);
            return new ProfissionalFincanceiroDoCooperadoPage(driver);
        }

        [Obsolete]
        public ProfissionalFincanceiroDoCooperadoPage enderecosContatos()
        {
            inserirCep(titular.cep);
            esperaCep();
            inserirTipodeResidencia(titular.tipoDeResidencia);
            inserirNumero(titular.numeroResidencia);
            inserirTelefonePrincipal(titular.telefonePrincipal);
            tipoDoContato(titular.tipoContato);
            checkBoxSePossuiWhatsapp(titular.possuiWhasapp);
            inserirEmail(titular.email);
            preferenciaDeContato(titular.preferenciaContato);
            checkBoxComunicacaoInstitucionalPromocional(titular.aceiteContrato);
            clicarEmProximo();
            return new ProfissionalFincanceiroDoCooperadoPage(driver);
        }
    }
}

