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
    public class MPISearchBySurnameAndPostcodeStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchBySurnameAndPostcodeStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [When(@"An MPI search is attempted with Surname '([^']*)' and postcode '([^']*)'")]
        public void WhenAnMPISearchIsAttemptedWithSurnameAndPostcode(string Surname, string Postcode)
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
            driver.FindElement(By.XPath("//*[@id=\"txtLastName\"]")).SendKeys(Surname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtPostCode\"]")).SendKeys(Postcode);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(2000);
        }

        [Then(@"a result is returned with values '([^']*)' and '([^']*)'")]
        public void ThenAResultIsReturnedWithValuesAnd(string Surname, string Postcode)
        {
            var tableNotPresent = false;
            try
            {
                IWebElement table = driver.FindElement(By.Id("CWGrid"));
            }
            catch (NoSuchElementException tableNotDisplayed)
            {
                tableNotPresent = true;
            }
            if (tableNotPresent)
            {
                throw new Exception("MPI found no results. Test aborted.");
            }

            // init table element
            IWebElement resultTable = driver.FindElement(By.Id("CWGrid"));

            // init tr elements from the table
            ReadOnlyCollection<IWebElement> allSearchResultRows = resultTable.FindElements(By.TagName("tr"));

            // init searchResult as empty
            IWebElement searchResult = null;

            // loop through each row and check if it contains all the values under test
            foreach (IWebElement resultRow in allSearchResultRows)
            {
                string resultSurname = resultRow.FindElement(By.CssSelector("td[title='" + Surname + "']")).Text;
                string resultPostcode = resultRow.FindElement(By.CssSelector("td[title='" + Postcode + "']")).Text;
                if (resultSurname == Surname && resultPostcode == Postcode)
                {
                    searchResult = resultRow;
                }
                else
                {
                    continue;
                }
            }
            switch (searchResult)
            {
                case null:
                    throw new Exception("No matching results were returned. Test aborted.");
                default:
                    {
                        Actions act = new Actions(driver);
                        act.DoubleClick(searchResult).Perform();
                        xrmBrowser.ThinkTime(5000);
                        break;
                    }
            }
        }

        [Then(@"the result can be opened with the values '([^']*)' and '([^']*)' to create a new record")]
        public void ThenTheResultCanBeOpenedWithTheValuesAndToCreateANewRecord(string Surname, string Postcode)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(3000);
            driver.SwitchTo().Frame("contentIFrame0");
            String surnameField = driver.FindElement(By.Id("lastname")).Text;
            xrmBrowser.ThinkTime(2000);
            String PostCodeField = driver.FindElement(By.Id("address1_postalcode")).Text;
            xrmBrowser.ThinkTime(2000);
            Assert.IsTrue(surnameField.Contains(Surname));
            Assert.IsTrue(PostCodeField.Contains(Postcode));
        }
    }
}
