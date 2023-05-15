using Microsoft.Dynamics365.UIAutomation.Api;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WCCIS.Specs.PageObjects
{
    internal class Page_PersonCoreDemographics
    {

        //Note:
        //There is a design pattern employed for text boxes on the Person Core Demographics page
        //First the Element is "clicked into". In order to do this you will need to click either
        //The Label or the Div related to the field under test
        //You will only then be able to send text to the input fields.
        public static void EnterDateMovedIn(IWebDriver driver, string dateMovedIn, bool isUsingDatePicker = false)
        {

            if (isUsingDatePicker)
            {
               throw new NotImplementedException();
                //LocateDMIPickerButton
                //SelectUsingDMIPicker
            }

            if (!isUsingDatePicker)
            {
                ClickLabelDateMovedIn(driver);
                EnterTextIntoTextBoxDateMovedIn(driver, dateMovedIn);
            }
        }


        public static void EnterGender(IWebDriver driver, string gender)
        {
            //This is the public method - as in other fields you must select it first
            //You do this by clicking into the field ClickGenderLabel
            //This activates the field, so you can set the dropdown
            ClickGenderLabel(driver);
            SelectGenderFromDropDown(driver, gender);
        }

        public static void EnterPreferredLanguage(IWebDriver driver, string preferredLanguage, bool isUsingLookup = false)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu using the title property
                throw new NotImplementedException ("This is partially imeplemented at this time");
                ClickLabelPreferredLanguage(driver);
                ClickLookupButtonPreferredLanguage(driver);
                ClickPreferredLanguageUsingLookup(driver, preferredLanguage);
            }
            
            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelPreferredLanguage(driver);
                EnterTextIntoPreferredLanguageField(driver, preferredLanguage);
            }
        }

        public static void EnterDateOfBirth(IWebDriver driver, string dateOfBirth, bool isUsingCalendar = false)
        {
            if (isUsingCalendar)
            {
                //Use this area to code a solution that uses the calendar
                //Not using the calendar is considered the default
                throw new NotImplementedException();
            }

            if (!isUsingCalendar)
            {
                //default method
                //This is as many dates will require lots of clicks
                //users will probably usually type values in because of this
                ClickLabelDOB(driver);
                EnterTextIntoDOBField(driver, dateOfBirth);
            }
        }

        
        public static void EnterEthnicity(IWebDriver driver, string ethnicity, bool isUsingLookup = false)
        {
            if (isUsingLookup)
            {
                //This method will use the lookup button instead of entering text
                throw new NotImplementedException("This is partially implemented and needs work");
                ClickEthnicityLabel(driver);
                SelectEthnicityUsingLookup(driver, ethnicity);

            }

            if (!isUsingLookup)
            {
                //This method will click the Label and then type into the Ethnicity Text Box
                //If the text matches an ethnicity in the lookup, you will enter it into the field
                ClickEthnicityLabel(driver);
                EnterTextIntoEthnicityField(driver, ethnicity);
            }
        }

        private static void ClickEthnicityLabel(IWebDriver driver)
        {
            IWebElement ethnicityLabel = LocateEthnicityLabel(driver);
            ethnicityLabel.Click();
        }

        private static void SelectEthnicityUsingLookup(IWebDriver driver, string ethnicity)
        {
            IWebElement lookUpButton = LocateEthnicityLookupButton(driver);
            lookUpButton.Click();
            IWebElement ethnicityFromMenu = LocateEthnicityFromMenu(driver, ethnicity);
            ethnicityFromMenu.Click();
        }

        public static void EnterFirstName(IWebDriver driver, string firstName)
        {
            //This method will click the Label and then type into the First Name Text Box
            ClickLabelFirstName(driver);
            EnterTextIntoFirstNameField(driver, firstName);
        }

        public static void EnterLastName(IWebDriver driver, string lastName)
        {
            //This method will click the Label and then type into the Last Name Text Box
            ClickLabelLastName(driver);
            EnterTextIntoLastNameField(driver, lastName);
        }

        ///Private methods below - not to be called directly in tests

        private static void EnterTextIntoTextBoxDateMovedIn(IWebDriver driver, string dateMovedIn)
        {
            IWebElement textBoxDateMovedIn = LocateTextBoxDateMovedIn(driver);
            textBoxDateMovedIn.SendKeys(dateMovedIn);
        }

        private static IWebElement LocateTextBoxDateMovedIn(IWebDriver driver)
        {
            IWebElement textBoxDateMovedIn = driver.FindElement(By.Id("cw_datepersonmovedin_iDateInput"));
            return textBoxDateMovedIn;
        }

        private static void ClickLabelDateMovedIn(IWebDriver driver)
        {
            IWebElement dateMovedInLabel = LocateDivDateMovedIn(driver);
            dateMovedInLabel.Click();
        }

        private static IWebElement LocateDivDateMovedIn(IWebDriver driver)
        {
            //IWebElement dateMovedInLabel = driver.FindElement(By.XPath("//*[@id=\"Date Person moved in_label\"]"));
            IWebElement dateMovedInLabel = driver.FindElement(By.Id("cw_datepersonmovedin"));
            return dateMovedInLabel;
        }

        private static void ClickGenderLabel(IWebDriver driver)
        {
            IWebElement genderLabel = LocateLabelGender(driver);
            genderLabel.Click();
        }

        private static void SelectGenderFromDropDown(IWebDriver driver, string gender)
        {
            IWebElement genderDropDown = LocateDropDownGender(driver);
            var selectElementGender = new SelectElement(genderDropDown);
            selectElementGender.SelectByText(gender);
        }

        private static IWebElement LocateDropDownGender(IWebDriver driver)
        {
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement genderDropDown = driver.FindElement(By.Id("gendercode_i"));
            return genderDropDown;
        }

        private static IWebElement LocateLabelGender(IWebDriver driver)
        {
            IWebElement genderLabel = driver.FindElement(By.Id("gendercode"));
            return genderLabel;
        }


        private static void ClickPreferredLanguageUsingLookup(IWebDriver driver, string preferredLanguage)
        {
            IWebElement preferredLanguageFromLookup = LocatePreferredLanguageFromLookup(driver, preferredLanguage);
            preferredLanguageFromLookup.Click();
        }

        private static IWebElement LocatePreferredLanguageFromLookup(IWebDriver driver, string preferredLanguage)
        {
            //Note that if the ethnicity button is clicked more than once you will generate a new ID each time
            IWebElement preferredLanguageFromMenu = driver.FindElement(By.XPath("//a[@title='" + preferredLanguage + "']"));
            return preferredLanguageFromMenu;

        }

        private static void ClickLookupButtonPreferredLanguage(IWebDriver driver)
        {
            IWebElement lookupButtonPreferredLanguage = LocateLookupButtonPreferredLanguage(driver);
            lookupButtonPreferredLanguage.Click();
        }

        private static IWebElement LocateLookupButtonPreferredLanguage(IWebDriver driver)
        {
            IWebElement lookupButtonPreferredLanguage = driver.FindElement(By.Id("cw_languageid_lookupSearch"));
            return lookupButtonPreferredLanguage;
        }

        private static void EnterTextIntoPreferredLanguageField(IWebDriver driver, string preferredLanguage)
        {
            IWebElement textBoxPreferredLanguage = LocateTextBoxPreferredLanguage(driver);
            textBoxPreferredLanguage.SendKeys(preferredLanguage);
        }

        private static IWebElement LocateTextBoxPreferredLanguage(IWebDriver driver)
        {
            IWebElement textBoxPreferredLanguage = driver.FindElement(By.Id("cw_languageid_ledit"));
            return textBoxPreferredLanguage;
        }

        private static void ClickLabelPreferredLanguage(IWebDriver driver)
        {
            IWebElement label = LocateLabelPreferredLanguage(driver);
            label.Click();
        }

        private static IWebElement LocateLabelPreferredLanguage(IWebDriver driver)
        {
            IWebElement prefLanguageLabel = driver.FindElement(By.Id("cw_languageid_cl"));
            return prefLanguageLabel;
        }

        private static void EnterTextIntoDOBField(IWebDriver driver, string dateOfBirth)
        {
            //Send keys to the text box
            //will only work if you have clicked into the field to activate it
            IWebElement dobField = LocateTextBoxDOB(driver);
            dobField.SendKeys(dateOfBirth);
        }

        private static IWebElement LocateTextBoxDOB(IWebDriver driver)
        {
            //locate the date of birth field only
            //use this field to act on the field e.g. send text or assert content.
            IWebElement textBoxDOB = driver.FindElement(By.XPath("//*[@id=\"birthdate_iDateInput\"]"));
            return textBoxDOB;
        }

        private static void ClickLabelDOB(IWebDriver driver)
        {
            //Just to click the element
            IWebElement label = LocateLabelDOB(driver);
            label.Click();
        }

        private static IWebElement LocateLabelDOB(IWebDriver driver)
        {
            //Find label by ID and return it
            IWebElement label = driver.FindElement(By.XPath("//*[@id=\"Date of Birth_label\"]"));
            return label;

        }

        private static void EnterTextIntoEthnicityField(IWebDriver driver, string ethnicity)
        {
            //Locate the box and send text to it
            //Not to be called directly in isolation
            //Method will fail unless you are clicked into the box 
            IWebElement ethnicityTextbox = LocateEthnicityBox(driver);
            ethnicityTextbox.SendKeys(ethnicity);
        }

        private static IWebElement LocateEthnicityLabel(IWebDriver driver)
        {
            //Note that the clicked element here is different to those used for last name etc. 
            IWebElement ethnicityLabel = driver.FindElement(By.Id("cw_ethnicityid_cl_span"));
            return ethnicityLabel;
        }

        private static IWebElement LocateEthnicityBox(IWebDriver driver)
        {
            //Locate the ethnicity text box - this method does nothing with it
            IWebElement ethnicityBox = driver.FindElement(By.Id("cw_ethnicityid_ledit"));
            return ethnicityBox;
        }

        private static IWebElement LocateEthnicityLookupButton(IWebDriver driver)
        {
            //
            IWebElement ethnicityLookupButton = driver.FindElement(By.Id("cw_ethnicityid_lookupSearch"));
            return ethnicityLookupButton;
        }

        private static IWebElement LocateEthnicityFromMenu(IWebDriver driver, string ethnicity)
        {
            //Note that if the ethnicity button is clicked more than once you will generate a new ID each time
            IWebElement ethnicityFromMenu = driver.FindElement(By.XPath("//a[@title='" + ethnicity + "']"));
            return ethnicityFromMenu;
        }

        private static void EnterTextIntoLastNameField(IWebDriver driver, string lastName) 
        {
            //Locate the text box, then send a string into it
            //private method to protect this from being used as a step step, as you need to click into the field first
            IWebElement textBoxLastName = LocateTextBoxLastName(driver);
            textBoxLastName.SendKeys(lastName);
            
        }

        private static IWebElement LocateTextBoxLastName(IWebDriver driver)
        {
            //Find the box only, do not do anything with it
            //Use this method if you are doing an action or check against the firstname input box
            //E.g. typing into it, asserting text inside it, etc.
            IWebElement textBoxLastName = driver.FindElement(By.Id("lastname_i"));
            return textBoxLastName;
        }

        private static void ClickLabelLastName(IWebDriver driver)
        {
            //Locate the label and actually click it
            IWebElement labelLastName = LocateLabelLastName(driver);
            labelLastName.Click();
        }

        private static IWebElement LocateLabelLastName(IWebDriver driver)
        {
            //Enter field by clicking on the label
            // Use this locate method also if you wish to, for example, check the text of the label. 
            IWebElement labelLastName = driver.FindElement(By.Id("lastname_cl"));
            return labelLastName;
        }


        private static void EnterTextIntoFirstNameField(IWebDriver driver, string firstName)
        {
            //Locate the text box, then send a string into it
            //private method to protect this from being used as a step step, as you need to click into the field first
            IWebElement textBoxFirstName = LocateTextBoxFirstName(driver);
            textBoxFirstName.SendKeys(firstName);
        }

        private static void ClickLabelFirstName(IWebDriver driver)
        {
            //Changed from div to be label
            IWebElement divFirstName = LocateLabelFirstName(driver);
            divFirstName.Click();
        
        }

        private static IWebElement LocateTextBoxFirstName(IWebDriver driver) 
        {
            //Find the box only, do not do anything with it
            //Use this method if you are doing an action or check against the firstname input box
            //E.g. typing into it, asserting text inside it, etc.
            IWebElement textBoxFirstName = driver.FindElement(By.Id("firstname_i"));
            return textBoxFirstName;
        }

        private static IWebElement LocateLabelFirstName(IWebDriver driver)
        {
            //Enter field by clicking on the label
            // Use this locate method also if you wish to, for example, check the text of the label. 
            IWebElement divFirstName = driver.FindElement(By.Id("firstname_cl"));
            return divFirstName;
        }

    }
}
