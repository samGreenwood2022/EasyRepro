using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCIS.Specs.PageObjects
{
    internal class Page_PersonSearchResults
    {
        //Method for entering obtaining the client id from the search results list

        public static string GetStringClientIdFromResultsList(IWebDriver driver)
        {
            string personId = driver.FindElement(By.XPath("//*[contains(@id, 'cw_clientid')]")).Text;
            return personId;
        }

        //Method for entering obtaining the client id from the search results list

        public static void DoubleClickSearchResultContaining(IWebDriver driver,string textInResult)
        {
            Actions actions = new Actions(driver);
            driver.WaitUntilVisible(By.XPath("//*[text()[contains(.,'" + textInResult + "')]]"));
            IWebElement row = driver.FindElement(By.XPath("//*[text()[contains(.,'" + textInResult + "')]]"));
            actions.DoubleClick(row).Perform();
        }

        //method for double clicking a result

        public static void DoubleClickSearchResult(IWebDriver driver, string personID)
        {
            IWebElement personSearchResult = LocatePersonSearchResult(driver, personID);

            Actions actions = new Actions(driver);
            actions.DoubleClick(personSearchResult).Perform();
        }

        //method for asserting a result is present 

        public static bool IsPersonSearchResultPresent(IWebDriver driver, string personID)
        {
            IWebElement personSearchResult = LocatePersonSearchResult(driver, personID);

            bool isPersonResultPresent = personSearchResult.Displayed;

            return isPersonResultPresent;
        }

        //method for obtaining the 1st Person Id value from returned results on the results page

        public static string GetFirstPersonId(IWebDriver driver)
        {
            {
                IWebElement firstPersonId = LocateFirstPersonId(driver);
                string personId = firstPersonId.Text;
                return personId;
            }

        }

        // Private methods

        //Method for locating a result

        private static IWebElement LocatePersonSearchResult(IWebDriver driver, string personID)
        {
            driver.WaitUntilVisible(By.XPath("//*[text()='" + personID + "']"));
            IWebElement row = driver.FindElement(By.XPath("//*[text()='" + personID + "']"));
            return row;
        }

        //Method for obtaining the value for the first Person Id value on the results screen

        private static IWebElement LocateFirstPersonId(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[contains(@id, 'cw_clientid')]"));
            IWebElement personId = driver.FindElement(By.XPath("//*[contains(@id, 'cw_clientid')]"));
            return personId;
        }

    }
}
