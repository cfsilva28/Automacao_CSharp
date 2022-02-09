﻿using System;
using NUnit.Framework;
using Ailos.Test.Automation.Web.Core.Utils;
[SetUpFixture]
public class BaseReport
{
    static string path = AppDomain.CurrentDomain.BaseDirectory.Split("\\bin")[0];
    Util util = new Util();

    [OneTimeSetUp]
    public void RunBeforeAnyTestSuite()
    {
        util.startGenerateExtentReport(path);
        Log.CurrentLog.Info(String.Format("\r\n..............................................................\r\n" +
                                          "INÍCIO DA EXECUÇÃO\r\n" +
                                          ".............................................................."));
    }

    [OneTimeTearDown]
    public void RunAfterAnyTestSuite()
    {
        util.endGenerateExtentReport();
        Log.CurrentLog.Info(String.Format("\r\n..............................................................\r\n" +
                                          "FIM DA EXECUÇÃO\r\n" +
                                          ".............................................................."));
        Log.CloseLog();
    }
}

namespace Ailos.Test.Automation.Web.OnboardingPF.Utils
{
    public class Initialize : Init
    {
        //Herda a inicialização pelo core

    }
}
