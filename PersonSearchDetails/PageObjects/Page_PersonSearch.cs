using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

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

        //method for selecting a gender from the dropdown menu

        public static void EnterGender(IWebDriver driver, string gender)
        {
            LocateDropDownGender(driver);
            SelectGenderFromDropDown(driver, gender);
        }

        //method for entering a number into the NHS Number field

        public static void EnterNHSNumber(IWebDriver driver, string nhsNumber)
        {
            IWebElement textBoxNHSNumber = LocateNumericFieldNHSNumber(driver);
            textBoxNHSNumber.SendKeys(nhsNumber);
        }

        //method for entering a number into the Court Case No text field

        public static void EnterCourtCaseNo(IWebDriver driver, string courtCaseNo)
        {
            IWebElement textBoxCourtCaseNo = LocateTextBoxCourtCaseNo(driver);
            textBoxCourtCaseNo.SendKeys(courtCaseNo);
        }

        //method for entering text into the UPN text field

        public static void EnterUPN(IWebDriver driver, string upn)
        {
            IWebElement textBoxUPN = LocateTextBoxUPN(driver);
            textBoxUPN.SendKeys(upn);
        }

        //method for entering text into the Ni No text field

        public static void EnterNiNo(IWebDriver driver, string niNo)
        {
            IWebElement textBoxNiNo = LocateTextBoxNiNo(driver);
            textBoxNiNo.SendKeys(niNo);
        }

        //method for entering text into the Property Name text field

        public static void EnterPropertyName(IWebDriver driver, string propertyName)
        {
            IWebElement textBoxPropertyName = LocateTextBoxPropertyName(driver);
            textBoxPropertyName.SendKeys(propertyName);
        }

        //method for entering text into the Property No text field

        public static void EnterPropertyNo(IWebDriver driver, string propertyNo)
        {
            IWebElement textBoxPropertyNo = LocateTextBoxPropertyNo(driver);
            textBoxPropertyNo.SendKeys(propertyNo);
        }

        //method for entering text into the Street text field

        public static void EnterStreet(IWebDriver driver, string street)
        {
            IWebElement textBoxStreet = LocateTextBoxStreet(driver);
            textBoxStreet.SendKeys(street);
        }

        //method for entering text into the Vlg/District text field

        public static void EnterVlgDistrict(IWebDriver driver, string vlgDistrict)
        {
            IWebElement textBoxVlgDistrict = LocateTextBoxVlgDistrict(driver);
            textBoxVlgDistrict.SendKeys(vlgDistrict);
        }

        //method for entering text into the Town/City text field

        public static void EnterTownCity(IWebDriver driver, string townCity)
        {
            IWebElement textBoxTownCity = LocateTextBoxTownCity(driver);
            textBoxTownCity.SendKeys(townCity);
        }

        //method for entering text into the County text field

        public static void EnterCounty(IWebDriver driver, string county)
        {
            IWebElement textBoxCounty = LocateTextBoxCounty(driver);
            textBoxCounty.SendKeys(county);
        }

        //method for entering text into the Postcode text field

        public static void EnterPostcode(IWebDriver driver, string postcode)
        {
            IWebElement textBoxPostcode = LocateTextBoxPostcode(driver);
            textBoxPostcode.SendKeys(postcode);
        }

        //method for entering text into the LegacyID text field

        public static void EnterLegacyID(IWebDriver driver, string legacyID)
        {
            IWebElement textBoxLegacyID = LocateTextBoxLegacyID(driver);
            textBoxLegacyID.SendKeys(legacyID);
        }

        //method for selecting a value for the Use Date Of Birth Range radio field

        public static void EnterUseDateOfBirthRange(IWebDriver driver, bool isUseDateOfBirthRange)
        {
            if (isUseDateOfBirthRange == true)
            {
                IWebElement radioButtonUseDateOfBirthRange = LocateRadioButtonUseDateOfBirthRange(driver);
                radioButtonUseDateOfBirthRange.Click();
            } 
        }

        //method for entering text into From date field

        public static void EnterFromDate(IWebDriver driver, string fromDate, bool isUsingCalendar = false)
        {
            if (isUsingCalendar)
            {
                throw new NotImplementedException();
            }

            if (!isUsingCalendar)
            {
                IWebElement textBoxFromDate = LocateTextBoxFrom(driver);
                textBoxFromDate.SendKeys(fromDate);
            }
        }

        //method for entering text into the To date field

        public static void EnterToDate(IWebDriver driver, string toDate, bool isUsingCalendar = false)
        {
            if (isUsingCalendar)
            {
                throw new NotImplementedException();
            }

            if (!isUsingCalendar)
            {
                IWebElement textBoxToDate = LocateTextBoxFrom(driver);
                textBoxToDate.SendKeys(toDate);
            }
        }

        //method for selecting the Sounds Like checkbox

        public static void SelectSoundsLike(IWebDriver driver, bool isUsingSoundsLike)
        {
            if (isUsingSoundsLike == true)
            {
                IWebElement checkboxSoundsLike = LocateCheckboxSoundsLike(driver);
                checkboxSoundsLike.Click();
            }
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

        //Method for selecting a value from the gender dropdown menu

        private static void SelectGenderFromDropDown(IWebDriver driver, string gender)
        {
            IWebElement genderDropDown = LocateDropDownGender(driver);
            var selectElementGender = new SelectElement(genderDropDown);
            selectElementGender.SelectByText(gender);
        }

        //Method for locating gender dropdown field

        private static IWebElement LocateDropDownGender(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("cboGender"));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement genderDropDownMenu = driver.FindElement(By.Id("cboGender"));
            return genderDropDownMenu;
        }

        //Method for finding Preferred Name field

        private static IWebElement LocateNumericFieldNHSNumber(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtNHSNo\"]"));
            return idTextBox;
        }

        //Method for finding Court Case No field

        private static IWebElement LocateTextBoxCourtCaseNo(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtCourtCaseNo\"]"));
            return idTextBox;
        }

        //Method for finding UPN field

        private static IWebElement LocateTextBoxUPN(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtPupilNo\"]"));
            return idTextBox;
        }

        //Method for finding Ni No field

        private static IWebElement LocateTextBoxNiNo(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"TextInsuranceNumber\"]"));
            return idTextBox;
        }

        //Method for finding Property Name field

        private static IWebElement LocateTextBoxPropertyName(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtPropertyName\"]"));
            return idTextBox;
        }

        //Method for finding Property No field

        private static IWebElement LocateTextBoxPropertyNo(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtPropertyNo\"]"));
            return idTextBox;
        }

        //Method for finding Street field

        private static IWebElement LocateTextBoxStreet(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtStreet1\"]"));
            return idTextBox;
        }

        //Method for finding Vlg/District field

        private static IWebElement LocateTextBoxVlgDistrict(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtStreet2\"]"));
            return idTextBox;
        }

        //Method for finding Town/City field

        private static IWebElement LocateTextBoxTownCity(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtCity\"]"));
            return idTextBox;
        }

        //Method for finding County field

        private static IWebElement LocateTextBoxCounty(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtState\"]"));
            return idTextBox;
        }

        //Method for finding Postcode field

        private static IWebElement LocateTextBoxPostcode(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtPostCode\"]"));
            return idTextBox;
        }

        //Method for finding Legacy ID field

        private static IWebElement LocateTextBoxLegacyID(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"txtLegacyId\"]"));
            return idTextBox;
        }

        //Method for finding the Use Date of Birth Range radio button

        private static IWebElement LocateRadioButtonUseDateOfBirthRange(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"BirthDateRangeCheckYes\"]"));
            return idTextBox;
        }

        //Method for finding date field From

        private static IWebElement LocateTextBoxFrom(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"TextDateOfBirthFrom\"]"));
            return idTextBox;
        }

        //Method for finding date field To

        private static IWebElement LocateTextBoxTo(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"TextDateOfBirthTo\"]"));
            return idTextBox;
        }

        //Method for finding Sounds Like checkbox

        private static IWebElement LocateCheckboxSoundsLike(IWebDriver driver)
        {
            IWebElement idTextBox = driver.FindElement(By.XPath("//*[@id=\"chkSoundsLike\"]"));
            return idTextBox;
        }



    }
}
