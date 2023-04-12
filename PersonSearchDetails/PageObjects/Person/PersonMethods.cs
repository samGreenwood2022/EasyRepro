using Microsoft.Dynamics365.UIAutomation.Api;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;

namespace PersonSearchDetails.PageObjects
{
    internal class PersonMethods
        // a collection of methods that can be used in the Person area of CareDirector
    {
        public static string dateMovedInNew = "01/01/2003";

        // this method completes the mandatory fields required to add a valid address to a Person
        public static void enterAddressDetails(Browser xrmBrowser, IWebDriver driver, string propertyNo, string firstLineOfAddress, string townCity, string county, string postCode)
        {
            driver.FindElement(By.XPath("//*[@id=\"cw_propertyno_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cw_propertyno_i\"]")).SendKeys(propertyNo);
            driver.FindElement(By.XPath("//*[@id=\"cw_propertyno_i\"]")).SendKeys(Keys.Return);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"address1_line1_cl_span\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"address1_line1_i\"]")).SendKeys(firstLineOfAddress);
            driver.FindElement(By.XPath("//*[@id=\"address1_line1_i\"]")).SendKeys(Keys.Return);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"address1_city_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"address1_city_i\"]")).SendKeys(townCity);
            driver.FindElement(By.XPath("//*[@id=\"address1_city_i\"]")).SendKeys(Keys.Return);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"address1_stateorprovince_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"address1_stateorprovince_i\"]")).SendKeys(county);
            driver.FindElement(By.XPath("//*[@id=\"address1_stateorprovince_i\"]")).SendKeys(Keys.Return);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"address1_postalcode_cl\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"address1_postalcode_i\"]")).SendKeys(postCode);
            driver.FindElement(By.XPath("//*[@id=\"address1_postalcode_i\"]")).SendKeys(Keys.Return);
            // click postcode lookup
            // driver.FindElement(By.XPath("//*[@id=\"address1_postalcodeAddressSearch\"]")).Click();
            xrmBrowser.ThinkTime(2000);
            xrmBrowser.CommandBar.ClickCommand("SAVE");
            xrmBrowser.ThinkTime(1000);
        }

        public static string personSearch(Browser xrmBrowser, IWebDriver driver, string firstname, string lastname, string dob)
        {
            // search for our person, the search person method should be called from here
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtLastName")).SendKeys(lastname);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtDOB")).SendKeys(dob);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("btnFind")).Click();
            xrmBrowser.ThinkTime(2000);

            // finds the element that stores the person id by searching on a partial id
            // then getting the text value from that element
            String personId = driver.FindElement(By.XPath("//*[contains(@id, 'cw_clientid')]")).Text;
            Console.WriteLine(personId);
            // the Actions class contains functions like 'doubleClick' which can be used on ui elements
            Actions act = new Actions(driver);
            IWebElement row = driver.FindElement(By.XPath("//*[text()[contains(.,'" + firstname + "')]]"));
            act.DoubleClick(row).Perform();
            xrmBrowser.ThinkTime(2000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            //driver.Close();
            // switch to the correct browser window and iFrame we want to use
            // driver.SwitchTo().Window(driver.WindowHandles.First());
            // driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.SwitchTo().Frame("contentIFrame0");
            // driver.SwitchTo().Frame(driver.FindElement(By.Id("IFRAME_Banner")));
            xrmBrowser.ThinkTime(2000);
            return personId;

        }



    }
}
