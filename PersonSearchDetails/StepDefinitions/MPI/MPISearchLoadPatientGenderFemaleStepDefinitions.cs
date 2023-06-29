using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchLoadPatientGenderFemaleStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchLoadPatientGenderFemaleStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [Given(@"an MPI Search is conducted with NHS number '([^']*)'")]
        public void GivenAnMPISearchIsConductedWithNHSNumber(string NHSNumber)
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
            xrmBrowser.ThinkTime(8000);
        }

        [When(@"the patient record is loaded with NHS number '([^']*)'")]
        public void WhenThePatientRecordIsLoadedWithNHSNumber(string NHSNumber)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(90000);
            driver.FindElement(By.XPath("//table/tbody/tr/td[@title='" + NHSNumber + "']"));
            xrmBrowser.ThinkTime(1000);
            Actions act = new Actions(driver);
            IWebElement result = driver.FindElement(By.XPath("//table/tbody/tr/td[@title='" + NHSNumber + "']"));
            act.DoubleClick(result).Perform();
            xrmBrowser.ThinkTime(5000);
        }

        [Then(@"the patient Gender field contains value '([^']*)'")]
        public void ThenThePatientGenderFieldContainsValue(string gender)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(3000);
            driver.SwitchTo().Frame("contentIFrame0");
            String NHSField = driver.FindElement(By.Id("gendercode")).Text;
            xrmBrowser.ThinkTime(2000);
            Assert.IsTrue(NHSField.Contains(gender));
        }

    }
}
