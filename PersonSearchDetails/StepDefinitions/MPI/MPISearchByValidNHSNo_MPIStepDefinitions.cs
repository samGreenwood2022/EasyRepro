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
    public class MPISearchByValidNHSNo_MPIStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchByValidNHSNo_MPIStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [Then(@"a patient result is returned with NHS number '([^']*)'")]
        public void ThenAPatientResultIsReturnedWithNHSNumber(string NHSNumber)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(2000);
            driver.FindElement(By.XPath("//table/tbody/tr/td[@title='" + NHSNumber + "']"));
            xrmBrowser.ThinkTime(1000);
        }

        [Then(@"the user is able to open the record with NHS number '([^']*)'")]
        public void ThenTheUserIsAbleToOpenTheRecordWithNHSNumber(string NHSNumber)
        {
            Actions act = new Actions(driver);
            IWebElement result = driver.FindElement(By.XPath("//table/tbody/tr/td[@title='" + NHSNumber + "']"));
            act.DoubleClick(result).Perform();
            xrmBrowser.ThinkTime(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(3000);
            driver.SwitchTo().Frame("contentIFrame0");
            String NHSField = driver.FindElement(By.Id("cw_nhsno")).Text;
            xrmBrowser.ThinkTime(2000);
            NHSField = NHSField.Replace(" ", "");
            xrmBrowser.ThinkTime(2000);
            Assert.IsTrue(NHSField.Contains(NHSNumber));
        }
    }
}
