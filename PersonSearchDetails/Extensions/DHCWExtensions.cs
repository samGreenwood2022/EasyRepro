using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Security;
using System.Text;

namespace WCCIS.Specs.Extentions
{
    public static class DHCWExtensions
    {       
        public static string dateMovedInNew = "01/01/2003";
        public static int menuNumber;
        // this code will log us into CareDirector
        public static void Login(Browser xrmBrowser, SecureString _username, SecureString _password)
        {
            // wait for page to load
            var driver = xrmBrowser.Driver;
            xrmBrowser.ThinkTime(2000);
            driver.Navigate().GoToUrl("https://caredirectoruat365.ccis.cymru");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"bySelection\"]/div[2]/img")).Click();
            // driver.FindElement(By.XPath("//*[@id=\"bySelection\"]/div[6]/div/span")).Click();
            
            // wait for page to load
            xrmBrowser.ThinkTime(1000);
            // ADFS login screen
            driver.FindElement(By.Id("userNameInput")).SendKeys(_username.ToUnsecureString());
            driver.FindElement(By.Id("passwordInput")).SendKeys(_password.ToUnsecureString());
            driver.FindElement(By.Id("submitButton")).Click();
            // xrmBrowser.ThinkTime(2000);
        }

        // Generate a random string with a given size
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

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
            xrmBrowser.ThinkTime(1000);
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

        public static void selectFormSectionsMenu(IWebDriver driver, Browser xrmBrowser, string option)
        {
            // here we click on the navigation control icon to open the form sections menu
            driver.FindElement(By.Id("FormSecNavigationControl-Icon")).Click();
            xrmBrowser.ThinkTime(1000);
            // this code selects an option in the Form Sections Menu
            if (option == "core demographics")
            {
                menuNumber = 1;
            }

            if (option == "general practitioner information")
            {
                menuNumber = 2;
            }

            if (option == "audit information")
            {
                menuNumber = 3;
            }
            // menuNumber 1, 2 or 3 will inserted into this XPath selector, there are 3 elements in 
            // the DOM called 'flyoutFormSection_Cell', selecting 1, 2 or 3 selects the corresponding menu item
            driver.FindElement(By.XPath("//*[@id=\"flyoutFormSection_Cell\"][" + menuNumber + "]")).Click();

        }


    }
}
