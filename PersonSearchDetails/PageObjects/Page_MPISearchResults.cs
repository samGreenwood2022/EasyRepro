using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WCCIS.Specs.StepDefinitions;

namespace WCCIS.Specs.PageObjects
{
    internal class Page_MPISearchResults
    {
        //public

        //Method to check results have returned
        public static void CheckResultsReturned(IWebDriver driver)
        {
            var tableNotPresent = false;
            try
            {
                IWebElement table = driver.FindElement(By.Id("CWGrid"));
            }
            catch
            {
                tableNotPresent = true;
            }
            if (tableNotPresent)
            {
                throw new Exception("MPI found no results. Test aborted.");
            }
        }

        //Method to check results have returned
        public static void CheckNoResultsReturned(IWebDriver driver)
        {
            var noTablePresent = false;
            try
            {
                IWebElement table = driver.FindElement(By.Id("CWGrid"));
            }
            catch (NoSuchElementException)
            {
                noTablePresent = true;
            }
            if (noTablePresent == true)
            {
                Console.WriteLine("No results found.");
            }
            else
            {
                throw new Exception("Search results found. Test aborted.");
            }
        }

        //Method to locate a search result with a given search value

        public static void LocateResult(IWebDriver driver, string searchValue)
        {
            driver.FindElement(By.XPath("//table/tbody/tr/td[@title='" + searchValue + "']"));
        }

        //Method to locate a search result with a given search value and open a new patient record for that result

        public static void OpenSearchResult(IWebDriver driver, string searchValue)
        {
            IWebElement searchResult = driver.FindElement(By.XPath("//table/tbody/tr/td[@title='" + searchValue + "']"));
            Actions act = new Actions(driver);
            act.DoubleClick(searchResult).Perform();
        }

        //Method to locate 5 line address has returned and open it

        public static void FindAndOpen5LineAddressMatch(IWebDriver driver, string Street, string OtherDesignation, string City, string County, string Postcode)
        {
            // init table element
            IWebElement resultTable = driver.FindElement(By.Id("CWGrid"));

            // init tr elements from the table
            ReadOnlyCollection<IWebElement> allSearchResultRows = resultTable.FindElements(By.TagName("tr"));

            // init searchResult as empty
            IWebElement searchResult = null;

            // loop through each row and check if it contains all the values under test
            foreach (IWebElement resultRow in allSearchResultRows)
            {
                string resultStreet = LocateAddressResult(driver, resultRow, Street);
                string resultOtherDesignation = LocateAddressResult(driver, resultRow, OtherDesignation);
                string resultCity = LocateAddressResult(driver, resultRow, City);
                string resultCounty = LocateAddressResult(driver, resultRow, County);
                string resultPostcode = LocateAddressResult(driver, resultRow, Postcode);
                if (resultStreet == Street && resultOtherDesignation == OtherDesignation && resultCity == City && resultCounty == County && resultPostcode == Postcode)
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
                        break;
                    }
            }
        }

