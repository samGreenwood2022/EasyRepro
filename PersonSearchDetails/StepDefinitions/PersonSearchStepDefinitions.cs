using BoDi;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.Dynamics365.UIAutomation.Sample;
using Microsoft.Dynamics365.UIAutomation.Sample.Extentions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Security;
using TechTalk.SpecFlow;

namespace WCCIS.specs.StepDefinitions
{
    [Binding]
    public class PersonSearchStepDefinitions
    {
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();

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
            // verify the care director logo is displayed
            driver.FindElement(By.XPath("//*[@id=\"navTabLogoTextId\"]/img"));
        }

        [When(@"i perform a person search using firstname '([^']*)', lastname '([^']*)' & dob '([^']*)'")]
        public void WhenIPerformAPersonSearchUsingFirstnameLastnameDob(string firstname, string lastname, string dob)
        {

            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtLastName")).SendKeys(lastname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtDOB")).SendKeys(dob);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(4000);

        }

        [Then(@"the returned record will show the correct name and id '([^']*)'")]
        public void ThenTheReturnedRecordWillShowTheCorrectNameAndId(string name)
        {
            Actions act = new Actions(driver);

            IWebElement row = driver.FindElement(By.XPath("//*[text()='4073889']"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(5000);
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));
            driver.FindElement(By.XPath("//*[text()='TEST, Billy (WCCIS ID: 4073889)']"));
        }

        [Then(@"the returned record will show the correct house number & street '([^']*)'")]
        public void ThenTheReturnedRecordWillShowTheCorrectHouseNumberStreet(string p0)
        {
            driver.FindElement(By.XPath("//*[text()='11 GRANGE STREET']"));
        }


        [Then(@"the returned record will show the correct town '([^']*)'")]
        public void ThenTheReturnedRecordWillShowTheCorrectAddress(string town)
        {
            driver.FindElement(By.XPath("//*[text()='PORT TALBOT ']"));
        }

        [Then(@"the returned record will show the correct dob '([^']*)'")]
        public void ThenTheReturnedRecordWillShowTheCorrectDob(string dob)
        {
            driver.FindElement(By.XPath("//*[text()='12/08/1976 (46 Years)']"));
        }
    }
}
