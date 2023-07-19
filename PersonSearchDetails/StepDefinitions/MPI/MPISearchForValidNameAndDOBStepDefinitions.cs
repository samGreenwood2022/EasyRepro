using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchForValidNameAndDOBStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchForValidNameAndDOBStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [Then(@"a result is returned with values '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenAResultIsReturnedWithValuesAnd(string firstName, string surname, string DOB)
        {
            Page_MPISearchResults.CheckResultsReturned(driver);
            Page_MPISearchResults.FindAndOpenFullNamePostcodeMatch(driver, firstName, surname, DOB);
        }

        [Then(@"the result can be opened with the values '([^']*)', '([^']*)', and '([^']*)' to create a new record")]
        public void ThenTheResultCanBeOpenedWithTheValuesAndToCreateANewRecord(string firstNameValue, string lastNameValue, string DOBValue)
        {
            Page_MPISearchResults.SwitchToNewRecord(driver);
            string firstField = Page_PersonCoreDemographics.GetFirstNameValue(driver);
            string surnameField = Page_PersonCoreDemographics.GetLastNameValue(driver);
            string DOBField = Page_PersonCoreDemographics.GetDOBValue(driver);
            Assert.IsTrue(firstField.Contains(firstNameValue));
            Assert.IsTrue(surnameField.Contains(lastNameValue));
            Assert.IsTrue(DOBField.Contains(DOBValue));
        }
    }
}