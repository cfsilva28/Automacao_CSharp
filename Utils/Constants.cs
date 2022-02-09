using System;
using System.IO;
namespace Ailos.Test.Automation.Web.OnboardingPF
{
    static class Constants
    {
        //public const string URL = "http://localhost:8082/";

        //Browser
        //public const string CHROME = "chrome";
        //public const string FIREFOX = "firefox";
        //public const string REMOTE = "remote";
        public const string ADDONBOARDINGDATA = @"\infoCpfData.json";

        public static string PROJECTDIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string ELEMENTSDIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Elements\";
        public static string DATADIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Data\";
        public static string INPUTDIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Input\";
        public const string NOME_TITULAR_DA_CONTA = "DANIEL COELHO DA COSTA";
        public const string TEXT_ABERTURA_DE_CONTA = "Abertura da conta\r\nfoi concluída!";
    }
}
