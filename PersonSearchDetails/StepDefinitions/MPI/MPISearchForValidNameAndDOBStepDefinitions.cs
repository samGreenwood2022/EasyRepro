using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchForValidNameAndDOBStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchForValidNameAndDOBStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }

        [Then(@"a result is returned with values '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenAResultIsReturnedWithValuesAnd(string firstName, string surname, string DOB)
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
                string resultFirstName = resultRow.FindElement(By.CssSelector("td[title='" + firstName + "']")).Text;
                string resultSurname = resultRow.FindElement(By.CssSelector("td[title='" + surname + "']")).Text;
                string resultDOB = resultRow.FindElement(By.CssSelector("td[title='" + DOB + "']")).Text;
                if (resultDOB==DOB && resultFirstName==firstName && resultSurname==surname)
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

        [Then(@"the result can be opened with the values '([^']*)', '([^']*)', and '([^']*)' to create a new record")]
        public void ThenTheResultCanBeOpenedWithTheValuesAndToCreateANewRecord(string firstNameValue, string lastNameValue, string DOBValue)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(3000);
            driver.SwitchTo().Frame("contentIFrame0");
            String firstField = driver.FindElement(By.Id("firstname")).Text;
            xrmBrowser.ThinkTime(2000);
            String surnameField = driver.FindElement(By.Id("lastname")).Text;
            xrmBrowser.ThinkTime(2000);
            String DOBField = driver.FindElement(By.Id("birthdate")).Text;
            xrmBrowser.ThinkTime(2000);
            Assert.IsTrue(firstField.Contains(firstNameValue));
            Assert.IsTrue(surnameField.Contains(lastNameValue));
            Assert.IsTrue(DOBField.Contains(DOBValue));
        }
    }
}