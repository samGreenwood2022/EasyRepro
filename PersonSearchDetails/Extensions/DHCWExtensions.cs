using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Text;

namespace WCCIS.Specs.Extentions
{
    public static class DHCWExtensions
    {       
        public static string dateMovedInNew = "01/01/2003";
        public static int menuNumber;
        // this code will log us into CareDirector
        public static void Login(IWebDriver webDriver, Browser xrmBrowser, string username, string password)
        {
            // wait for page to load
            var driver = webDriver;
            //var browser = xrmBrowser;
            driver.Navigate().GoToUrl("https://caredirectoruat365.ccis.cymru");
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"bySelection\"]/div[2]/img")).Click();
            // driver.FindElement(By.XPath("//*[@id=\"bySelection\"]/div[6]/div/span")).Click();
            
            // wait for page to load
            xrmBrowser.ThinkTime(1000);
            // ADFS login screen
            driver.FindElement(By.Id("userNameInput")).SendKeys(username);
            driver.FindElement(By.Id("passwordInput")).SendKeys(password);
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
            xrmBrowser.ThinkTime(2000);
            xrmBrowser.CommandBar.ClickCommand("SAVE");
            xrmBrowser.ThinkTime(1000);
        }

        public static string personSearch(Browser xrmBrowser, IWebDriver driver, string firstName, string lastName, string dob)
        {
            // search for our person, the search person method should be called from here
            xrmBrowser.Navigation.OpenSubArea("Workplace", "People");
            xrmBrowser.CommandBar.ClickCommand("PERSON SEARCH");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]")).SendKeys(firstName);
            xrmBrowser.ThinkTime(1000);
            driver.FindElement(By.Name("txtLastName")).SendKeys(lastName);
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
            IWebElement row = driver.FindElement(By.XPath("//*[text()[contains(.,'" + firstName + "')]]"));
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
            // selecting the correct frame first
            driver.SwitchTo().Frame("contentIFrame1");
            driver.FindElement(By.Id("FormSecNavigationControl-Icon")).Click();
            xrmBrowser.ThinkTime(1000);
            // this code selects an option in the Form Sections Menu
            if (option == "core demographics")
            {
                driver.FindElement(By.XPath("//td[@title='Core Demographics']")).Click();
            }

            if (option == "general practitioner information")
            {
                driver.FindElement(By.XPath("//td[@title='General Practitioner Information']")).Click();
            }

            if (option == "audit information")
            {
                driver.FindElement(By.XPath("//td[@title='Audit Information']")).Click();
            }
        }

        public static string ReturnNHSNumber()
        {
            string nhsNumber = MakeNHSNumber();
            while (nhsNumber.Length > 10)
            {
                nhsNumber = MakeNHSNumber();
            }
            return nhsNumber;
        }

        private static string MakeNHSNumber()
        {
            string firstNumber = ChooseStartNumber();
            string middleNumbers = FillMiddleNumbers();
            string firstTen = firstNumber + middleNumbers;
            string finalNumber = CalculateEndNumber(firstTen);
            string nhsNumber = firstTen + finalNumber;
            return nhsNumber;
        }

        private static string ChooseStartNumber()
        {
            Random number = new Random(Guid.NewGuid().GetHashCode());
            int startNo = number.Next(0, 3) + 1;
            return startNo.ToString();
        }

        private static string FillMiddleNumbers()
        {
            Random number = new Random(Guid.NewGuid().GetHashCode());

            //String is filled with 8 characters so that the Remove/Insert functions correctly
            string middleNumbers = "12345678";

            //Use a for loop to remove a number from the string, then insert another in it's place
            for (int i = 0; i <= 7; i++)
            {
                int randNumber = number.Next(0, 9);
                middleNumbers = middleNumbers.Remove(i, 1);
                middleNumbers = middleNumbers.Insert(i, randNumber.ToString());
            }
            return middleNumbers;
        }

        private static string CalculateEndNumber(string nhsNumber)
        {
            //Create an array to contain each individual number
            int[] numberList = new int[9];

            //Use a for loop to populate the array at position "i"
            for (int i = 0; i <= 8; i++)
            {
                string thisNumber = nhsNumber.Substring(i, 1);
                int number = Int32.Parse(thisNumber);
                numberList[i] = number;
            }

            //Divide Each number by it's position in the string
            int moduloDivisor = (numberList[0] * 10) + (numberList[1] * 9)
                + (numberList[2] * 8) + (numberList[3] * 7) + (numberList[4] * 6)
                + (numberList[5] * 5) + (numberList[6] * 4) + (numberList[7] * 3) + (numberList[8] * 2);

            //Get the remainder when divided by 11
            int moduloResult = moduloDivisor % 11;

            //Take the remainder away from 11 to get the final number
            int finalNumber = 11 - moduloResult;

            string finalNumberString = finalNumber.ToString();
            return finalNumberString;
        }

    }
}
