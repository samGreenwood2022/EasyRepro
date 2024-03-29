using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PersonSearchDetails.PageObjects;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects;
using WCCIS.Specs.PageObjects.Person;

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



        [Given(@"a known person already exists in the system (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void GivenAKnownPersonAlreadyExistsInTheSystem(string firstName, string dob, string dateMovedIn, string ethnicity, string gender, string preferredLanguage)
        {

            // This method is technically wrong - it should be using a static reference patient and not creating a new one
            // It is missing the opportunity to find any issues when opening legacy data - which is what the userstory seems to suggest

            // Create a new person - can we call the  method 'When a person is created by completing mandatory fields only'
            SharedNavigation.ClickPeople(xrmBrowser);
            SharedNavigation.ClickNewPerson(xrmBrowser);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            // select the correct iFrame
            driver.SwitchTo().Frame("contentIFrame1");

            // enter firstName
            Page_PersonCoreDemographics.EnterFirstName(driver, firstName);

            // generate a random string for surname
            lastName = DHCWExtensions.RandomString(6, false);
            Page_PersonCoreDemographics.EnterLastName(driver, lastName);
            Page_PersonCoreDemographics.EnterEthnicity(driver, ethnicity);

            //Enter value into preferred language field
            Page_PersonCoreDemographics.EnterPreferredLanguage(driver, preferredLanguage);
            //Select the first value from the gender picklist
            Page_PersonCoreDemographics.EnterGender(driver, gender);
            //Enter a value into the dob field
            Page_PersonCoreDemographics.EnterDateOfBirth(driver, dob);
            //Enter a value into the Date Moved In field
            Page_PersonCoreDemographics.EnterDateMovedIn(driver, dateMovedIn);

            // add an address (currently hard coded above)
            // DHCWExtensions.enterAddressDetails(xrmBrowser, driver, propertyNo, street, townCity, county, postCode);
            Page_PersonCoreDemographics.EnterPropertyNumber(driver, propertyNo);
            Page_PersonCoreDemographics.EnterFirstLineOfAddress(driver, street);
            Page_PersonCoreDemographics.EnterTownCity(driver, townCity);
            Page_PersonCoreDemographics.EnterCounty(driver, county);
            Page_PersonCoreDemographics.EnterPostCode(driver, postCode);

            SharedNavigation.ClickSave(driver, xrmBrowser);

            //Eventually refactor this into a sharednavigation class - method OpenPersonSearch
            SharedNavigation.ClickPeople(xrmBrowser);
            SharedNavigation.ClickPersonSearch(driver, xrmBrowser);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);

            Page_PersonSearch.EnterFirstName(driver, firstName);
            Page_PersonSearch.EnterLastName(driver, lastName);
            Page_PersonSearch.EnterDateOfBirth(driver, dob);
            Page_PersonSearch.ClickSearch(driver);

            //assuming the code below will find the box that has the person ID from the search results
            //Then will pull the text from that
            //Then will doubleClick on the box that contains the first name
            //Then the person ID is returned
            //This one needs some thought

            //Double click search results containing <firstname>
            Page_PersonSearchResults.DoubleClickSearchResultContaining(driver, firstName);
            xrmBrowser.ThinkTime(2000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.Close();
            // switch to the correct browser window and iFrame we want to use
            // driver.SwitchTo().Window(driver.WindowHandles.First());
            // driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            // driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));
            xrmBrowser.ThinkTime(2000);
        }

        [When(@"i amend a persons primary address details (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenIAmendAPersonsPrimaryAddressDetails(string propertyNo, string street, string townCity, string county, string postCode)
        {
            //CH Comment = what are these doing? Need to find out and refactor
            //For info, this clicks the menu to the right of the Person label which is displayed when amending a person,
            ////we click the 1st menu option which is 'core demographics', allowing us to amend the address details
            driver.FindElement(By.Id("FormSecNavigationControl-Icon")).Click();
            driver.FindElement(By.XPath("//*[@id=\"flyoutFormSection_Cell\"]")).Click();


            //Create a clear details
            Page_PersonCoreDemographics.ClearDateMovedIn(driver);
            Page_PersonCoreDemographics.EnterDateMovedIn(driver, "01/01/2010");

            Page_PersonCoreDemographics.EnterPropertyNumber(driver, propertyNo);
            Page_PersonCoreDemographics.EnterFirstLineOfAddress(driver, street);
            Page_PersonCoreDemographics.EnterTownCity(driver, townCity);
            Page_PersonCoreDemographics.EnterCounty(driver, county);
            Page_PersonCoreDemographics.EnterPostCode(driver, postCode);

            SharedNavigation.ClickSave(driver, xrmBrowser);



        }

        [Then(@"Then the new address will replace the old address on the persons record (.*) and (.*)")]
        public void ThenTheNewAddressWillReplaceTheOldAddressOnThePersonsRecord(string firstName, string dob)
        {
            SharedNavigation.ClickPeople(xrmBrowser);
            SharedNavigation.ClickPersonSearch(driver, xrmBrowser);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            Page_PersonSearch.EnterFirstName(driver, firstName);
            Page_PersonSearch.EnterLastName(driver, lastName);
            Page_PersonSearch.EnterDateOfBirth(driver, dob);
            Page_PersonSearch.ClickSearch(driver);
            string personId = Page_PersonSearchResults.GetFirstPersonId(driver);
            Page_PersonSearchResults.DoubleClickSearchResult(driver, personId);

            // switch to the correct browser window and iFrame we want to use
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));
            // verify our lastname, firstname and id is correct, then store in a string so we can see what it is
            String concatName = driver.FindElement(By.XPath("//*[text()='" + lastName + ", " + firstName + " (WCCIS ID: " + personId + ")']")).Text;
            // write the string to the console so we can see whats in it
            Console.WriteLine("The concatenated person details are: " + concatName);
            //possibly remove the below line as the the test is being performed above
            driver.FindElement(By.XPath("//*[text()='" + lastName + ", " + firstName + " (WCCIS ID: " + personId + ")']"));
            //search for our dob value within the iframe
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + dob + "')]]"));
        }
    }
}