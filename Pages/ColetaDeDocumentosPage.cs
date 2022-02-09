using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace Ailos.Test.Automation.Web.OnboardingPF.Pages.Onboarding
{
    public class ColetaDeDocumentosPage : BasePage
    {
        ColetaDeDocumentosModel idField;
        ColetaDeDocumentosModel idDoc;
        public ColetaDeDocumentosPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<ColetaDeDocumentosModel>(
            Constants.ELEMENTSDIRECTORY + @"\coletaDeDocumentosPage.json");

            idDoc = util.ConvertJsonToObject<ColetaDeDocumentosModel>(
            Constants.DATADIRECTORY + @"\coletaDeDocumentosData.json");
        }
        public ColetaDeDocumentosPage upLoadIdentificacaoFrente()
        {
            write.WriteFileByCssSelector(idField.identificacao, Constants.INPUTDIRECTORY + idDoc.rgFrente);
            return this;
        }
        public ColetaDeDocumentosPage AdcDocumementoIdentificacao(string opcaoDeDocumento)
        {
            System.Threading.Thread.Sleep(4000);
            radio.SelectRadioByCssSelector(idField.carteiraIdentidade, opcaoDeDocumento);
            return this;
        }
        public ColetaDeDocumentosPage upLoadIdentificacaoVerso()
        {
            write.WriteFileByCssSelector(idField.identificacaoVerso, Constants.INPUTDIRECTORY + idDoc.rgVerso);
            System.Threading.Thread.Sleep(1000);
            return this;
        }
        public ColetaDeDocumentosPage upLoadComprovanteDeResidencia()
        {
            write.WriteFileByCssSelector(idField.comprovanteResidencia, Constants.INPUTDIRECTORY + idDoc.comprovante);
            System.Threading.Thread.Sleep(3000);
            return this;
        }
        public ColetaDeDocumentosPage upLoadDocumentoEmancipacao()
        {
            write.WriteFileByCssSelector(idField.documentoEmancipacao, Constants.INPUTDIRECTORY + idDoc.documento);
            System.Threading.Thread.Sleep(3000);
            return this;
        }
        public IdentificacaoTitularPage cliqueProximaPagina()
        {
            click.ClickByCssSelector(idField.proximo);
            return new IdentificacaoTitularPage(driver);
        }
        [Obsolete]
        public IdentificacaoTitularPage esperaAnaliseDeDocumentos()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 1, 40));
            IWebElement element = driver.FindElement(By.XPath(idField.progress));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, idDoc.progress));
            return new IdentificacaoTitularPage(driver);
        }
        [Obsolete]
        public IdentificacaoTitularPage coletaDeDocumentos()
        {
            upLoadIdentificacaoFrente();
            AdcDocumementoIdentificacao(idDoc.opcaoDeDocumento);
            upLoadIdentificacaoVerso();
            upLoadComprovanteDeResidencia();
            upLoadDocumentoEmancipacao();
            cliqueProximaPagina();
            esperaAnaliseDeDocumentos();
            return new IdentificacaoTitularPage(driver);
        }
    }
}

