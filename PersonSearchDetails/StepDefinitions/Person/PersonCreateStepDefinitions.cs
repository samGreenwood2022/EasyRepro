using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.Dynamics365.UIAutomation.Sample.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PersonSearchDetails.PageObjects;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;
using WCCIS.Specs.PageObjects;
using static WCCIS.Specs.Enums.Enums;

namespace WCCIS.specs.StepDefinitions
{
    [Binding]
    public class PersonCreateStepDefinitions
    {

        //THE SPECFLOW STEP DEFINITIONS SHOULD CONTAIN THE GROUPING OF TEST STEPS AND HOW THOSE MAP TO THE USER STORY STATEMENTS

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


        //Can we give this field default values? The specflow might make this challenging...
        [When(@"a person is created by completing mandatory fields only (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenAPersonIsCreatedByCompletingMandatoryFieldsOnly(string firstName, string dob, string dateMovedIn, string ethnicity, string gender, string preferredLanguage)
        {
            // generate a random string for surname, false or true sets the string to upper or lower case
            lastName = DHCWExtensions.RandomString(6, false);
            
            //Open New Person Window
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
            driver.SwitchTo().Window(driver.WindowHandles.Last());


            xrmBrowser.ThinkTime(1000);
            // select the correct iFrame
            driver.SwitchTo().Frame("contentIFrame1");
            xrmBrowser.ThinkTime(1000);
            driver.WaitForPageToLoad();

            Page_PersonCoreDemographics.EnterFirstName(driver, firstName);
            Page_PersonCoreDemographics.EnterLastName(driver, lastName);
            Page_PersonCoreDemographics.EnterEthnicity(driver, ethnicity);
            Page_PersonCoreDemographics.EnterPreferredLanguage(driver, preferredLanguage);
            Page_PersonCoreDemographics.EnterGender(driver, gender);
            Page_PersonCoreDemographics.EnterDateOfBirth(driver, dob);
            Page_PersonCoreDemographics.EnterDateMovedIn(driver, dateMovedIn);

            // save the record
            xrmBrowser.CommandBar.ClickCommand("SAVE");
            xrmBrowser.ThinkTime(3000);


        }

        [Then(@"new person can be returned in a search (.*) and (.*)")]
        public void ThenNewPersonCanBeReturnedInASearch(string firstname, string dob)
        {
            // search for our person
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.WaitForPageToLoad();
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
            driver.WaitForPageToLoad();
            driver.WaitUntilVisible(By.XPath("//*[@id=\"createdby_lookupValue\"]"));
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
        public void WhenICreateTwoPeopleUsingTheSameDetails(string firstName, string dob, string dateMovedIn, string ethnicity, string gender, string preferredLanguage)
        {
            // generate a random string for surname, false or true sets the string to upper or lower case
            lastName = DHCWExtensions.RandomString(6, false);

            for (int i= 0; i<2; i++)
            {
                //Create SharedNavigation method for "open new person"
                xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
                xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
                //Switch back to main window after opening new person
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                // select the correct iFrame - this should be refactored out in the future
                driver.SwitchTo().Frame("contentIFrame1");


                driver.WaitForPageToLoad();
                Page_PersonCoreDemographics.EnterFirstName(driver, firstName);
                Page_PersonCoreDemographics.EnterLastName(driver, lastName);
                Page_PersonCoreDemographics.EnterEthnicity(driver, ethnicity);
                Page_PersonCoreDemographics.EnterPreferredLanguage(driver, preferredLanguage);
                Page_PersonCoreDemographics.EnterGender(driver, gender);
                Page_PersonCoreDemographics.EnterDateOfBirth(driver, dob);
                Page_PersonCoreDemographics.EnterDateMovedIn(driver, dateMovedIn);

                // save the record
                //Note that we have had to use a custom save function elsewhere
                xrmBrowser.CommandBar.ClickCommand("SAVE");
                //xrmBrowser.ThinkTime(3000);
                Console.WriteLine(lastName);
            }
        }


        [Then(@"the duplicate detection rules will trigger")]
        public void ThenTheDuplicateDetectionRulesWillTrigger()
        {
            //On the person page
            driver.WaitUntilAvailable(By.Id("InlineDialog_Iframe"));
            driver.SwitchTo().Frame("id = \"InlineDialog_Iframe\"");
            xrmBrowser.ThinkTime(1000);

            //Locate the error element and pull back the text
            //This needs a new name and some description
            String errorTextd = driver.FindElement(By.XPath("//*[@id=\"ErrorTitle\"]")).Text;
            xrmBrowser.ThinkTime(1000);

            //Confirm Duplicate record is the text pulled back
            //Query: Is this too brittle?
            Assert.AreEqual(errorTextd, "Duplicate Record");
            xrmBrowser.ThinkTime(1000);

            //This is clicking the same element as before
            driver.FindElement(By.XPath("//*[@id=\"ErrorTitle\"]")).Click();


            //this is now clicking a new element - what is it?
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
            // set field we want to check to be ethnicity
            PersonMandatoryFields fieldWeWant = PersonMandatoryFields.ethnicity;
            // determine if ethnicity is mandatory
            bool isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, fieldWeWant);
            // ensure the validation message displayed is for the expected field
            Assert.IsTrue(isErrorBoxFound);

            // this can be partially refactored

            // add a value to the field so we can test validation on the next field
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid_ledit\"]")).SendKeys("African");
            xrmBrowser.CommandBar.ClickCommand("Save");

            // test the next validation message 
            fieldWeWant = PersonMandatoryFields.preferredLanguage;
            // determine if preferredLanguage is mandatory
            isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, fieldWeWant);
            // ensure the validation message displayed is for the expected field
            Assert.IsTrue(isErrorBoxFound);
            // enter value into preferred language field so we can test validation on the next field
            driver.FindElement(By.XPath("//*[@id=\"cw_languageid_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_languageid_ledit\"]")).SendKeys("Welsh");
            xrmBrowser.CommandBar.ClickCommand("Save");
            xrmBrowser.ThinkTime(1000);

