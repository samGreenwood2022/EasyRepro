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

    public class MPISearchRetryAfterCriteriaMessageStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchRetryAfterCriteriaMessageStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [When(@"an error message contains text '([^']*)'")]
        public void WhenAnErrorMessageContainsText(string errorMessage)
        {
            String error = driver.FindElement(By.XPath("//*[@id=\"CWNotificationMessage_EMPISearch\"]")).Text;
            Console.WriteLine(error);
            Assert.IsTrue(error.Contains(errorMessage));
        }

        [When(@"the user retries the MPI Search with Surname '([^']*)' and Postcode '([^']*)'")]
        public void WhenTheUserRetriesTheMPISearchWithSurnameAndPostcode(string Surname, string Postcode)
        {
            driver.FindElement(By.XPath("//*[@id=\"txtLastName\"]")).SendKeys(Surname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtPostCode\"]")).SendKeys(Postcode);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(2000);
        }
    }
}
