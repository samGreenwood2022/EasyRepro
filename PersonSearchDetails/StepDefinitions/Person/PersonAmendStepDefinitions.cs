using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PersonSearchDetails.PageObjects;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects;

namespace WCCIS.specs.StepDefinitions
{
    [Binding]
    public class PersonAmendStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;
        public string lastName { get; set; }
        // public string personId { get; set; }
        public string dateMovedIn { get; set; }

        public string propertyNo = "137";
        public string street = "Clydesdale Road";
        public string townCity = "Newcastle Upon Tyne";
        public string county = "Tyne and Wear";
        public string postCode = "NE6 2EQ";


        public PersonAmendStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webbrowser (defined in the Hooks) to be used by all methods in this class
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }


        /////a known person already exists in the system <firstname> and <dob> and <dateMovedIn> and <ethnicity> and <gender> and <preferredLanguage>

        [Given(@"a known person already exists in the system (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void GivenAKnownPersonAlreadyExistsInTheSystem(string firstname, string dob, string dateMovedIn, string ethnicity, string gender, string preferredLanguage)
        {

            // This method is technically wrong - it should be using a static reference patient and not creating a new one
            // It is missing the opportunity to find any issues when opening legacy data - which is what the userstory seems to suggest

            // Create a new person - can we call the  method 'When a person is created by completing mandatory fields only'
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            // select the correct iFrame
            driver.SwitchTo().Frame("contentIFrame1");

            xrmBrowser.ThinkTime(1000);
            Page_PersonCoreDemographics.EnterFirstName(driver, firstname);
            
            // generate a random string for surname
            lastName = DHCWExtensions.RandomString(6, false);
            Page_PersonCoreDemographics.EnterLastName(driver, lastName);
            Page_PersonCoreDemographics.EnterEthnicity(driver, ethnicity);

            // enter value into preferred language field
            Page_PersonCoreDemographics.EnterPreferredLanguage(driver, preferredLanguage);
            // Select the first value from the gender picklist
            Page_PersonCoreDemographics.EnterGender(driver, gender);

            //selectElement.SelectByIndex(0);
            xrmBrowser.ThinkTime(1000);
            // enter a value into the dob field
            Page_PersonCoreDemographics.EnterDateOfBirth(driver, dob);

            Page_PersonCoreDemographics.EnterDateMovedIn(driver, dateMovedIn);

            // add an address (currently hard coded above)
            // DHCWExtensions.enterAddressDetails(xrmBrowser, driver, propertyNo, street, townCity, county, postCode);
            PersonMethods.enterAddressDetails(xrmBrowser, driver, propertyNo, street, townCity, county, postCode);

            xrmBrowser.ThinkTime(4000);
            Console.WriteLine(lastName);

            // search for our person, the search person method should be called from here
            // DHCWExtensions.personSearch(xrmBrowser, driver, firstname, lastname, dob);
            PersonMethods.personSearch(xrmBrowser, driver, firstname, lastName, dob);


        }

        [When(@"i amend a persons primary address details (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenIAmendAPersonsPrimaryAddressDetails(string propertyNo, string street, string townCity, string county, string postCode)
        {
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.Id("FormSecNavigationControl-Icon")).Click();
            driver.FindElement(By.XPath("//*[@id=\"flyoutFormSection_Cell\"]")).Click();
            xrmBrowser.ThinkTime(2000);

            //Create a clear details
            driver.FindElement(By.XPath("//*[@id=\"Date Person moved in_label\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_datepersonmovedin_iDateInput\"]")).Clear();

            Page_PersonCoreDemographics.EnterDateMovedIn(driver, "01/01/2010");
            // DHCWExtensions.enterAddressDetails(xrmBrowser, driver, propertyNo, street, townCity, county, postcode);
            PersonMethods.enterAddressDetails(xrmBrowser, driver, propertyNo, street, townCity, county, postCode);
            xrmBrowser.ThinkTime(1000);
            // xrmBrowser.CommandBar.ClickCommand("SAVE");
        }

        [Then(@"Then the new address will replace the old address on the persons record (.*) and (.*)")]
        public void ThenTheNewAddressWillReplaceTheOldAddressOnThePersonsRecord(string firstName, string dob)
        {
            // call our personSearch method
            string personId = DHCWExtensions.personSearch(xrmBrowser, driver, firstName, lastName, dob);

            // switch tio the correct browser window and iFrame we want to use
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));
            // verify our lastname, firstname and id is correct, then store in a string so we can see what it is
            String concatName = driver.FindElement(By.XPath("//*[text()='" + lastName + ", " + firstName + " (WCCIS ID: " + personId + ")']")).Text;
            // write the string to the console so we can see whats in it, handy for debugging
            Console.WriteLine(concatName);
            //possibly remove the below line as the the test is being performed above
            driver.FindElement(By.XPath("//*[text()='" + lastName + ", " + firstName + " (WCCIS ID: " + personId + ")']"));
            //search for our dob value within the iframe
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + dob + "')]]"));
        }
    }
}