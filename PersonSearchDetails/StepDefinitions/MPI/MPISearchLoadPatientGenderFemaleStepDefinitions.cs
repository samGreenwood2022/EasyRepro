using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects.Person;
using WCCIS.Specs.PageObjects;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchLoadPatientGenderFemaleStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchLoadPatientGenderFemaleStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [Given(@"an MPI Search is conducted with NHS number '([^']*)'")]
        public void GivenAnMPISearchIsConductedWithNHSNumber(string NHSNumber)
        {
            //Select Person Search
            SharedNavigation.ClickPersonSearch(driver, xrmBrowser);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            //Enter first name
            Page_PersonSearch.EnterFirstName(driver);
            //Select Search 
            Page_PersonSearch.ClickSearch(driver);
            xrmBrowser.ThinkTime(2000);
            //Select MPI Search
            Page_PersonSearchResults.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(2000);
            //Enter search address
            Page_MPISearch.EnterNHS(driver, NHSNumber);
            //Click Search
            Page_MPISearch.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(2000);
        }

        [When(@"the patient record is loaded with NHS number '([^']*)'")]
        public void WhenThePatientRecordIsLoadedWithNHSNumber(string NHSNumber)
        {
            Page_MPISearchResults.OpenSearchResult(driver, NHSNumber);
            xrmBrowser.ThinkTime(5000);
        }

        [Then(@"the patient Gender field contains value '([^']*)'")]
        public void ThenThePatientGenderFieldContainsValue(string gender)
        {
            Page_MPISearchResults.SwitchToNewRecord(driver);
            string genderValue = Page_PersonCoreDemographics.GetGender(driver);
            Assert.IsTrue(genderValue.Contains(gender));
        }

    }
}
