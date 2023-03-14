using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.Dynamics365.UIAutomation.Sample.Extentions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace WCCIS.specs.StepDefinitions
{
    [Binding]
    public class PersonCreateStepDefinitions
    {

        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;
        public string lastname { get; set; }

        public PersonCreateStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
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


        [When(@"a person is created by completing mandatory fields only (.*) and (.*) and (.*) and (.*) and (.*)")]
        public string WhenAPersonIsCreatedByCompletingMandatoryFieldsOnlyJohnAndAndAndAfricanAndMale(string firstname, string dob, string dateMovedIn, string ethnicity, string gender)
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
            // generate a random string for surname
            String lastname = DHCWExtentions.RandomString(6, true);
            driver.FindElement(By.Id("lastname_i")).SendKeys(lastname);
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid\"]/div[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid_ledit\"]")).SendKeys(ethnicity);
            xrmBrowser.ThinkTime(1000);
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
            return lastname;
            
        }


        [When(@"a person is created by completing mandatory fields only Alice,(.*)/(.*)/(.*),English,Female")]
        public void WhenAPersonIsCreatedByCompletingMandatoryFieldsOnlyAliceEnglishFemale(string firstname, string dob, string dateMovedIn, string ethnicity, string gender)
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
            // generate a random string for surname
            String s1 = DHCWExtentions.RandomString(6, true);
            driver.FindElement(By.Id("lastname_i")).SendKeys(s1);
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid\"]/div[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_ethnicityid_ledit\"]")).SendKeys(ethnicity);
            xrmBrowser.ThinkTime(1000);
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
        }

        [Then(@"new person can be returned in a search (.*) and (.*) and (.*)")]
        public void ThenNewPersonCanBeReturnedInASearchJohnAndAndLastname(string firstname, string dob, string s1)
        {
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtLastName")).SendKeys(s1);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtDOB")).SendKeys(dob);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(4000);
        }
    }
}
