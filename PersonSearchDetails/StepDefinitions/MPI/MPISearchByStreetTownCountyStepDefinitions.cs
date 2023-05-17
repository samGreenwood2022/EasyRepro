using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;
using WCCIS.Specs.Extentions;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPISearchByStreetTownCountyStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly Browser xrmBrowser;

        public MPISearchByStreetTownCountyStepDefinitions(IWebDriver webDriver, Browser browser)//constructor
        {
            // Create an instance of our webserver (defined within Hooks) to be used by all methods
            // also create an instance of a dynamics365 library (xrmBrowser) containing commands we can use
            driver = webDriver;
            xrmBrowser = browser;
        }
        [When(@"an MPI search is conducted using Street '([^']*)', Town '([^']*)' and County '([^']*)'")]
        public void WhenAnMPISearchIsConductedUsingStreetTownAndCounty(string Street, string City, string County)
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
            driver.FindElement(By.XPath("//*[@id=\"txtStreetAddress\"]")).SendKeys(Street);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtCity\"]")).SendKeys(City);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtStateOrProvince\"]")).SendKeys(County);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnEMPISearch")).Click();
            xrmBrowser.ThinkTime(2000);
        }

        [Then(@"a result is returned with Street '([^']*)', Town '([^']*)' and County '([^']*)'")]
        public void ThenAResultIsReturnedWithStreetTownAndCounty(string Street, string City, string County)
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
                string resultStreet = resultRow.FindElement(By.CssSelector("td[title='" + Street + "']")).Text;
                string resultCity = resultRow.FindElement(By.CssSelector("td[title='" + City + "']")).Text;
                string resultCounty = resultRow.FindElement(By.CssSelector("td[title='" + County + "']")).Text;
                if (resultStreet == Street && resultCity == City && resultCounty == County)
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

        [Then(@"the result can be opened with Street '([^']*)', Town '([^']*)' and County '([^']*)'")]
        public void ThenTheResultCanBeOpenedWithStreetTownAndCounty(string Street, string City, string County)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(3000);
            driver.SwitchTo().Frame("contentIFrame0");
            String StreetField = driver.FindElement(By.Id("address1_line1")).Text;
            xrmBrowser.ThinkTime(2000);
            String CityField = driver.FindElement(By.Id("address1_city")).Text;
            xrmBrowser.ThinkTime(2000);
            String CountyField = driver.FindElement(By.Id("address1_stateorprovince")).Text;
            xrmBrowser.ThinkTime(2000);
            Assert.IsTrue(StreetField.Contains(Street));
            Assert.IsTrue(CityField.Contains(City));
            Assert.IsTrue(CountyField.Contains(County));
        }
    }
}
