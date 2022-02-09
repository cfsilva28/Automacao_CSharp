using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using OpenQA.Selenium;
using System;
namespace Ailos.Test.Automation.Web.OnboardingPF.Pages
{
    public class DocumentosAssinaturasPage : BasePage
    {
        DocumentosAsssinaturasModel idField;
        public DocumentosAssinaturasPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<DocumentosAsssinaturasModel>(
                Constants.ELEMENTSDIRECTORY + @"\documentosAssinaturasPage.json");
        }
        public DocumentosAssinaturasPage clicarEmConcluir()
        {
            click.ClickByCssSelector(idField.btnConcluir);
            return this;
        }
        public DocumentosAsssinaturasModel valicacaoNomeResumoDaConta()
        {
            DocumentosAsssinaturasModel dadosTela = new DocumentosAsssinaturasModel();
            dadosTela.nomeCard = get.GetInnerTextByCssSelector(idField.nomeCard);
            System.Threading.Thread.Sleep(4000);
            dadosTela.numContaCard = get.GetInnerTextByCssSelector(idField.numContaCard);
            dadosTela.textAberturaDeContaModal = get.GetInnerTextByCssSelector(idField.textAberturaDeContaModal);
            dadosTela.nomeModal = get.GetInnerTextByCssSelector(idField.nomeModal);
            dadosTela.numContaModal = get.GetInnerTextByCssSelector(idField.numContaModal);
            dadosTela.dataContaModal = get.GetInnerTextByCssSelector(idField.dataContaModal);
            dadosTela.atualData = (DateTime.Now.ToString("dd/MM/yyyy"));
            return dadosTela;
        }

    }

}
