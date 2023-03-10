using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.Dynamics365.UIAutomation.Sample;
using Microsoft.Dynamics365.UIAutomation.Sample.Extentions;
using NUnit.Framework;
using System.Security;


namespace WCCIS.specs.StepDefinitions
{
    [Binding]
    public class PersonSearchStepDefinitions
    {
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();

        [Given(@"that i login with a username & password")]
        public void GivenThatILoginWithAUsernamePassword()
        { 
            
            var xrmBrowser = new Microsoft.Dynamics365.UIAutomation.Api.Browser(TestSettings.Options);

            var driver = xrmBrowser.Driver;
            DHCWExtentions.Login(xrmBrowser, _username, _password);
            xrmBrowser.GuidedHelp.CloseGuidedHelp();
            driver.Manage().Window.Maximize();
            // xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
        }

        [When(@"i perform a person search using firstname '([^']*)', lastname '([^']*)' & dob '([^']*)'")]
        public void WhenIPerformAPersonSearchUsingFirstnameLastnameDob(string firstname, string lastname, string dob)
        {
            throw new PendingStepException();
        }

        [Then(@"the returned record will show the correct name '([^']*)'")]
        public void ThenTheReturnedRecordWillShowTheCorrectName(string name)
        {
            throw new PendingStepException();
        }

        [Then(@"the returned record will show the correct address '([^']*)'")]
        public void ThenTheReturnedRecordWillShowTheCorrectAddress(string address)
        {
            throw new PendingStepException();
        }

        [Then(@"the returned record will show the correct dob '([^']*)'")]
        public void ThenTheReturnedRecordWillShowTheCorrectDob(string dob)
        {
            throw new PendingStepException();
        }
    }
}
