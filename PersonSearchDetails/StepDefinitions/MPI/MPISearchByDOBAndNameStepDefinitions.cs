using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Drawing;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchByDOBAndNameStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchByDOBAndNameStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [When(@"an MPI search is attempted with Forename '([^']*)', Surname '([^']*)' and DOB '([^']*)'")]
        public void WhenAnMPISearchIsAttemptedWithForenameSurnameAndDOB(string Forename, string Surname, string DOB)
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
            driver.FindElement(By.XPath("//*[@id=\"txtDOB\"]")).SendKeys(DOB);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(2000);
        }

        [Then(@"a patient result is returned with value '([^']*)'")]
        public void ThenAPatientResultIsReturnedWithValue(string searchValue)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.XPath("//table/tbody/tr/td[@title='" + searchValue + "']"));
            xrmBrowser.ThinkTime(1000);
        }

        [Then(@"the user is able to open the record with Forename '([^']*)', Surname '([^']*)' and DOB '([^']*)'")]
        public void ThenTheUserIsAbleToOpenTheRecordWithForenameSurnameAndDOB(string Forename, string Surname, string DOB)
        {
            Actions act = new Actions(driver);
            IWebElement result = driver.FindElement(By.XPath("//table/tbody/tr/td[@title='" + DOB + "']"));
            act.DoubleClick(result).Perform();
            xrmBrowser.ThinkTime(5000);
        }


        [Then(@"the record contains the value Forename '([^']*)', Surname '([^']*)' and DOB '([^']*)'")]
        public void ThenTheRecordContainsTheValueForenameSurnameAndDOB(string Forename, string Surname, string DOB)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(3000);
            driver.SwitchTo().Frame("contentIFrame0");
            String firstname = driver.FindElement(By.Id("firstname")).Text;
            xrmBrowser.ThinkTime(1000);
            Assert.IsTrue(firstname.Contains(Forename));
            String lastname = driver.FindElement(By.Id("lastname")).Text;
            xrmBrowser.ThinkTime(1000);
            Assert.IsTrue(lastname.Contains(Surname));
            String birthdate = driver.FindElement(By.Id("birthdate")).Text;
            xrmBrowser.ThinkTime(1000);
            Assert.IsTrue(birthdate.Contains(DOB));
        }

    }
}
