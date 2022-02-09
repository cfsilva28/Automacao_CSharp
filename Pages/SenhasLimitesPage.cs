using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace Ailos.Test.Automation.Web.OnboardingPF.Pages
{
    public class SenhasLimitesPage : BasePage
    {
        SenhasLimitesModel idField;
        SenhasLimitesModel idData;
        public SenhasLimitesPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<SenhasLimitesModel>(
                Constants.ELEMENTSDIRECTORY + @"\senhasLimitesPage.json");
           
            idData = util.ConvertJsonToObject<SenhasLimitesModel>(
                Constants.DATADIRECTORY + @"\senhasLimitesData.json");
        }
        public SenhasLimitesPage inserirSenha(string senha)
        {
            write.WriteByCssSelector(idField.campoSenha, senha, true);
            System.Threading.Thread.Sleep(2000);
                return this;
        } public SenhasLimitesPage repetirSenha(string senha)
        {
            write.WriteByCssSelector(idField.campoRepetirSenha, senha);
            System.Threading.Thread.Sleep(2000);
            return this;
        }
        public SenhasLimitesPage inserirLetraDeSeguranca(string letras)
        {
            write.WriteByCssSelector(idField.campoLetra, letras, true);
            System.Threading.Thread.Sleep(2000);
            return this;
        }
        public SenhasLimitesPage repetirLetraDeSeguranca(string letras)
        {
            write.WriteByCssSelector(idField.campoRepetirLetra, letras);
            
            return this;
        }
        public DocumentosAssinaturasPage clicarBtnProximo()
        {
            click.ClickByCssSelector(idField.btnProximo);
            return new DocumentosAssinaturasPage(driver);
        }
        [Obsolete]
        public DocumentosAssinaturasPage esperaProximaTela()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 1, 40));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(idField.esperaProximaTela)));
            return new DocumentosAssinaturasPage(driver);
        }
        [Obsolete]
        public DocumentosAssinaturasPage senhasLimites()
        {
            inserirSenha(idData.senha);
            repetirSenha(idData.senha);
            inserirLetraDeSeguranca(idData.letras);
            repetirLetraDeSeguranca(idData.letras);
            clicarBtnProximo();
            esperaProximaTela();
            return new DocumentosAssinaturasPage(driver);
        }
           
    }
}
