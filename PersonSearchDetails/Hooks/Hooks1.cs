using BoDi;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System.Security;
using TechTalk.SpecFlow;

namespace WCCIS.Specs.Hooks
{
    [Binding]
    public class SingleBrowserHook
    {
        // initialise our fields so we can use them
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly IObjectContainer _objectContainer;

        public SingleBrowserHook(IObjectContainer objectContainer)
        {
            // our constructor creates an 'object container' where we can store things we want to use later
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            // This before scenario initialises our browser before each test
            var xrmBrowser = new Microsoft.Dynamics365.UIAutomation.Api.Browser(TestSettings.Options);
            var driver = xrmBrowser.Driver;
            // the below code has been commented out as we are now using our Given statements to
            // specify which user we would like to log in with
            //DHCWExtensions.Login(xrmBrowser, _username, _password);
            //xrmBrowser.GuidedHelp.CloseGuidedHelp();
            //driver.Manage().Window.Maximize();

            // here we are storing an instance of IWebDriver and Browser
            // IWebDriver allows us to control our Browser and also allows us to call Selenium commands to interact with html elements
            // Browser contains Dynamics365 methods allowing us to interact the app, ie click certian option in the command bar
            // this step has a Binding with each scenario and passes these values to each step definition
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
            _objectContainer.RegisterInstanceAs<Browser>(xrmBrowser);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            // This closes the browser down after the test is complete
            var webDriver = _objectContainer.Resolve<IWebDriver>();

            if (webDriver == null) return;

            webDriver.Close();
            webDriver.Dispose();
        }
    }
}