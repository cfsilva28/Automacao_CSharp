using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace Ailos.Test.Automation.Web.OnboardingPF.Pages
{
    public class InformacaoDaContaPage : BasePage
    {
        InformacaoDaContaModel idField;
        InformacaoDaContaModel titular;
        public InformacaoDaContaPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<InformacaoDaContaModel>(
                Constants.ELEMENTSDIRECTORY + @"\informacaoDaContaPage.json");

            titular = util.ConvertJsonToObject<InformacaoDaContaModel>(
                Constants.DATADIRECTORY + @"informacaoContaData.json");
        }
        public InformacaoDaContaPage inserirSituacaoDaConta(string situacaoDeConta)
        {
            select.SelectTextByCssSelector(idField.situacaoDeConta, situacaoDeConta);
            return this;
        }
        public void ScreenDown() // Scroll provisório para alcance do tipo de conta // 
        {
            driver.FindElement(By.CssSelector(idField.postoDeAtendimento)).SendKeys(Keys.Tab + Keys.End);
            System.Threading.Thread.Sleep(3000);
        }
        public InformacaoDaContaPage selecionarTipoDaConta(string tipoDeConta)
        {
            radio.SelectRadioByCssSelector(idField.radioButtonTipoDeConta, tipoDeConta);
            return this;
        }
        public InformacaoDaContaPage clicarAbrirConta()
        {
            click.ClickByCssSelector(idField.abrirConta);
            return this;
        }
        public SenhasLimitesPage gerarConta()
        {
            click.ClickByCssSelector(idField.gerarConta);
            return new SenhasLimitesPage(driver);
        }
        [Obsolete]
        public SenhasLimitesPage esperaAberturaDeConta()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 1, 40));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(idField.esperaAbrirConta)));
            return new SenhasLimitesPage(driver);
        }
        [Obsolete]
        public SenhasLimitesPage informacaoDaConta()
        {
            inserirSituacaoDaConta(titular.situacaoDeConta);
            ScreenDown();
            selecionarTipoDaConta(titular.tipoDeConta);
            clicarAbrirConta();
            gerarConta();
            esperaAberturaDeConta();
            return new SenhasLimitesPage(driver);
        }
    }
}
