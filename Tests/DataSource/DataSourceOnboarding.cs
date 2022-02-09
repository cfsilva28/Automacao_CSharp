using System.Collections;
using Ailos.Test.Automation.Web.Core.Utils;
using Ailos.Test.Automation.Web.OnboardingPF.Model;
using NUnit.Framework;
namespace Ailos.Test.Automation.Web.OnboardingPF.Tests.DataSource
{
    [TestFixture]
    public class DataSourceOnboarding
    {
        public static Util util = new Util();
        static IniciarAtendimentoModel objCpfInvalido, objCpfNulo;
        public static IEnumerable cpfInvalido
        {
            get
            {
                objCpfInvalido = util.ConvertJsonToObject<IniciarAtendimentoModel>(Constants.DATADIRECTORY + Constants.ADDONBOARDINGDATA);

                yield return new TestCaseData(objCpfInvalido)
                .SetName("Checagem da mensagem esperada após a inserção de um cpf inválido");
            }
        }
        public static IEnumerable cpfNulo
        {

            get
            {
                objCpfNulo = util.ConvertJsonToObject<IniciarAtendimentoModel>(Constants.DATADIRECTORY + Constants.ADDONBOARDINGDATA);
                yield return new TestCaseData(objCpfNulo)
                    .SetName("Checagem da mensagem esperada após validação do campo CPF vazio");
            }
        }

    }    
}
