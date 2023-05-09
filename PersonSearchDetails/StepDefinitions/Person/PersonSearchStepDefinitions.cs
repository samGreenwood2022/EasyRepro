using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using TechTalk.SpecFlow;

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
        public void WhenIPerformAPersonSearchUsingFirstnameLastnameDob(string firstname, string lastname, string dob)
        {


            //Select Person Search
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            //Enter First Name
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstname);
            xrmBrowser.ThinkTime(1000);
            //Enter last name
            driver.FindElement(By.Name("txtLastName")).SendKeys(lastname);
            xrmBrowser.ThinkTime(1000);
            //Enter Date of Birth (Not via calendar)
            driver.FindElement(By.Name("txtDOB")).SendKeys(dob);
            xrmBrowser.ThinkTime(1000);
            //Select Search 
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(4000);

        }

        [Then(@"the returned record will show the correct name, id, dob & address")]
        public void ThenTheReturnedRecordWillShowTheCorrectNameIdDobAddress()
        {
            Actions act = new Actions(driver);

            //Double CLick the Returned Patient
            IWebElement row = driver.FindElement(By.XPath("//*[text()='4073889']"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(3000);

            //NAVIGATE TO PERSON ENTITY (EXISTING) WINDOW

            //This is all just switching frames etc. to find the banner area
            //Can it not be simplified?
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));


            //Check Banner iframe for an element containing Name & Date Of Birth
            //These methods will end up parameterised
            driver.FindElement(By.XPath("//*[text()='TEST, Billy (WCCIS ID: 4073889)']"));
            //Check Banner iframe for an element containing  Address line 1
            driver.FindElement(By.XPath("//*[text()='11 GRANGE STREET']"));
            //Check Banner iframe for an element containing address line 2
            driver.FindElement(By.XPath("//*[text()='PORT TALBOT ']"));
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
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstLetter);
            xrmBrowser.ThinkTime(1000);

            //Send "secondletter" to second name field 
            //Rename the field for parameter secondLetter
            driver.FindElement(By.Name("txtLastName")).SendKeys(secondLetter);
            xrmBrowser.ThinkTime(1000);

            //Send "dob" to date of birth field 
            driver.FindElement(By.Name("txtDOB")).SendKeys(dob);
            xrmBrowser.ThinkTime(1000);

            //This needs some definition - what is btnFind
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(2000);

            //NAVIGATE TO PERSON SEARCH RESULTS WINDOW

            Actions act = new Actions(driver);

            IWebElement row = driver.FindElement(By.XPath("//*[text()='4073889']"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(4000);
        }

        [When(@"i perform a person search using a person id '([^']*)'")]
        public void WhenIPerformAPersonSearchUsingAPersonId(string personId)
        {
            // need to pass the person id so other methods can use it in this script
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);

            //Enter value into personID field
            driver.FindElement(By.XPath("//*[@id=\"txtClientId\"]")).SendKeys(personId);
            xrmBrowser.ThinkTime(1000);

            //Commit the search with a click
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(2000);
            xrmBrowser.ThinkTime(2000);

            //Click a row based on the person ID
            //To check if this can be used with other fields (e.g. name, DOB)
            Actions act = new Actions(driver);
            IWebElement row = driver.FindElement(By.XPath("//*[text()='" + personId + "']"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(5000);
        }


    }
}
