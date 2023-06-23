using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchForValidHospNoAndAssigningAuthorityStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchForValidHospNoAndAssigningAuthorityStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [When(@"an MPI search is attempted with Hospital Number '([^']*)' and Assigning Authority '([^']*)'")]
        public void WhenAnMPISearchIsAttemptedWithHospitalNumberAndAssigningAuthority(string HospNo, string AssignAuth)
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
            driver.FindElement(By.XPath("//*[@id=\"txtSourceID\"]")).SendKeys(HospNo);
            xrmBrowser.ThinkTime(3000);
            driver.FindElement(By.XPath("//*[@id=\"ddlSourceCode\"]")).Click();
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@value=\""+ AssignAuth +"\"]")).Click();
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(100000);
        }
    }
}