        public static void FindAndOpenStreetDesCountyMatch(IWebDriver driver, string Street, string OtherDesignation, string County)
        {
            // init table element
            IWebElement resultTable = driver.FindElement(By.Id("CWGrid"));

            // init tr elements from the table
            ReadOnlyCollection<IWebElement> allSearchResultRows = resultTable.FindElements(By.TagName("tr"));

            // init searchResult as empty
            IWebElement searchResult = null;

            // loop through each row and check if it contains all the values under test
            foreach (IWebElement resultRow in allSearchResultRows)
            {
                string resultStreet = LocateAddressResult(driver, resultRow, Street);
                string resultOtherDesignation = LocateAddressResult(driver, resultRow, OtherDesignation);
                string resultCounty = LocateAddressResult(driver, resultRow, County);
                if (resultStreet == Street && resultOtherDesignation == OtherDesignation && resultCounty == County)
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
                        break;
                    }
            }
        }

        public static void FindAndOpenStreetDesCityCountyMatch(IWebDriver driver, string Street, string OtherDesignation, string City, string County)
        {
            // init table element
            IWebElement resultTable = driver.FindElement(By.Id("CWGrid"));

            // init tr elements from the table
            ReadOnlyCollection<IWebElement> allSearchResultRows = resultTable.FindElements(By.TagName("tr"));

            // init searchResult as empty
            IWebElement searchResult = null;

            // loop through each row and check if it contains all the values under test
            foreach (IWebElement resultRow in allSearchResultRows)
            {
                string resultStreet = LocateAddressResult(driver, resultRow, Street);
                string resultOtherDesignation = LocateAddressResult(driver, resultRow, OtherDesignation);
                string resultCity = LocateAddressResult(driver, resultRow, City);
                string resultCounty = LocateAddressResult(driver, resultRow, County);
                if (resultStreet == Street && resultOtherDesignation == OtherDesignation && resultCity == City && resultCounty == County)
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
                        break;
                    }
            }
        }

        public static void FindAndOpenStreetDesCityMatch(IWebDriver driver, string Street, string OtherDesignation, string City)
        {
            // init table element
            IWebElement resultTable = driver.FindElement(By.Id("CWGrid"));

            // init tr elements from the table
            ReadOnlyCollection<IWebElement> allSearchResultRows = resultTable.FindElements(By.TagName("tr"));

            // init searchResult as empty
            IWebElement searchResult = null;

            // loop through each row and check if it contains all the values under test
            foreach (IWebElement resultRow in allSearchResultRows)
            {
                string resultStreet = LocateAddressResult(driver, resultRow, Street);
                string resultOtherDesignation = LocateAddressResult(driver, resultRow, OtherDesignation);
                string resultCity = LocateAddressResult(driver, resultRow, City);
                if (resultStreet == Street && resultOtherDesignation == OtherDesignation && resultCity == City)
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
                        break;
                    }
            }
        }

        public static void FindAndOpenStreetCityCountyMatch(IWebDriver driver, string Street, string City, string County)
        {
            // init table element
            IWebElement resultTable = driver.FindElement(By.Id("CWGrid"));

            // init tr elements from the table
            ReadOnlyCollection<IWebElement> allSearchResultRows = resultTable.FindElements(By.TagName("tr"));

            // init searchResult as empty
            IWebElement searchResult = null;

            // loop through each row and check if it contains all the values under test
            foreach (IWebElement resultRow in allSearchResultRows)
            {
                string resultStreet = LocateAddressResult(driver, resultRow, Street);
                string resultCity = LocateAddressResult(driver, resultRow, City);
                string resultCounty = LocateAddressResult(driver, resultRow, County);
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
                        break;
                    }
            }
        }

        //method to find and open the result with matching DOB & Surname
        public static void FindAndOpenSurnamePostcodeMatch(IWebDriver driver, string Surname, string Postcode)
        {
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
                        break;
                    }
            }
        }

        //find and open result with matching full name and dob
        public static void FindAndOpenFullNamePostcodeMatch(IWebDriver driver, string firstName, string surname, string DOB)
        {
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
                if (resultDOB == DOB && resultFirstName == firstName && resultSurname == surname)
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
                        break;
                    }
            }
        }


        public static void SwitchToNewRecord(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.SwitchTo().Frame("contentIFrame0");
        }


        //method to trim first name entry to the 50 characters that should be permitted in the field

        public static string TrimFirstName(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            object firstName = js.ExecuteScript("return $.trim($('#txtFirstName').val());");
            return firstName.ToString();
        }

        //method to trim last name entry to the 50 characters that should be permitted in the field
        public static string TrimLastName(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            object lastName = js.ExecuteScript("return $.trim($('#txtLastName').val());");
            return lastName.ToString();
        }

        // private

        //method for finding address search match
        private static String LocateAddressResult(IWebDriver driver, IWebElement resultRow, string addressLine)
        {
            string resultLine = resultRow.FindElement(By.CssSelector("td[title='" + addressLine + "']")).Text;
            return resultLine;
        }
    }
}
