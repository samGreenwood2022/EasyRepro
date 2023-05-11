using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PersonSearchDetails.PageObjects;
using System;
using System.Collections.Generic;
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

        public string lastName { get; set; }
        public string personId { get; set; }

        public PersonCreateStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webbrowser (defined in the Hooks) to be used by all methods in this class
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [When(@"a person is created by completing mandatory fields only (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenAPersonIsCreatedByCompletingMandatoryFieldsOnly(string firstname, string dob, string dateMovedIn, string ethnicity, string gender, string preferredLanguage)
        {
            // generate a random string for surname, false or true sets the string to upper or lower case
            lastName = DHCWExtensions.RandomString(6, false);
            // create our first person
            PersonMethods.CreateBasicPerson(xrmBrowser, driver, firstname, dob, dateMovedIn, ethnicity, gender, preferredLanguage, lastName);

        }

        [Then(@"new person can be returned in a search (.*) and (.*)")]
        public void ThenNewPersonCanBeReturnedInASearch(string firstname, string dob)
        {
            // search for our person
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtLastName")).SendKeys(lastName);
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
            String concatName = driver.FindElement(By.XPath("//*[text()='" + lastName + ", " + firstname + " (WCCIS ID: " + personId + ")']")).Text;
            // write the string to the console so we can see whats in it, handy for debugging
            Console.WriteLine(concatName);
            //possibly remove the below line as the the test is being performed above
            driver.FindElement(By.XPath("//*[text()='" + lastName + ", " + firstname + " (WCCIS ID: " + personId + ")']"));
            //search for our dob value within the iframe
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + dob + "')]]"));

        }

        [Then(@"the expected audit events would be created")]
        public void ThenTheExpectedAuditEventsWouldBeCreated()
        {
            xrmBrowser.ThinkTime(1000);
            // select 'audit information' from person record
            DHCWExtensions.selectFormSectionsMenu(driver, xrmBrowser, "audit information");
            xrmBrowser.ThinkTime(1000);
            // gets the value of the created by field
            var createdBy = driver.FindElement(By.XPath("//*[@id=\"createdby_lookupValue\"]")).Text;
            // writes the value of userId to the console
            Console.WriteLine(createdBy);
            // perform an assertion to ensure userId is as expected
            Assert.AreEqual(createdBy, "CCIS Test55");
            xrmBrowser.ThinkTime(1000);

            // gets the value of the created by field
            string createdDate = driver.FindElement(By.XPath("//*[@id=\"Created On_label\"]")).Text;
            // get letters 0-10 of the createdDate string
            string shortDate = createdDate.Substring(0, 10);
            // get todays date and store in the same format as the shortDate string
            var todaysDate = DateTime.Now.ToString("dd/MM/yyyy");
            Assert.AreEqual(shortDate, todaysDate);
            xrmBrowser.ThinkTime(2000);

        }

        [When(@"i create two people using the same details (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenICreateTwoPeopleUsingTheSameDetails(string firstname, string dob, string dateMovedIn, string ethnicity, string gender, string preferredLanguage)
        {
            // generate a random string for surname, false or true sets the string to upper or lower case
            lastName = DHCWExtensions.RandomString(6, false);
            // create our first person
            PersonMethods.CreateBasicPerson(xrmBrowser, driver, firstname, dob, dateMovedIn, ethnicity, gender, preferredLanguage, lastName);
            // create the 2nd person using the same details as above
            PersonMethods.CreateBasicPerson(xrmBrowser, driver, firstname, dob, dateMovedIn, ethnicity, gender, preferredLanguage, lastName);
            
        }


        [Then(@"the duplicate detection rules will trigger")]
        public void ThenTheDuplicateDetectionRulesWillTrigger()
        {
            driver.SwitchTo().Frame("id = \"InlineDialog_Iframe\"");
            xrmBrowser.ThinkTime(1000);
            String errorTextd = driver.FindElement(By.XPath("//*[@id=\"ErrorTitle\"]")).Text;
            xrmBrowser.ThinkTime(1000);
            Assert.AreEqual(errorTextd, "Duplicate Record");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"ErrorTitle\"]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"Duplicate detect rules popup\"]")).Click();
            Console.WriteLine("Duplicate detection rules currently not in place");
        }

        [When(@"i start the process of creating a new person")]
        public void WhenIStartTheProcessOfCreatingANewPerson()
        {
            // begin start the  process of creating a new person
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            // select the correct iFrame
            driver.SwitchTo().Frame("contentIFrame1");
            xrmBrowser.ThinkTime(1000);
        }


        [Then(@"the expected mandatory fields are active")]
        public void ThenTheExpectedMandatoryFieldsAreActive()
        {
            bool isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, "ethnicity");
            // ensure the validation message displayed is for the expected 
            Assert.IsTrue(isErrorBoxFound);

            // add a value to the field so we can test validation on the next field
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid_ledit\"]")).SendKeys("African");
            xrmBrowser.ThinkTime(1000);
            xrmBrowser.CommandBar.ClickCommand("Save");
            xrmBrowser.ThinkTime(1000);
            // test the next validation message 
            isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, "preferredLanguage");
            Assert.IsTrue(isErrorBoxFound);


        }

        [When(@"i've created a new person with an NHS Number")]
        public void WhenIveCreatedANewPersonWithAnNHSNumber()
        {
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            // select the correct iFrame
            driver.SwitchTo().Frame("contentIFrame1");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"firstname\"]/div[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"firstname_i\"]")).SendKeys("TestX");
            driver.FindElement(By.XPath("//*[@id=\"lastname\"]/div[1]")).Click();
            // generate a random string for surname, false or true sets the string to upper or lower case
            lastName = DHCWExtensions.RandomString(6, false);
            driver.FindElement(By.Id("lastname_i")).SendKeys(lastName);
            //-------------------
            // add NHS number
            // generate a random number 1st
            var number = DHCWExtensions.ReturnNHSNumber();
            // convert to a string so we can type it into out field
            string nhsNumber = number.ToString();
            driver.FindElement(By.XPath("//*[@id=\"cw_nhsno_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_nhsno_i\"]")).SendKeys(nhsNumber);
            driver.FindElement(By.XPath("//*[@id=\"cw_nhsno_i\"]")).SendKeys(Keys.Enter);
            xrmBrowser.ThinkTime(1000);
            //-------------------
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid\"]/div[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid_ledit\"]")).SendKeys("African");
            xrmBrowser.ThinkTime(1000);
            // enter value into preferred language field
            driver.FindElement(By.XPath("//*[@id=\"cw_languageid_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_languageid_ledit\"]")).SendKeys("English");
            // Select the first value from the gender picklist
            driver.FindElement(By.XPath("//*[@id=\"gendercode\"]")).Click();
            var dropDownOption = driver.FindElement(By.XPath("//*[@id=\"gendercode_i\"]"));
            var selectElement = new SelectElement(dropDownOption);
            selectElement.SelectByText("Male");
            //selectElement.SelectByIndex(0);
            xrmBrowser.ThinkTime(1000);
            // enter a value into the dob field
            driver.FindElement(By.XPath("//*[@id=\"Date of Birth_label\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"birthdate_iDateInput\"]")).SendKeys("12/10/1976");
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.XPath("//*[@id=\"Date Person moved in_label\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_datepersonmovedin_iDateInput\"]")).SendKeys("01/01/2000");
            xrmBrowser.ThinkTime(1000);
            // save the record
            xrmBrowser.CommandBar.ClickCommand("SAVE");
            xrmBrowser.ThinkTime(3000);
            Console.WriteLine(lastName);
        }

        [Then(@"check to see if the NHS Number field is blank")]
        public void ThenCheckToSeeIfTheNHSNumberFieldIsBlank()
        {
            driver.FindElement(By.XPath("//*[@id=\"cw_nhsno_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_nhsno_i\"]")).SendKeys("abcd");
            driver.FindElement(By.XPath("//*[@id=\"cw_languageid_cl\"]")).Click();
            string titleValue = driver.FindElement(By.XPath("//*[@id=\"NHS No_label\"]")).Text;
            Console.WriteLine(titleValue);
            Assert.AreEqual("--", titleValue);
            

        }

        public class PersonMandatoryFields
        {
            public static string ethnicity = "ethnicity";
            public static string preferredLanguage = "preferredLanguage";

        }

    }


}
