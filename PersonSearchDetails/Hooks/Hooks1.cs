using Microsoft.Dynamics365.UIAutomation.Sample.Extentions;
using Microsoft.Dynamics365.UIAutomation.Sample;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Security;
using Microsoft.Dynamics365.UIAutomation.Browser;
using BoDi;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.Dynamics365.UIAutomation.Api;

namespace PersonSearchDetails.Hooks
{
    [Binding]
    public class SingleBrowserHook
    {
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly IObjectContainer _objectContainer;

        public SingleBrowserHook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario("@mytag1")]
        public void BeforeScenarioWithTag()
        {
            var xrmBrowser = new Microsoft.Dynamics365.UIAutomation.Api.Browser(TestSettings.Options);
            var driver = xrmBrowser.Driver;
            DHCWExtentions.Login(xrmBrowser, _username, _password);
            xrmBrowser.GuidedHelp.CloseGuidedHelp();
            driver.Manage().Window.Maximize();


            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
            _objectContainer.RegisterInstanceAs<Browser>(xrmBrowser);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            var webDriver = _objectContainer.Resolve<IWebDriver>();

            if (webDriver == null) return;

            webDriver.Close();
            webDriver.Dispose();
        }
    }
}