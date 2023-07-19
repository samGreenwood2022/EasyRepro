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
    public class MPISearchByStreetDesTownCountyStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchByStreetDesTownCountyStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [When(@"an MPI search is conducted using Street '([^']*)', Other Designation '([^']*)', Town '([^']*)' and County '([^']*)'")]
        public void WhenAnMPISearchIsConductedUsingStreetOtherDesignationTownAndCounty(string Street, string OtherDes, string City, string County)
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
            //Enter search address
            Page_MPISearch.EnterStreet(driver, Street);
            Page_MPISearch.EnterOtherDes(driver, OtherDes);
            Page_MPISearch.EnterCity(driver, City);
            Page_MPISearch.EnterCounty(driver, County);
            //Click Search
            Page_MPISearch.ClickMPISearch(driver);
            xrmBrowser.ThinkTime(2000);
        }

        [Then(@"a result is returned with Other Designation Street '([^']*)', '([^']*)', Town '([^']*)' and County '([^']*)'")]
        public void ThenAResultIsReturnedWithOtherDesignationStreetTownAndCounty(string Street, string OtherDes, string City, string County)
        {
            Page_MPISearchResults.CheckResultsReturned(driver);
            Page_MPISearchResults.FindAndOpenStreetDesCityCountyMatch(driver, Street, OtherDes, City, County);
        }

        [Then(@"the result can be opened with Street '([^']*)', Other Designation '([^']*)', Town '([^']*)' and County '([^']*)'")]
        public void ThenTheResultCanBeOpenedWithStreetOtherDesignationTownAndCounty(string Street, string OtherDes, string City, string County)
        {
            Page_MPISearchResults.SwitchToNewRecord(driver);
            string StreetField = Page_PersonCoreDemographics.GetStreetValue(driver);
            string OthDesField = Page_PersonCoreDemographics.GetOtherDesignationValue(driver);
            string CityField = Page_PersonCoreDemographics.GetCityValue(driver);
            string CountyField = Page_PersonCoreDemographics.GetCountyValue(driver);
            string PostCodeField = Page_PersonCoreDemographics.GetPostCodeValue(driver);
            Assert.IsTrue(StreetField.Contains(Street));
            Assert.IsTrue(OthDesField.Contains(OtherDes));
            Assert.IsTrue(CityField.Contains(City));
            Assert.IsTrue(CountyField.Contains(County));
        }
    }
}
