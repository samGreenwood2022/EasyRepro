using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
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
using WCCIS.Specs.PageObjects.Person;
using static WCCIS.Specs.Enums.MandatoryFields;
using static WCCIS.Specs.Enums.CoreDemographicsDropdownValues;

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
            SharedNavigation.ClickPeople(xrmBrowser);
            SharedNavigation.ClickNewPerson(xrmBrowser);
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

            Page_PersonAdditionalDemographicDetails.OpenAdditionalDemographicDetails(driver);
            Page_PersonAdditionalDemographicDetails.EnterNHSCardLocation(driver, "Home");
            Page_PersonAdditionalDemographicDetails.EnterImmigrationStatus(driver, "Not Known");
            Page_PersonAdditionalDemographicDetails.EnterPlaceOfBirth(driver, "Hospital");

            //Get the integer (or index) of our 
            int valueWeWant = (int) LivesAloneValues.yes;

            Page_PersonAdditionalDemographicDetails.EnterLivesAlone(driver, valueWeWant);
            Page_PersonAdditionalDemographicDetails.EnterDOBPre1900(driver, "18/04/1900");
            Page_PersonAdditionalDemographicDetails.EnterLMPConfirmedBy(driver, "Last Menstrual Period (LMP) date as stated by the mother");
            Page_PersonAdditionalDemographicDetails.EnterTeenageParent(driver, "No");
            Page_PersonAdditionalDemographicDetails.EnterDaysGestation(driver, "burger");
            Page_PersonAdditionalDemographicDetails.EnterExpectedDateOfBirth(driver, "01/01/1976");
            Page_PersonAdditionalDemographicDetails.EnterSigningRequired(driver, "Yes");

            Page_PersonAdditionalDemographicDetails.EnterSSDNumber(driver, "100");
            Page_PersonAdditionalDemographicDetails.EnterNINo(driver, "100");
            Page_PersonAdditionalDemographicDetails.EnterNHSNoPre1995(driver, "100");
            Page_PersonAdditionalDemographicDetails.EnterUniquePupilNo(driver, "100");
            Page_PersonAdditionalDemographicDetails.EnterFormerUniquePupilNo(driver, "200");
            Page_PersonAdditionalDemographicDetails.EnterProfessionalRegistrationNo(driver, "300");

            Page_PersonAdditionalDemographicDetails.EnterCourtCaseNo(driver, "400");
            Page_PersonAdditionalDemographicDetails.EnterBirthCertificateNo(driver, "500");
            Page_PersonAdditionalDemographicDetails.EnterIsExternalPerson(driver, "Yes");
            Page_PersonAdditionalDemographicDetails.EnterHomeOfficeRegistrationNo(driver, "600");
            Page_PersonAdditionalDemographicDetails.EnterUPNUnknownReason(driver, "Child is not looked after and the authority is unable to obtain the UPN");



            // save the record
            SharedNavigation.ClickSave(driver, xrmBrowser);
            xrmBrowser.ThinkTime(1000);


        }

        [Then(@"new person can be returned in a search (.*) and (.*)")]
        public void ThenNewPersonCanBeReturnedInASearch(string firstname, string dob)
        {
            // search for our person
            SharedNavigation.ClickPeople(xrmBrowser);
            SharedNavigation.ClickPersonSearch(driver, xrmBrowser);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.WaitForPageToLoad();

            Page_PersonSearch.EnterFirstName(driver, firstname);
            Page_PersonSearch.EnterLastName(driver, lastName);
            Page_PersonSearch.EnterDateOfBirth(driver, dob);
            Page_PersonSearch.ClickSearch(driver);
            xrmBrowser.ThinkTime(2000);

            // finds the element that stores the person id by searching on a partial id
            // then getting the text value from that element
            String personId = driver.FindElement(By.XPath("//*[contains(@id, 'cw_clientid')]")).Text;    
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
                //Click People, then New Person
                SharedNavigation.ClickPeople(xrmBrowser);
                SharedNavigation.ClickNewPerson(xrmBrowser);
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
                SharedNavigation.ClickSave(driver, xrmBrowser);
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
            SharedNavigation.ClickPeople(xrmBrowser);
            SharedNavigation.ClickNewPerson(xrmBrowser);
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

            // add a value to the field so we can test validation on the next field
            Page_PersonCoreDemographics.EnterEthnicity(driver, "African");
            SharedNavigation.ClickSave(driver, xrmBrowser);

            // set field we want to check to be lastName
            fieldWeWant = PersonMandatoryFields.lastName;
            // determine if lastName is mandatory
            isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, fieldWeWant);
            // ensure the validation message displayed is for the expected feld
            Assert.IsTrue(isErrorBoxFound);
            // enter a value into the lastName field so we can test validation on the next field
            xrmBrowser.ThinkTime(1000);
            Page_PersonCoreDemographics.EnterLastName(driver, "Test");
            xrmBrowser.ThinkTime(1000);
            SharedNavigation.ClickSave(driver, xrmBrowser);
            xrmBrowser.ThinkTime(1000);

            // set field we want to check to be gender
            fieldWeWant = PersonMandatoryFields.gender;
            // determine if gender is mandatory
            isErrorBoxFound = PersonMethods.IsPersonMandatoryFieldValidationErrorPresent(xrmBrowser, driver, fieldWeWant);
            // ensure the validation message displayed is for the expected 
            Assert.IsTrue(isErrorBoxFound);
            // Select the first value from the gender picklist
            Page_PersonCoreDemographics.EnterGender(driver, "Male");
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
            Page_PersonCoreDemographics.EnterDateMovedIn(driver, "01/01/2000");
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
            SharedNavigation.ClickPeople(xrmBrowser);
            SharedNavigation.ClickNewPerson(xrmBrowser);
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
            SharedNavigation.ClickSave(driver, xrmBrowser);
            xrmBrowser.ThinkTime(3000);
        }

        [Then(@"check to see if the NHS Number field is blank")]
        public void ThenCheckToSeeIfTheNHSNumberFieldIsBlank()
        {
            // this method will test that letters cant be submitted into the NHS Number field
            // attempt to submit 'abcd' into the NHS Number field
            Page_PersonCoreDemographics.EnterNHSNumber(driver, "abcd" + Keys.Enter);
            // get the value for the NHS Number field
            string titleValue = driver.FindElement(By.XPath("//*[@id=\"NHS No_label\"]")).Text;
            // we then assert that the NHS number field doesnt contain the letters we previously tried to enter
            Assert.AreEqual("--", titleValue);
            

        }

    }


}
