// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.Dynamics365.UIAutomation.Sample.Extentions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Web
{
    [TestClass]
    public class ScriptTemplate
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();

        [TestMethod]
        public void TestMethod()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                var driver = xrmBrowser.Driver;
                DHCWExtentions.Login(xrmBrowser, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();
                driver.Manage().Window.Maximize();
                xrmBrowser.ThinkTime(2000);
                




            }
        }
    }
}