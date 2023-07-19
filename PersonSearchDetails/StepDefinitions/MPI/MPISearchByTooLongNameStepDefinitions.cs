using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects.Person;
using WCCIS.Specs.PageObjects;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchByTooLongNameStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchByTooLongNameStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [When(@"an MPI search is conducted using the first name '([^']*)' and surname '([^']*)'")]
        public void WhenAnMPISearchIsConductedUsingTheFirstNameAndSurname(string Forename, string Surname)
        {
            //Select Person Search
            SharedNavigation.ClickPersonSearch(driver, xrmBrowser);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            //Enter first name
            Page_PersonSearch.EnterFirstName(driver);
            //Select Search 
            Page_PersonSearch.ClickSearch(driver);
            xrmBrowser.ThinkTime(1000);
            //Select MPI Search
            Page_PersonSearchResults.ClickMPISearch(driver);
            Page_MPISearch.ClickNHSRadioNo(driver);
            //Enter search details
            Page_MPISearch.EnterSurname(driver, Surname);
            Page_MPISearch.EnterFirstName(driver, Forename);         
        }

        [Then(@"the MPI search field will allow the special characters but remove excess from first name '([^']*)' and surname '([^']*)'")]
        public void ThenTheMPISearchFieldWillAllowTheSpecialCharactersButRemoveExcessFromFirstNameAndSurname(string Forename, string Surname)
        {
            string firstName = Page_MPISearchResults.TrimFirstName(driver);
            Assert.IsTrue(firstName == Forename.Substring(0, 50));
            string lastName = Page_MPISearchResults.TrimLastName(driver);
            Assert.IsTrue(lastName == Surname.Substring(0, 50));
            Page_MPISearch.EnterDOB(driver, "01/01/2000");
        }


        [Then(@"no results will be found")]
        public void ThenNoResultsWillBeFound()
        {
            Page_MPISearch.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(5000);
            Page_MPISearchResults.CheckNoResultsReturned(driver);
        }
    }
}
