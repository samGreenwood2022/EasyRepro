// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.UCI
{
    [TestClass]
    public class CreateLeadUCI
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void UCITestCreateLead()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password);

                xrmApp.Navigation.OpenApp("UCI");

                xrmApp.Navigation.OpenSubArea("Sales", "Leads");

                xrmApp.CommandBar.ClickCommand("New");

                xrmApp.ThinkTime(5000);

                xrmApp.Entity.SetValue("subject", "Test Lead Creation");
                xrmApp.Entity.SetValue("firstname", "John");
                xrmApp.Entity.SetValue("lastname", "Doe");

                xrmApp.Entity.Save();

            }
            
        }
    }
}

