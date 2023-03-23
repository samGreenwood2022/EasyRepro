using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace PersonSearchDetails.StepDefinitions
{
    [Binding]
    public class PersonAmendStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;
        public string lastname { get; set; }
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

        [Given(@"a known person already exists in the system (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void GivenAKnownPersonAlreadyExistsInTheSystem(string firstname, string dob, string dateMovedIn, string ethnicity, string gender)
        {
            // Create a new person - can we call the  method 'When a person is created by completing mandatory fields only'
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("NEW PERSON");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            // select the correct iFrame
            driver.SwitchTo().Frame("contentIFrame1");
            driver.FindElement(By.XPath("//*[@id=\"firstname\"]/div[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"firstname_i\"]")).SendKeys(firstname);
            driver.FindElement(By.XPath("//*[@id=\"lastname\"]/div[1]")).Click();
            // generate a random string for surname
            lastname = DHCWExtensions.RandomString(6, false);
            driver.FindElement(By.Id("lastname_i")).SendKeys(lastname);
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid\"]/div[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid_ledit\"]")).SendKeys(ethnicity);
            xrmBrowser.ThinkTime(1000);
            // Select the first value from the gender picklist
            driver.FindElement(By.XPath("//*[@id=\"gendercode_cl\"]")).Click();

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
            // add an address (currently hard coded above)
            DHCWExtensions.enterAddressDetails(xrmBrowser, driver, propertyNo, street, townCity, county, postCode);

            //driver.FindElement(By.XPath("//*[@id=\"cw_propertyno_cl\"]")).Click();
            //driver.FindElement(By.XPath("//*[@id=\"cw_propertyno_i\"]")).SendKeys(propertyNo);
            //xrmBrowser.ThinkTime(1000);
            //driver.FindElement(By.XPath("//*[@id=\"address1_line1_cl_span\"]")).Click();
            //driver.FindElement(By.XPath("//*[@id=\"address1_line1_i\"]")).SendKeys(firstLineOfAddress);
            //xrmBrowser.ThinkTime(1000);
            //driver.FindElement(By.XPath("//*[@id=\"address1_postalcode_cl\"]")).Click();
            //driver.FindElement(By.XPath("//*[@id=\"address1_postalcode_i\"]")).SendKeys(postCode);
            // click postcode lookup
            //driver.FindElement(By.XPath("//*[@id=\"address1_postalcodeAddressSearch\"]")).Click();

            xrmBrowser.ThinkTime(1000);
            // save the record
            // xrmBrowser.CommandBar.ClickCommand("SAVE & CLOSE");
            xrmBrowser.ThinkTime(3000);
            Console.WriteLine(lastname);

            // search for our person, the search person method should be called from here
            DHCWExtensions.personSearch(xrmBrowser, driver, firstname, lastname, dob);


        }

        [When(@"i amend a persons primary address details (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void WhenIAmendAPersonsPrimaryAddressDetails(string propertyNo, string street, string townCity, string county, string postcode)
        {
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.Id("FormSecNavigationControl-Icon")).Click();
            driver.FindElement(By.XPath("//*[@id=\"flyoutFormSection_Cell\"]")).Click();
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.XPath("//*[@id=\"Date Person moved in_label\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_datepersonmovedin_iDateInput\"]")).Clear();
            driver.FindElement(By.XPath("//*[@id=\"cw_datepersonmovedin_iDateInput\"]")).SendKeys("01/01/2010");
            DHCWExtensions.enterAddressDetails(xrmBrowser, driver, propertyNo, street, townCity, county, postcode);
            xrmBrowser.ThinkTime(1000);
            // xrmBrowser.CommandBar.ClickCommand("SAVE");
        }

        [Then(@"Then the new address will replace the old address on the persons record (.*) and (.*)")]
        public void ThenTheNewAddressWillReplaceTheOldAddressOnThePersonsRecord(string firstname, string dob)
        {
            // call our personSearch method
            string personId = DHCWExtensions.personSearch(xrmBrowser, driver, firstname, lastname, dob);

            // switch tio the correct browser window and iFrame we want to use
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.SwitchTo().Window(driver.WindowHandles[2]);
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