using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchByTooLongNameStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchByTooLongNameStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [When(@"an MPI search is conducted using the first name '([^']*)' and surname '([^']*)'")]
        public void WhenAnMPISearchIsConductedUsingTheFirstNameAndSurname(string Forename, string Surname)
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
            driver.FindElement(By.XPath("//*[@id=\"NHSNo\"]")).Click();
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(Forename);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtLastName\"]")).SendKeys(Surname);
            xrmBrowser.ThinkTime(1000);
        }

        [Then(@"the MPI search field will allow the special characters but remove excess from first name '([^']*)' and surname '([^']*)'")]
        public void ThenTheMPISearchFieldWillAllowTheSpecialCharactersButRemoveExcessFromFirstNameAndSurname(string Forename, string Surname)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
            //String firstName = driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).Text;
            object firstNameObject = js.ExecuteScript("$('txtFirstName').val()");
            Console.WriteLine(firstNameObject);
            //string firstName = firstNameObject.ToString();
            //Console.WriteLine(firstName);
            xrmBrowser.ThinkTime(1000);
            //Assert.IsTrue(firstName.Length == 50);
            String lastName = driver.FindElement(By.XPath("//*[@id=\"txtLastName\"]")).Text;
            Console.WriteLine(lastName);
            xrmBrowser.ThinkTime(1000);
            //Assert.IsTrue(lastName.Length == 50);
            driver.FindElement(By.XPath("//*[@id=\"txtDOB\"]")).SendKeys("01/01/2000");
            xrmBrowser.ThinkTime(1000);
        }


        [Then(@"no results will be found")]
        public void ThenNoResultsWillBeFound()
        {
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(2000);
            var tableNotPresent = false;
            try
            {
                IWebElement table = driver.FindElement(By.Id("CWGrid"));
            }
            catch
            {
                tableNotPresent = true;
            }
            Assert.IsTrue(tableNotPresent);
        }
    }
}
