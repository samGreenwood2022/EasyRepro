using Microsoft.Dynamics365.UIAutomation.Api;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace PersonSearchDetails.StepDefinitions
{
    [Binding]
    public class PersonSearchVerifyRecordStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public PersonSearchVerifyRecordStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            driver = webDriver;
            xrmBrowser = browser;
        }

        [Given(@"that i've logged in as a Test Administrator")]
        public void GivenThatIveLoggedInAsATestAdministrator()
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

        [When(@"when i search for a person")]
        public void WhenWhenISearchForAPerson()
        {
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys("Billy");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtLastName")).SendKeys("Test");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtDOB")).SendKeys("12/08/1976");
            xrmBrowser.ThinkTime(1000);

            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(2000);
            xrmBrowser.ThinkTime(2000);
            Actions act = new Actions(driver);

            IWebElement row = driver.FindElement(By.XPath("//*[text()='4073889']"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(5000);
        }

        [Then(@"the expected record will be displayed on screen")]
        public void ThenTheExpectedRecordWillBeDisplayedOnScreen()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));
            driver.FindElement(By.XPath("//*[text()='TEST, Billy (WCCIS ID: 4073889)']"));
            driver.FindElement(By.XPath("//*[text()='12/08/1976 (46 Years)']"));
            driver.FindElement(By.XPath("//*[text()='11 GRANGE STREET']"));
            driver.FindElement(By.XPath("//*[text()='PORT TALBOT ']"));
            driver.FindElement(By.XPath("//*[text()='SA13 1EN']"));
            xrmBrowser.ThinkTime(5000);
        }
    }
}
