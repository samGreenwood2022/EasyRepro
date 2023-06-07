using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.PageObjects.Person;

namespace WCCIS.specs.StepDefinitions
{
    [Binding]
    public class PersonSearchStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;
     
        public PersonSearchStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            driver = webDriver;
            xrmBrowser= browser;    
        }

        [Given(@"that i login with a username & password")]
        public void GivenThatILoginWithAUsernamePassword()
        {
            // removes any popups displayed when we 1st log in
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
            // verify the care director logo is displayed
            driver.FindElement(By.XPath("//*[@id=\"navTabLogoTextId\"]/img"));
        }

        [When(@"i perform a person search using firstname '([^']*)', lastname '([^']*)' & dob '([^']*)'")]
        public void WhenIPerformAPersonSearchUsingFirstnameLastnameDob(string firstName, string lastName, string dob)
        {
            //Select Person Search
            //Note the clickign person search should be a shared command and not on the person search page object
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            //Enter first name
            Page_PersonSearch.EnterFirstName(driver, firstName);
            //Enter last name
            Page_PersonSearch.EnterLastName(driver, lastName);
            //Enter Date of Birth (Not via calendar)
            Page_PersonSearch.EnterDateOfBirth(driver, dob);
            //Select Search 
            Page_PersonSearch.ClickSearch(driver);
        }

        [Then(@"the returned record will show the correct name, id, dob & address")]
        public void ThenTheReturnedRecordWillShowTheCorrectNameIdDobAddress()
        {
            //Actions act = new Actions(driver);
            ////Double CLick the Returned Patient
            Page_PersonSearch.DoubleClickSearchResult(driver, "4074401");
            xrmBrowser.ThinkTime(3000);

            //NAVIGATE TO PERSON ENTITY (EXISTING) WINDOW
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));


            //Check Banner iframe for an element containing Name & Date Of Birth
            //These methods will end up parameterised
            //The banner here should be it's own page object, it appears on multiple pages 
            //Whichever pages have the banner should inherit the banner page object
            driver.FindElement(By.XPath("//*[text()='ZJYIGN, John (WCCIS ID: 4074401)']"));
            //Check Banner iframe for an element containing  Address line 1
            driver.FindElement(By.XPath("//*[text()='137 Clydesdale Road']"));
            //Check Banner iframe for an element containing address line 2
            driver.FindElement(By.XPath("//*[text()='Newcastle Upon Tyne Tyne and Wear']"));
            //Check Banner iframe for an element containing DOB
            driver.FindElement(By.XPath("//*[text()[contains(.,'12/08/1976')]]"));
        }


        [When(@"i perform a person search using a wildcards '([^']*)', '([^']*)' & dob '([^']*)'")]
        public void WhenIPerformAPersonSearchUsingAWildcardsDob(string firstLetter, string secondLetter, string dob)
        {
            //Person Search could be extracted to the ribbon inherited commands. This might be a lower concern considering it's handled by EasyRepro
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);

            //NAVIGATE TO PERSON SEARCH WINDOW

            //Send "firstletter" to first name field 
            //Rename the fieldname for parameter firstletter
            Page_PersonSearch.EnterFirstName(driver, firstLetter);

            //Send "secondletter" to second name field 
            //Rename the field for parameter secondLetter
            Page_PersonSearch.EnterLastName(driver, secondLetter);

            //Send "dob" to date of birth field 
            Page_PersonSearch.EnterDateOfBirth(driver, dob);

            //This needs some definition - what is btnFind
            Page_PersonSearch.ClickSearch(driver);

            //NAVIGATE TO PERSON SEARCH RESULTS WINDOW
            Page_PersonSearch.DoubleClickSearchResult(driver, "4074401");
            xrmBrowser.ThinkTime(2000);
        }

        [When(@"i perform a person search using a person id '([^']*)'")]
        public void WhenIPerformAPersonSearchUsingAPersonId(string personId)
        {
            // need to pass the person id so other methods can use it in this script
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);

            //Enter value into personID field
            Page_PersonSearch.EnterPersonID(driver, personId);

            //Commit the search with a click
            Page_PersonSearch.ClickSearch(driver);

            //Click a row based on the person ID
            //To check if this can be used with other fields (e.g. name, DOB)

            Page_PersonSearch.DoubleClickSearchResult(driver, personId);
        }
    }
}
