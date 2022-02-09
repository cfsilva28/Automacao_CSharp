using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using OpenQA.Selenium;
using System;
using Global = Ailos.Test.Automation.Web.OnboardingPF.Utils.Global;

namespace Ailos.Test.Automation.Web.OnboardingPF.Pages.Onboarding
{
    public class IdentificacaoTitularPage : BasePage
    {
        IdentificacaoTitularModel idField;
        IdentificacaoTitularModel titular;
        public IdentificacaoTitularPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<IdentificacaoTitularModel>(
                Constants.ELEMENTSDIRECTORY + @"\identificacaoDoTitularPage.json");

            titular = util.ConvertJsonToObject<IdentificacaoTitularModel>(
                Constants.DATADIRECTORY + @"\infoTitularData.json");
        }
        public IdentificacaoTitularPage inserirDataDeNascimento(string dataNascimento)
        {
            System.Threading.Thread.Sleep(5000);
            write.WriteFileByCssSelector(idField.data, dataNascimento);
            return this;
        }
        public IdentificacaoTitularPage inserirCapacidadeCivil(string capacidadeCivil)
        {
            select.SelectTextByCssSelector(idField.capacidadeCivil, capacidadeCivil);
            System.Threading.Thread.Sleep(5000);
            return this;
        }
        public IdentificacaoTitularPage inserirDataDeEmancipacao(string dataEmancipacao)
        {
            write.WriteByCssSelector(idField.dataEmancipacao, dataEmancipacao);
            return this;
        }
        public IdentificacaoTitularPage inserirEstadoCivil(string estadoCivil)
        {
            select.SelectTextByCssSelector(idField.estadoCivil, estadoCivil);
            return this;
        }
        public IdentificacaoTitularPage pessoaComDeficiencia(string tipoDeficiencia)
        {
            select.SelectTextByCssSelector(idField.pessoaComDeficiencia, tipoDeficiencia);
            return this;
        }
        public IdentificacaoTitularPage tipoDeNacionalidade(string nacionalidade)
        {
            System.Threading.Thread.Sleep(1000);
            select.SelectTextByCssSelector(idField.nacionalidade, nacionalidade);
            return this;
        }
        public IdentificacaoTitularPage naturalidade(string naturalidade)
        {
            write.WriteByCssSelector(idField.naturalidade, naturalidade, true);
            return this;
        }
        public IdentificacaoTitularPage selecionarSexo(string genero)
        {
            radio.SelectRadioByCssSelector(idField.genero, genero);
            return this;
        }
        public IdentificacaoTitularPage inserirDataConsultaCpf()
        {
            var date = (Keys.Home + DateTime.Now.ToString("dd/MM/yyyy"));
            write.WriteFileByCssSelector(idField.dataConsultaCpf, date);
            return this;
        }
        public IdentificacaoTitularPage selecionarSituacaoCpf(string situacaoDeCpf)
        {
            string validacao = get.GetInnerTextByCssSelector(idField.situacaoDeCpf);
            if (validacao == titular.textoSituacaoCpf)
            {
                select.SelectTextByCssSelector(idField.situacaoDeCpf, situacaoDeCpf);
                inserirDataConsultaCpf();
            }
            return this;
        }
        public IdentificacaoTitularPage selecionarOrgaoEmissor(string orgaoEmissor)
        {
            write.WriteByCssSelector(idField.orgaoEmissor, orgaoEmissor, true);
            return this;
        }
        public IdentificacaoTitularPage selecionarUf(string estado)
        {
            select.SelectTextByCssSelector(idField.estado, estado);
            return this;
        }
        public IdentificacaoTitularPage inserirDataDeEmissao(string dataDeEmissao)
        {
            write.WriteByCssSelector(idField.dataEmissaoRg, dataDeEmissao);
            return this;
        }
        public EnderecosContatosPage clicarEmProximo()
        {
            click.ClickByCssSelector(idField.proximo);
            System.Threading.Thread.Sleep(3000);
            return new EnderecosContatosPage(driver);
        }
        public string getNomeDoTitularDaConta()
        {
            return Global.nomeTitular = get.GetAttributeByCssSelector(idField.nomeTitular, titular.value);
        }
        public EnderecosContatosPage identificacaoDoTitular()
        {
            inserirDataDeNascimento(titular.data);
            inserirCapacidadeCivil(titular.capacidadeCivil);
            inserirDataDeEmancipacao(titular.dataEmancipacao);
            inserirEstadoCivil(titular.estadoCivil);
            pessoaComDeficiencia(titular.tipoDeficiencia);
            tipoDeNacionalidade(titular.nacionalidade);
            naturalidade(titular.naturalidade);
            selecionarSexo(titular.genero);
            selecionarSituacaoCpf(titular.situacaoDeCpf);
            selecionarOrgaoEmissor(titular.orgaoEmissor);
            selecionarUf(titular.estado);
            inserirDataDeEmissao(titular.dataEmissaoRg);
            getNomeDoTitularDaConta();
            clicarEmProximo();
            return new EnderecosContatosPage(driver);
        }
    }
}

