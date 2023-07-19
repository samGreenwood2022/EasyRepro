using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchByValidNHSNo_MPIStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchByValidNHSNo_MPIStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [Then(@"a patient result is returned with NHS number '([^']*)'")]
        public void ThenAPatientResultIsReturnedWithNHSNumber(string NHSNumber)
        {
            Page_MPISearchResults.LocateResult(driver, NHSNumber);            
            xrmBrowser.ThinkTime(1000);
        }

        [Then(@"the user is able to open the record with NHS number '([^']*)'")]
        public void ThenTheUserIsAbleToOpenTheRecordWithNHSNumber(string NHSNumber)
        {
            Page_MPISearchResults.OpenSearchResult(driver, NHSNumber);
            Page_MPISearchResults.SwitchToNewRecord(driver);
            string NHSField = Page_PersonCoreDemographics.GetUnformattedNHS(driver);
            Assert.IsTrue(NHSField.Contains(NHSNumber));
        }
    }
}
