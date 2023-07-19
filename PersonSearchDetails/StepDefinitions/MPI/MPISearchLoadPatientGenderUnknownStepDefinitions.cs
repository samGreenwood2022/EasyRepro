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
    public class MPISearchLoadPatientGenderUnknownStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchLoadPatientGenderUnknownStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [Given(@"a result is returned with Gender as '([^']*)'")]
        public void GivenAResultIsReturnedWithGenderAs(string searchValue)
        {
            Page_MPISearchResults.SwitchToNewRecord(driver);
            string gender = Page_PersonCoreDemographics.GetGender(driver);
            Assert.IsTrue(gender.Contains(searchValue));
        }
    }
}
