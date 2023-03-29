using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace WCCIS.specs.StepDefinitions
{
    [Binding]
    public class PersonCreateStepDefinitions
    {

        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;
        public string lastname { get; set; }
        public string personId { get; set; }

        public PersonCreateStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webbrowser (defined in the Hooks) to be used by all methods in this class
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [Given(@"that i've logged in as an administrator")]
        public void GivenThatIveLoggedInAsAnAdministrator()
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
               // check to ensure the caredirector logo is displayed
            driver.FindElement(By.XPath("//*[@id=\"navTabLogoTextId\"]/img"));
        }


        [When(@"a person is created by completing mandatory fields only (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenAPersonIsCreatedByCompletingMandatoryFieldsOnly(string firstname, string dob, string dateMovedIn, string ethnicity, string gender, string preferredLanguage)
        {
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            // select the correct iFrame
            driver.SwitchTo().Frame("contentIFrame1");
            driver.FindElement(By.XPath("//*[@id=\"firstname\"]/div[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"firstname_i\"]")).SendKeys(firstname);
            driver.FindElement(By.XPath("//*[@id=\"lastname\"]/div[1]")).Click();
            // generate a random string for surname, false or true sets the string to upper or lower case
            lastname = DHCWExtensions.RandomString(6, false);
            driver.FindElement(By.Id("lastname_i")).SendKeys(lastname);
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid\"]/div[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid_ledit\"]")).SendKeys(ethnicity);
            xrmBrowser.ThinkTime(1000);
            // enter value into preferred language field
            driver.FindElement(By.XPath("//*[@id=\"cw_languageid_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_languageid_ledit\"]")).SendKeys(preferredLanguage);


            // Select the first value from the gender picklist
            driver.FindElement(By.XPath("//*[@id=\"gendercode\"]")).Click();
            var dropDownOption = driver.FindElement(By.XPath("//*[@id=\"gendercode_i\"]"));
            var selectElement = new SelectElement(dropDownOption);
            selectElement.SelectByText(gender);
            //selectElement.SelectByIndex(0);
            xrmBrowser.ThinkTime(1000);
            // enter a value into the dob field
            driver.FindElement(By.XPath("//*[@id=\"Date of Birth_label\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"birthdate_iDateInput\"]")).SendKeys(dob);
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.XPath("//*[@id=\"Date Person moved in_label\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_datepersonmovedin_iDateInput\"]")).SendKeys(dateMovedIn);
            xrmBrowser.ThinkTime(1000);
            // save the record
            xrmBrowser.CommandBar.ClickCommand("SAVE & CLOSE");
            xrmBrowser.ThinkTime(3000);
            Console.WriteLine(lastname);
             
        }

        [Then(@"new person can be returned in a search (.*) and (.*)")]
        public void ThenNewPersonCanBeReturnedInASearch(string firstname, string dob)
        {
            // search for our person
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtLastName")).SendKeys(lastname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtDOB")).SendKeys(dob);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(2000);


            // finds the element that stores the person id by searching on a partial id
            // then getting the text value from that element
            String personId = driver.FindElement(By.XPath("//*[contains(@id, 'cw_clientid')]")).Text;
            Console.WriteLine(personId);           
            // the Actions class contains functions like 'doubleClick' which can be used on ui elements
            Actions act = new Actions(driver);
            IWebElement row = driver.FindElement(By.XPath("//*[text()[contains(.,'" + firstname + "')]]"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(2000);
            // switch tio the correct browser window and iFrame we want to use
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));

            // verify our lastname, firstname and id is correct, then store in a string so we can see what it is
            String concatName = driver.FindElement(By.XPath("//*[text()='" + lastname + ", " + firstname + " (WCCIS ID: " + personId + ")']")).Text;
            // write the string to the console so we can see whats in it, handy for debugging
            Console.WriteLine(concatName);
            //possibly remove the below line as the the test is being performed above
            driver.FindElement(By.XPath("//*[text()='" + lastname + ", " + firstname + " (WCCIS ID: " + personId + ")']"));
            //search for our dob value within the iframe
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + dob + "')]]"));

        }
        
    }
}
