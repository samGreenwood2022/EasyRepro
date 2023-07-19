using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects.Person;
using WCCIS.Specs.PageObjects;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchBySurnameAndPostcodeStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchBySurnameAndPostcodeStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [When(@"An MPI search is attempted with Surname '([^']*)' and postcode '([^']*)'")]
        public void WhenAnMPISearchIsAttemptedWithSurnameAndPostcode(string Surname, string Postcode)
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
            //Enter search details
            Page_MPISearch.EnterSurname(driver, Surname);
            Page_MPISearch.EnterPostCode(driver, Postcode);
            //Click Search
            Page_MPISearch.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(2000);
        }

        [Then(@"a result is returned with values '([^']*)' and '([^']*)'")]
        public void ThenAResultIsReturnedWithValuesAnd(string Surname, string Postcode)
        {
            Page_MPISearchResults.CheckResultsReturned(driver);
            Page_MPISearchResults.FindAndOpenSurnamePostcodeMatch(driver, Surname, Postcode);
        }

        [Then(@"the result can be opened with the values '([^']*)' and '([^']*)' to create a new record")]
        public void ThenTheResultCanBeOpenedWithTheValuesAndToCreateANewRecord(string Surname, string Postcode)
        {
            Page_MPISearchResults.SwitchToNewRecord(driver);
            string surnameField = Page_PersonCoreDemographics.GetLastNameValue(driver);
            string PostCodeField = Page_PersonCoreDemographics.GetPostCodeValue(driver);
            Assert.IsTrue(surnameField.Contains(Surname));
            Assert.IsTrue(PostCodeField.Contains(Postcode));
        }
    }
}
