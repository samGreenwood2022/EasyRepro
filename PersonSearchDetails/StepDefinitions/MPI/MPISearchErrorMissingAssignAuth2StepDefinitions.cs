using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects.Person;
using WCCIS.Specs.PageObjects;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchErrorMissingAssignAuth2StepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchErrorMissingAssignAuth2StepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [When(@"the user enters hospital number, forename, surname and two address lines and attempts to search '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenTheUserEntersHospitalNumberForenameSurnameAndAddressLinesAndAttemptsToSearch(string HospNo, string Forename, string LastName, string Street, string City)
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
            Page_MPISearch.EnterHospitalNumber(driver, HospNo);
            Page_MPISearch.EnterFirstName(driver, Forename);
            Page_MPISearch.EnterSurname(driver, LastName);
            Page_MPISearch.EnterStreet(driver, Street);
            Page_MPISearch.EnterCity(driver, City);
            //Click Search
            Page_MPISearch.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(2000);
        }
    }
}
