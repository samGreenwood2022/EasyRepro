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
            xrmBrowser.ThinkTime(4000);

        }

        [Then(@"the returned record will show the correct name, id, dob & address")]
        public void ThenTheReturnedRecordWillShowTheCorrectNameIdDobAddress()
        {
            Actions act = new Actions(driver);

            IWebElement row = driver.FindElement(By.XPath("//*[text()='4073889']"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(3000);
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));
            driver.FindElement(By.XPath("//*[text()='TEST, Billy (WCCIS ID: 4073889)']"));
            driver.FindElement(By.XPath("//*[text()='11 GRANGE STREET']"));
            driver.FindElement(By.XPath("//*[text()='PORT TALBOT ']"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'12/08/1976')]]"));
        }


        [When(@"i perform a person search using a wildcards '([^']*)', '([^']*)' & dob '([^']*)'")]
        public void WhenIPerformAPersonSearchUsingAWildcardsDob(string firstLetter, string secondLetter, string dob)
        {
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstLetter);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtLastName")).SendKeys(secondLetter);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtDOB")).SendKeys(dob);
            xrmBrowser.ThinkTime(1000);

            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(2000);
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
            driver.FindElement(By.XPath("//*[@id=\"txtClientId\"]")).SendKeys(personId);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(2000);
            xrmBrowser.ThinkTime(2000);
            Actions act = new Actions(driver);
            IWebElement row = driver.FindElement(By.XPath("//*[text()='" + personId + "']"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(5000);
        }


    }
}
