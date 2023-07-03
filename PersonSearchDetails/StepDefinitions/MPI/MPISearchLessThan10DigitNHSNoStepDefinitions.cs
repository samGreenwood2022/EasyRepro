using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchLessThan10DigitNHSNoStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchLessThan10DigitNHSNoStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [Given(@"An administrator has logged in")]
        public void GivenAnAdministratorHasLoggedIn()
        {
            // call our AdministratorLogin method
            UserLogin.AdministratorLogin(xrmBrowser, driver);
                // removes any popups displayed when we 1st log in
                xrmBrowser.ThinkTime(2000);
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

        [When(@"an MPI search is attempted with NHS Number '([^']*)'")]
        public void WhenAnMPISearchIsAttemptedWithNHSNumber(string NHSNumber)
        {
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys("test");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(4000);
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.XPath("//*[@id=\"txtNHSNo\"]")).SendKeys(NHSNumber);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(2000);
        }

        [Then(@"an error message contains text '([^']*)'")]
        public void ThenAnErrorMessageContainsText(string errorMessage)
        {
            String error = driver.FindElement(By.XPath("//*[@id=\"CWNotificationMessage_EMPISearch\"]")).Text;
            Console.WriteLine(error);
            Assert.IsTrue(error.Contains(errorMessage));
        }

    }
}