            // set field we want to check to be lastName
            fieldWeWant = PersonMandatoryFields.lastName;
            // determine if lastName is mandatory
            isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, fieldWeWant);
            // ensure the validation message displayed is for the expected feld
            Assert.IsTrue(isErrorBoxFound);
            // enter a value into the lastName field so we can test validation on the next field
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"lastname_warn\"]")).Click();
            driver.FindElement(By.Id("lastname_i")).SendKeys("Test");
            xrmBrowser.ThinkTime(1000);
            xrmBrowser.CommandBar.ClickCommand("Save");
            xrmBrowser.ThinkTime(1000);

            // set field we want to check to be gender
            fieldWeWant = PersonMandatoryFields.gender;
            // determine if gender is mandatory
            isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, fieldWeWant);
            // ensure the validation message displayed is for the expected 
            Assert.IsTrue(isErrorBoxFound);
            // Select the first value from the gender picklist
            driver.FindElement(By.XPath("//*[@id=\"gendercode\"]")).Click();
            var dropDownOption = driver.FindElement(By.XPath("//*[@id=\"gendercode_i\"]"));
            var selectElement = new SelectElement(dropDownOption);
            selectElement.SelectByText("Male");
            // xrmBrowser.CommandBar.ClickCommand("Save");
            xrmBrowser.ThinkTime(1000);

            // set field we want to check to be gender
            fieldWeWant = PersonMandatoryFields.movedInDate;
            // determine if movedInDate is mandatory
            isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, fieldWeWant);
            // ensure the validation message displayed is for the expected 
            Assert.IsTrue(isErrorBoxFound);
            // switch to the correct iFrame
            // driver.SwitchTo().Frame("contentIFrame1");
            xrmBrowser.ThinkTime(2000);
            // enter a value into the date person moved in field so we can test validation on the next field
            driver.FindElement(By.XPath("//*[@id=\"cw_datepersonmovedin_iDateInput\"]")).SendKeys("01/01/2000");
            xrmBrowser.ThinkTime(1000);

            // set field we want to check to be dob in
            fieldWeWant = PersonMandatoryFields.dob;
            // determine if dob is mandatory
            isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, fieldWeWant);
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

            Page_PersonCoreDemographics.EnterFirstName(driver, "TestX");

            // generate a random string for surname, false or true sets the string to upper or lower case
            lastName = DHCWExtensions.RandomString(6, false);
            Page_PersonCoreDemographics.EnterLastName(driver, lastName);

            //-------------------
            Page_PersonCoreDemographics.EnterNHSNumber(driver);

            //-------------------
            Page_PersonCoreDemographics.EnterEthnicity(driver, "African");

            // enter value into preferred language field
            Page_PersonCoreDemographics.EnterPreferredLanguage(driver, "English");

            // Select the value from the gender picklist
            Page_PersonCoreDemographics.EnterGender(driver, "Male");

            // enter a value into the dob field
            Page_PersonCoreDemographics.EnterDateOfBirth(driver, "12/10/1976");

            //Enter Date Moved In
            Page_PersonCoreDemographics.EnterDateMovedIn(driver, "01/01/2000");

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

    }


}
