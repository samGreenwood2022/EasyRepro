using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCIS.Specs.PageObjects.Person
{
    internal class Page_PersonSearch
    {
        //Uncertain

        //Method for switching frame



        //public

        //Method for entering text into firstname 

        public static void EnterTextIntoFirstNameField(IWebDriver driver, string firstName)
        {
            IWebElement firstNameTextBox = LocateTextBoxFirstName(driver);
            firstNameTextBox.SendKeys(firstName);
        }

        //Method for entering text into lastname

        public static void EnterTextIntoLastNameField(IWebDriver driver, string lastName)
        {
            IWebElement lastNameTextBox = LocateTextBoxLastName(driver);
            lastNameTextBox.SendKeys(lastName);
        }

        //method for entering text into DOB

        public static void EnterDateOfBirth(IWebDriver driver, string dateOfBirth, bool isUsingCalendar = false)
        {
            if (isUsingCalendar)
            {
                throw new NotImplementedException();
            }

            if (!isUsingCalendar)
            {
                IWebElement dateOfBirthTextBox = LocateTextBoxDateOfBirth(driver);
                dateOfBirthTextBox.SendKeys(dateOfBirth);
            }
        }

        //method for clicking search

        public static void ClickSearch(IWebDriver driver)
        {
            IWebElement searchButton = LocateButtonSearch(driver);
            searchButton.Click();
        }

        //method for entering text into ID field

        public static void EnterPersonID(IWebDriver driver, string personID)
        {
            IWebElement personIDTextBox = LocateTextBoxID(driver);
            personIDTextBox.SendKeys(personID);
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

        //method for entering text into Middle Name field

        public static void EnterMiddleName(IWebDriver driver, string middleName)
        {
            IWebElement middleNameTextBox = LocateTextBoxMiddleName(driver);
            middleNameTextBox.SendKeys(middleName);
        }

        //method for entering text into Preferred Name field

        public static void EnterPreferredName(IWebDriver driver, string preferredName)
        {
            IWebElement preferredNameTextBox = LocateTextBoxPreferredName(driver);
            preferredNameTextBox.SendKeys(preferredName);
        }

        //method for selecting a gender from the  field

        public static void EnterGender(IWebDriver driver, string gender)
        {
            LocateDropDownGender(driver);
            SelectGenderFromDropDown(driver, gender);

        }



        //private

        //Method for Finding firstname field
        private static IWebElement LocateTextBoxFirstName(IWebDriver driver)
        {
            IWebElement firstNameTextBox = driver.FindElement(By.XPath("//*[@id=\"txtFirstName\"]"));
            return firstNameTextBox;
        }

        //Method for finding last name field

        private static IWebElement LocateTextBoxLastName(IWebDriver driver)
        {
            IWebElement lastNameTextBox = driver.FindElement(By.Name("txtLastName"));
            return lastNameTextBox;
        }

        //Method for finding DOB field

        private static IWebElement LocateTextBoxDateOfBirth(IWebDriver driver)
        {
            IWebElement dateOfBirthTextBox = driver.FindElement(By.Name("txtDOB"));
            return dateOfBirthTextBox;
        }

        //Method for finding Search button

        private static IWebElement LocateButtonSearch(IWebDriver driver)
        {
            IWebElement searchButton = driver.FindElement(By.Name("btnFind"));
            return searchButton;
        }

        //Method for finding ID field

        private static IWebElement LocateTextBoxID(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtClientId\"]"));
            return idTextBox;
        }

        //Method for locating a result

        private static IWebElement LocatePersonSearchResult(IWebDriver driver, string personID)
        {
            driver.WaitUntilVisible(By.XPath("//*[text()='" + personID + "']"));
            IWebElement row = driver.FindElement(By.XPath("//*[text()='" + personID + "']"));
            return row;
        }

        //Method for finding Middle Name field

        private static IWebElement LocateTextBoxMiddleName(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtMiddleName\"]"));
            return idTextBox;
        }

        //Method for finding Preferred Name field

        private static IWebElement LocateTextBoxPreferredName(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtNickName\"]"));
            return idTextBox;
        }

        //Method for finding Gender dropdown menu

        private static void SelectGenderFromDropDown(IWebDriver driver, string gender)
        {
            IWebElement genderDropDown = LocateDropDownGender(driver);
            var selectElementGender = new SelectElement(genderDropDown);
            selectElementGender.SelectByText(gender);
        }

        private static IWebElement LocateDropDownGender(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("cboGender"));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement genderDropDownMenu = driver.FindElement(By.Id("cboGender"));
            return genderDropDownMenu;
        }


    }
}
