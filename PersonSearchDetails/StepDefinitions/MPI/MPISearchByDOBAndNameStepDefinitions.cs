using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Drawing;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects.Person;
using WCCIS.Specs.PageObjects;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchByDOBAndNameStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchByDOBAndNameStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [When(@"an MPI search is attempted with Forename '([^']*)', Surname '([^']*)' and DOB '([^']*)'")]
        public void WhenAnMPISearchIsAttemptedWithForenameSurnameAndDOB(string Forename, string Surname, string DOB)
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
            Page_MPISearch.ClickNHSRadioNo(driver);
            xrmBrowser.ThinkTime(1000);
            //Enter search criteria
            Page_MPISearch.EnterFirstName(driver, Forename);
            Page_MPISearch.EnterSurname(driver, Surname);
            Page_MPISearch.EnterDOB(driver, DOB);
            //Click Search
            Page_MPISearch.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(2000);
        }

        [Then(@"a patient result is returned with value '([^']*)'")]
        public void ThenAPatientResultIsReturnedWithValue(string searchValue)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Page_MPISearchResults.LocateResult(driver, searchValue);
        }

        [Then(@"the user is able to open the record with Forename '([^']*)', Surname '([^']*)' and DOB '([^']*)'")]
        public void ThenTheUserIsAbleToOpenTheRecordWithForenameSurnameAndDOB(string Forename, string Surname, string DOB)
        {
            Page_MPISearchResults.OpenSearchResult(driver, DOB);
            xrmBrowser.ThinkTime(4000);
        }


        [Then(@"the record contains the value Forename '([^']*)', Surname '([^']*)' and DOB '([^']*)'")]
        public void ThenTheRecordContainsTheValueForenameSurnameAndDOB(string Forename, string Surname, string DOB)
        {
            Page_MPISearchResults.SwitchToNewRecord(driver);
            string firstname = Page_PersonCoreDemographics.GetFirstNameValue(driver);
            Assert.IsTrue(firstname.Contains(Forename));
            string lastname = Page_PersonCoreDemographics.GetLastNameValue(driver);
            Assert.IsTrue(lastname.Contains(Surname));
            string birthdate = Page_PersonCoreDemographics.GetDOBValue(driver);
            Assert.IsTrue(birthdate.Contains(DOB));
        }

    }
}
