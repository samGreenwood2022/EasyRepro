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
    public class MPISearchLessThan10DigitNHSNoStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchLessThan10DigitNHSNoStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [Given(@"An administrator has logged in")]
        public void GivenAnAdministratorHasLoggedIn()
        {
            // call our AdministratorLogin method
            UserLogin.AdministratorLogin(xrmBrowser, driver);
                // removes any popups displayed when we 1st log in
                xrmBrowser.ThinkTime(2000);
                try
                {
                    driver.SwitchTo().Frame("InlineDialog_Iframe");
                    xrmBrowser.ThinkTime(2000);
                    driver.FindElement(By.XPath("//*[@id=\"butBegin\"]")).Click();

                }
                catch
                {
                    Console.WriteLine("No popup displayed");

                }
                // check to ensure the caredirector logo is displayed
                driver.FindElement(By.XPath("//*[@id=\"navTabLogoTextId\"]/img"));
        }

        [When(@"an MPI search is attempted with NHS Number '([^']*)'")]
        public void WhenAnMPISearchIsAttemptedWithNHSNumber(string NHSNumber)
        {
            //Select Person Search
            SharedNavigation.ClickPersonSearch(driver, xrmBrowser);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            //Enter first name
            Page_PersonSearch.EnterFirstName(driver, "test");
            //Select Search 
            Page_PersonSearch.ClickSearch(driver);
            xrmBrowser.ThinkTime(3000);
            //Select MPI Search
            Page_PersonSearchResults.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(2000);
            //Enter search address
            Page_MPISearch.EnterNHS(driver, NHSNumber);
            //Click Search
            Page_MPISearch.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(2000);
        }

        [Then(@"an error message contains text '([^']*)'")]
        public void ThenAnErrorMessageContainsText(string errorMessage)
        {
            string error = Page_MPISearch.GetErrorMessage(driver);
            Assert.IsTrue(error.Contains(errorMessage));
        }

    }
}
