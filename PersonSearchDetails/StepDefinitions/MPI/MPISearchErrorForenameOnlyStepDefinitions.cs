using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects.Person;
using WCCIS.Specs.PageObjects;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchErrorForenameOnlyStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchErrorForenameOnlyStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [When(@"the user only enters the forename before clicking Search '([^']*)'")]
        public void WhenTheUserOnlyEntersTheForenameBeforeClickingSearch(string Forename)
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
            Page_MPISearch.EnterFirstName(driver, Forename);;
            //Click Search
            Page_MPISearch.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(2000);
        }
    }
}
