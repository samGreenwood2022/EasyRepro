using Microsoft.Dynamics365.UIAutomation.Api;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCCIS.Specs.Extentions
{
    public static class DHCWExtensions
    {       
        public static string dateMovedInNew = "01/01/2003";
        public static int menuNumber;
        // this code will log us into CareDirector
        public static void Login(Browser xrmBrowser, IWebDriver webDriver,  string username, string password)
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

        //This method will close the Person Search Results window if its open
        //NOTE: THIS METHOD IS UNFINISHED AT THE MOMENT

        public static void ClosePersonSearchResultsWindowIfOpen(IWebDriver driver, string title)
        {
            var currentWindow = driver.CurrentWindowHandle;
            var availableWindows = new List<string>(driver.WindowHandles);

            foreach (string w in availableWindows)
            {
                if (w != currentWindow)
                {
                    driver.SwitchTo().Window(w);
                    if (driver.Title == title)
                    {
                        driver.Close();
                    }
                        
                    else
                    {
                        driver.SwitchTo().Window(currentWindow);
                    }

                }
            }
            
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
