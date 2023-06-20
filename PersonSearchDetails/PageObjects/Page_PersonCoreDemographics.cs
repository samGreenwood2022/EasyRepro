using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WCCIS.Specs.Extentions;

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
            ClickLabelGender(driver);
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
                ClickLabelEthnicity(driver);
                SelectEthnicityUsingLookup(driver, ethnicity);
            }

            if (!isUsingLookup)
            {
                //This method will click the Label and then type into the Ethnicity Text Box
                //If the text matches an ethnicity in the lookup, you will enter it into the field
                ClickLabelEthnicity(driver);
                EnterTextIntoEthnicityField(driver, ethnicity);
            }
        }

        //Method to enter a enter a value into the NHS Number field

        public static void EnterNHSNumber(IWebDriver driver, string nhsNumber)
        {
            ClickLabelNHSNumber(driver);
            EnterTextIntoNHSNumberField(driver, nhsNumber);
        }

        //This overload will generate a random NHS Number
        public static void EnterNHSNumber(IWebDriver driver)
        {
            // add NHS number
            // generate a random number 1st
            var number = DHCWExtensions.ReturnNHSNumber();
            // convert to a string so we can type it into out field
            string nhsNumber = number.ToString();
            Console.WriteLine("NHS Number generated randomly during this test. Number was: " + nhsNumber);
            ClickLabelNHSNumber(driver);
            EnterTextIntoNHSNumberField(driver, nhsNumber);
        }

        //This method will click the Label and then type into the First Name Text Box

        public static void EnterFirstName(IWebDriver driver, string firstName)
        {
            ClickLabelFirstName(driver);
            EnterTextIntoFirstNameField(driver, firstName);
        }

        //This method will click the Label and then type into the Last Name Text Box

        public static void EnterLastName(IWebDriver driver, string lastName)
        {
            ClickLabelLastName(driver);
            EnterTextIntoLastNameField(driver, lastName);
        }

        //Method to enter values into the Property Number field

        public static void EnterPropertyNumber(IWebDriver driver, string propertyNumber)
        {
            ClickLabelPropertyNumber(driver);
            EnterTextIntoTextBoxPropertyNumber(driver, propertyNumber);
        }

        //Method for entering text into the First Line of Address field

        public static void EnterFirstLineOfAddress(IWebDriver driver, string firstLineOfAddress)
        {
            ClickLabelFirstLineOfAddress(driver);
            EnterTextintoTextBoxFirstLineOfAddress(driver, firstLineOfAddress);

        }

        //Method for entering text into Town/City field

        public static void EnterTownCity(IWebDriver driver, string townCity)
        {

            ClickLabelTownCity(driver);
            EnterTextIntoTownCity(driver, townCity);
        }

        //Method for entering text into the County field

        public static void EnterCounty(IWebDriver driver, string county)
        {
            ClickLabelCounty(driver);
            EnterTextIntoTextBoxCounty(driver, county);
        }

        //A method for entering text into the Post Code field

        public static void EnterPostCode(IWebDriver driver, string postCode)
        {
            ClickLabelPostCode(driver);
            EnterTextIntoTextBoxPostCode(driver, postCode);
        }

        //Method for clearing Date MOved In field

        public static void ClearDateMovedIn(IWebDriver driver)
        {
            ClickLabelDateMovedIn(driver);
            ClearTextBoxDateMovedIn(driver);
        }

        //General Practitioner Details
        //Note: there is a sequence that must be followed when completing fields in the General Practitioner details section
        //Surgery/Practice must be entered first
        //GP Name must be entered second
        //GP Start Date
        //GP Name
        //Method for entering text into Surgery/Practice field 
        public static void SelectSurgeryPractice(IWebDriver driver, string surgeryPractice, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our surgeryPractice text
                LocateLabelSurgeryPractice(driver);
                ClickLabelSurgeryPractice(driver);
                ClickLookupButtonSurgeryPractice(driver);
                ClickSurgeryPracticeUsingLookup(driver, surgeryPractice);
            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelSurgeryPractice(driver);
                EnterTextIntoSurgeryPracticeField(driver, surgeryPractice);
            }
        }
 
        //Method to enter text into the GP Name field
        //Note: this field must be completed after the Surgery/Practice field has been completed

        public static void SelectGPName(IWebDriver driver, string name, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our GP Name 
                LocateLabelGPName(driver);
                ClickLabelGPName(driver);
                ClickLookupButtonGPName(driver);
                ClickGPNameUsingLookup(driver, name);
            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelGPName(driver);
                EnterTextIntoGPNameField(driver, name);
            }
        }

        //Method to enter a date into the GP Start Date field
        //Note: this field must be completed after the GP Name field has been completed

        public static void EnterGPStartDate(IWebDriver driver, string startDate, bool isUsingDatePicker = false)
        {
            try
            {
                if (isUsingDatePicker)
                {
                    throw new NotImplementedException();
                    //LocateDMIPickerButton
                    //SelectUsingDMIPicker
                }

                if (!isUsingDatePicker)
                {
                    ClickLabelGPStartDate(driver);
                    EnterTextIntoTextBoxGPStartDate(driver, startDate);
                }

            }
            catch
            {
                throw new Exception("You must enter a GP Name prior to entering a GP Start Date");

            }

            
        }

        //---------------------------------------------------------------------------------------------------------

        ///Private methods below - not to be called directly in tests

        //---------------------------------------------------------------------------------------------------------

        //Method to locate the County label

        private static IWebElement LocateLabelCounty(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"address1_stateorprovince_cl\"]"));
            IWebElement countyLabel = driver.FindElement(By.XPath("//*[@id=\"address1_stateorprovince_cl\"]"));
            return countyLabel;
        }

        //Method to click the County label

        private static void ClickLabelCounty(IWebDriver driver)
        {
            IWebElement countyLabel = LocateLabelCounty(driver);
            countyLabel.Click();
        }

        //Method to locate the County text box

        private static IWebElement LocateTextBoxCounty(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"address1_stateorprovince_i\"]"));
            IWebElement countyTextBox = driver.FindElement(By.XPath("//*[@id=\"address1_stateorprovince_i\"]"));
            return countyTextBox;
        }

        //Method to enter text into the County text box

        private static void EnterTextIntoTextBoxCounty(IWebDriver driver, string county)
        {
            IWebElement countyTextBox = LocateTextBoxCounty(driver);
            countyTextBox.SendKeys(county = Keys.Enter);
        }

        //Method to locate the Post Code label

        private static IWebElement LocateLabelPostCode(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"address1_postalcode_cl\"]"));
            IWebElement postCodeLabel = driver.FindElement(By.XPath("//*[@id=\"address1_postalcode_cl\"]"));
            return postCodeLabel;
        }

        //Method to click the Post Code label

        private static void ClickLabelPostCode(IWebDriver driver)
        {
            IWebElement postCodeLabel = LocateLabelPostCode(driver);
            postCodeLabel.Click();
        }

        //Method to locate the Post Code text box

        private static IWebElement LocateTextBoxPostCode(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"address1_postalcode_i\"]"));
            IWebElement postCodeTextBox = driver.FindElement(By.XPath("//*[@id=\"address1_postalcode_i\"]"));
            return postCodeTextBox;
        }

        //Method to enter text into the Post Code field

        private static void EnterTextIntoTextBoxPostCode(IWebDriver driver, string postCode)
        {
            IWebElement postCodeTextBox = LocateTextBoxPostCode(driver);
            postCodeTextBox.SendKeys(postCode + Keys.Return);
        }

        //Method to locate Town City label

        private static IWebElement LocateLabelTownCity(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"address1_city_cl\"]"));
            IWebElement townCityLabel = driver.FindElement(By.XPath("//*[@id=\"address1_city_cl\"]"));
            return townCityLabel;
        }

        //Method to click the Town City label

        private static void ClickLabelTownCity(IWebDriver driver)
        {
            IWebElement townCityLabel = LocateLabelTownCity(driver);
            townCityLabel.Click();
        }

        //Method to locate the Town City field

        private static IWebElement LocateTextBoxTownCity(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"address1_city_i\"]"));
            IWebElement townCityTextBox = driver.FindElement(By.XPath("//*[@id=\"address1_city_i\"]"));
            return townCityTextBox;
        }

        //Method to enter text into the Town City field

        private static void EnterTextIntoTownCity(IWebDriver driver, string townCity)
        {
            IWebElement townCityTextBox = LocateTextBoxTownCity(driver);
            townCityTextBox.SendKeys(townCity + Keys.Enter);
        }

        //Method to locate label First Line of Address field

        private static IWebElement LocateLabelFirstLineOfAddress(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"address1_line1_cl_span\"]"));
            IWebElement firstLineOfAddressLabel = driver.FindElement(By.XPath("//*[@id=\"address1_line1_cl_span\"]"));
            return firstLineOfAddressLabel;
        }

        //Method to click the First Line of Address label

        private static void ClickLabelFirstLineOfAddress(IWebDriver driver)
        {
            IWebElement firstLineOfAddressLabel = LocateLabelFirstLineOfAddress(driver);
            firstLineOfAddressLabel.Click();
        }

        //Method to locate the First Line of Address checkbox

        private static IWebElement LocateTextBoxFirstLineOfAddress(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"address1_line1_i\"]"));
            IWebElement firstLineOfAddressTextBox = driver.FindElement(By.XPath("//*[@id=\"address1_line1_i\"]"));
            return firstLineOfAddressTextBox;
        }

        //Method to enter text into the First Lie of Address field

        private static void EnterTextintoTextBoxFirstLineOfAddress(IWebDriver driver, string firstLineOfAddress)
        {
            IWebElement firstLineOfAddressTextBox = LocateTextBoxFirstLineOfAddress(driver);
            firstLineOfAddressTextBox.SendKeys(firstLineOfAddress + Keys.Enter);
        }

        //Method to locate Property Number label

        private static IWebElement LocateLabelPropertyNumber(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_propertyno_cl\"]"));
            IWebElement propertyNumberLabel = driver.FindElement(By.XPath("//*[@id=\"cw_propertyno_cl\"]"));
            return propertyNumberLabel;
        }

        //Method to click the Property Number label

        private static void ClickLabelPropertyNumber(IWebDriver driver)
        {
            IWebElement propertyNumberLabel = LocateLabelPropertyNumber(driver);
            propertyNumberLabel.Click();
        }

        //Method to locate the Property Number text box

        private static IWebElement LocateTextBoxPropertyNumber(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_propertyno_i\"]"));
            IWebElement propertyNumberTextBox = driver.FindElement(By.XPath("//*[@id=\"cw_propertyno_i\"]"));
            return propertyNumberTextBox;
        }

        //Method to enter text into the property number text box

        private static void EnterTextIntoTextBoxPropertyNumber(IWebDriver driver, string propertyNumber)
        {
            IWebElement propertyNumberTextBox = LocateTextBoxPropertyNumber(driver);
            propertyNumberTextBox.SendKeys(propertyNumber + Keys.Enter);
        }

        //Method to click the Ethnicity label

        private static void ClickLabelEthnicity(IWebDriver driver)
        {
            IWebElement ethnicityLabel = LocateEthnicityLabel(driver);
            ethnicityLabel.Click();
        }

        //Method to select a value from the Ethnicity lookup

        private static void SelectEthnicityUsingLookup(IWebDriver driver, string ethnicity)
        {
            IWebElement lookUpButton = LocateEthnicityLookupButton(driver);
            lookUpButton.Click();
            IWebElement ethnicityFromMenu = LocateEthnicityFromMenu(driver, ethnicity);
            ethnicityFromMenu.Click();
        }

        //Method for entering text into the Date Moved In field

        private static void EnterTextIntoTextBoxDateMovedIn(IWebDriver driver, string dateMovedIn)
        {
            IWebElement textBoxDateMovedIn = LocateTextBoxDateMovedIn(driver);
            textBoxDateMovedIn.SendKeys(dateMovedIn);
        }

        //Method for locating the Date Moved In text box

        private static IWebElement LocateTextBoxDateMovedIn(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("cw_datepersonmovedin_iDateInput"));
            IWebElement textBoxDateMovedIn = driver.FindElement(By.Id("cw_datepersonmovedin_iDateInput"));
            return textBoxDateMovedIn;
        }

        //Method for clicking the Date Moved In label

        private static void ClickLabelDateMovedIn(IWebDriver driver)
        {
            IWebElement dateMovedInLabel = LocateDivDateMovedIn(driver);
            dateMovedInLabel.Click();
        }

        //Method to locate Date Moved In Div

        private static IWebElement LocateDivDateMovedIn(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("cw_datepersonmovedin"));
            IWebElement dateMovedInLabel = driver.FindElement(By.Id("cw_datepersonmovedin"));
            return dateMovedInLabel;
        }

        //Method to click the Gender label

        private static void ClickLabelGender(IWebDriver driver)
        {
            IWebElement genderLabel = LocateLabelGender(driver);
            genderLabel.Click();
        }

        //Method to select a Gender fron the dropdown

        private static void SelectGenderFromDropDown(IWebDriver driver, string gender)
        {
            IWebElement genderDropDown = LocateDropDownGender(driver);
            var selectElementGender = new SelectElement(genderDropDown);
            selectElementGender.SelectByText(gender);
        }

        //Method to locate Gender dropdown menu

        private static IWebElement LocateDropDownGender(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("gendercode_i"));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement genderDropDown = driver.FindElement(By.Id("gendercode_i"));
            return genderDropDown;
        }

        //Method to locate Gender label

        private static IWebElement LocateLabelGender(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("gendercode"));
            IWebElement genderLabel = driver.FindElement(By.Id("gendercode"));
            return genderLabel;
        }

        //Method to click Peferred Language from lookup

        private static void ClickPreferredLanguageUsingLookup(IWebDriver driver, string preferredLanguage)
        {
            IWebElement preferredLanguageFromLookup = LocatePreferredLanguageFromLookup(driver, preferredLanguage);
            preferredLanguageFromLookup.Click();
        }

        //Method to locate Preferred Language from lookup

        private static IWebElement LocatePreferredLanguageFromLookup(IWebDriver driver, string preferredLanguage)
        {
            //Note that if the ethnicity button is clicked more than once you will generate a new ID each time
            driver.WaitUntilVisible(By.XPath("//a[@title='" + preferredLanguage + "']"));
            IWebElement preferredLanguageFromMenu = driver.FindElement(By.XPath("//a[@title='" + preferredLanguage + "']"));
            return preferredLanguageFromMenu;
        }

        //Method to click Preferred Language lookup button

        private static void ClickLookupButtonPreferredLanguage(IWebDriver driver)
        {
            IWebElement lookupButtonPreferredLanguage = LocateLookupButtonPreferredLanguage(driver);
            lookupButtonPreferredLanguage.Click();
        }

        //Method to locate the Preferred Language lookup

        private static IWebElement LocateLookupButtonPreferredLanguage(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("cw_languageid_lookupSearch"));
            IWebElement lookupButtonPreferredLanguage = driver.FindElement(By.Id("cw_languageid_lookupSearch"));
            return lookupButtonPreferredLanguage;
        }

        //Method to enter text into the Preferred Language field

        private static void EnterTextIntoPreferredLanguageField(IWebDriver driver, string preferredLanguage)
        {
            IWebElement textBoxPreferredLanguage = LocateTextBoxPreferredLanguage(driver);
            textBoxPreferredLanguage.SendKeys(preferredLanguage);
        }

        //Method to locate the Preferred Language checkbox

        private static IWebElement LocateTextBoxPreferredLanguage(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("cw_languageid_ledit"));
            IWebElement textBoxPreferredLanguage = driver.FindElement(By.Id("cw_languageid_ledit"));
            return textBoxPreferredLanguage;
        }

        //Method to click the Preferred Language label

        private static void ClickLabelPreferredLanguage(IWebDriver driver)
        {
            IWebElement label = LocateLabelPreferredLanguage(driver);
            label.Click();
        }

        //Method to locate the Preferred Language label

        private static IWebElement LocateLabelPreferredLanguage(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("cw_languageid_cl"));
            IWebElement prefLanguageLabel = driver.FindElement(By.Id("cw_languageid_cl"));
            return prefLanguageLabel;
        }

        //Method to enter text into the Date of Birth field

        private static void EnterTextIntoDOBField(IWebDriver driver, string dateOfBirth)
        {
            //Send keys to the text box
            //will only work if you have clicked into the field to activate it
            IWebElement dobField = LocateTextBoxDOB(driver);
            dobField.SendKeys(dateOfBirth);
        }

        //Method to locate the text box Date of Birth

        private static IWebElement LocateTextBoxDOB(IWebDriver driver)
        {
            //locate the date of birth field only
            //use this field to act on the field e.g. send text or assert content.
            driver.WaitUntilVisible(By.XPath("//*[@id=\"birthdate_iDateInput\"]"));
            IWebElement textBoxDOB = driver.FindElement(By.XPath("//*[@id=\"birthdate_iDateInput\"]"));
            return textBoxDOB;
        }

        //Method to click the DOB label

        private static void ClickLabelDOB(IWebDriver driver)
        {
            //Just to click the element
            IWebElement label = LocateLabelDOB(driver);
            label.Click();
        }

        //Method to locate the DOB label

        private static IWebElement LocateLabelDOB(IWebDriver driver)
        {
            //Find label by ID and return it
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Date of Birth_label\"]"));
            IWebElement label = driver.FindElement(By.XPath("//*[@id=\"Date of Birth_label\"]"));
            return label;

        }

        //Method to enter text into the Ethnicity field

        private static void EnterTextIntoEthnicityField(IWebDriver driver, string ethnicity)
        {
            //Locate the box and send text to it
            //Not to be called directly in isolation
            //Method will fail unless you are clicked into the box 
            IWebElement ethnicityTextbox = LocateEthnicityBox(driver);
            ethnicityTextbox.SendKeys(ethnicity);
        }

        //Method to locate the Ethnicity label

        private static IWebElement LocateEthnicityLabel(IWebDriver driver)
        {
            //Note that the clicked element here is different to those used for last name etc. 
            driver.WaitUntilVisible(By.Id("cw_ethnicityid_cl_span"));
            IWebElement ethnicityLabel = driver.FindElement(By.Id("cw_ethnicityid_cl_span"));
            return ethnicityLabel;
        }

        //Method to locate the Ethnicity text box

        private static IWebElement LocateEthnicityBox(IWebDriver driver)
        {
            //Locate the ethnicity text box - this method does nothing with it
            driver.WaitUntilVisible(By.Id("cw_ethnicityid_ledit"));
            IWebElement ethnicityBox = driver.FindElement(By.Id("cw_ethnicityid_ledit"));
            return ethnicityBox;
        }

        //Method to locate the Ethnicity lookup button

        private static IWebElement LocateEthnicityLookupButton(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("cw_ethnicityid_lookupSearch"));
            IWebElement ethnicityLookupButton = driver.FindElement(By.Id("cw_ethnicityid_lookupSearch"));
            return ethnicityLookupButton;
        }

        //Method to locate Ethnicity from the menu

        private static IWebElement LocateEthnicityFromMenu(IWebDriver driver, string ethnicity)
        {
            //Note that if the ethnicity button is clicked more than once you will generate a new ID each time
            driver.WaitUntilVisible(By.XPath("//a[@title='" + ethnicity + "']"));
            IWebElement ethnicityFromMenu = driver.FindElement(By.XPath("//a[@title='" + ethnicity + "']"));
            return ethnicityFromMenu;
        }

        //Method to enter text into the Last Name field

        private static void EnterTextIntoLastNameField(IWebDriver driver, string lastName) 
        {
            //Locate the text box, then send a string into it
            //private method to protect this from being used as a step step, as you need to click into the field first
            IWebElement textBoxLastName = LocateTextBoxLastName(driver);
            textBoxLastName.SendKeys(lastName);
        }

        //Method to locate the Last Name text box

        private static IWebElement LocateTextBoxLastName(IWebDriver driver)
        {
            //Find the box only, do not do anything with it
            //Use this method if you are doing an action or check against the firstname input box
            //E.g. typing into it, asserting text inside it, etc.
            IWebElement textBoxLastName = driver.FindElement(By.Id("lastname_i"));
            driver.WaitUntilVisible(By.Id("lastname_i"));
            return textBoxLastName;
        }

        //Method to click the Last Name label

        private static void ClickLabelLastName(IWebDriver driver)
        {
            IWebElement labelLastName = LocateLabelLastName(driver);
            labelLastName.Click();
        }

        //Method to locate the LastName label

        private static IWebElement LocateLabelLastName(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("lastname_cl"));
            //Enter field by clicking on the label
            // Use this locate method also if you wish to, for example, check the text of the label. 
            IWebElement labelLastName = driver.FindElement(By.Id("lastname_cl"));
            return labelLastName;
        }

        //Method to enter text into FirstName field

        private static void EnterTextIntoFirstNameField(IWebDriver driver, string firstName)
        {
            //Locate the text box, then send a string into it
            //private method to protect this from being used as a step step, as you need to click into the field first
            IWebElement textBoxFirstName = LocateTextBoxFirstName(driver);
            textBoxFirstName.SendKeys(firstName);
        }

        //Method to click the FirstName label

        private static void ClickLabelFirstName(IWebDriver driver)
        {
            //Changed from div to be label
            IWebElement divFirstName = LocateLabelFirstName(driver);
            divFirstName.Click();
        
        }

        //Method to locate the FirstName text box

        private static IWebElement LocateTextBoxFirstName(IWebDriver driver) 
        {
            driver.WaitUntilVisible(By.Id("firstname_i"));
            //Find the box only, do not do anything with it
            //Use this method if you are doing an action or check against the firstname input box
            //E.g. typing into it, asserting text inside it, etc.
            IWebElement textBoxFirstName = driver.FindElement(By.Id("firstname_i"));
            return textBoxFirstName;
        }

        //Method to locate FirstName label

        private static IWebElement LocateLabelFirstName(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.Id("firstname_cl"));
            //Enter field by clicking on the label
            // Use this locate method also if you wish to, for example, check the text of the label. 

            IWebElement divFirstName = driver.FindElement(By.Id("firstname_cl"));
            return divFirstName;
        }

        //Method to locate NHS Number label

        private static IWebElement LocateLabelNHSNumber(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_nhsno_cl\"]"));
            //Call this method to interact with it (e.g. assert text, click)
            IWebElement nhsNumberLabel = driver.FindElement(By.XPath("//*[@id=\"cw_nhsno_cl\"]"));
            return nhsNumberLabel; 
        }

        //Method to click NHS Number label

        private static void ClickLabelNHSNumber(IWebDriver driver)
        {
            //Call this before the TextBox is used
            IWebElement nhsNumberLabel = LocateLabelNHSNumber(driver);
            nhsNumberLabel.Click();
        }

        //Method to locate the NHS Number text box

        private static IWebElement LocateTextBoxNHSNumber(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_nhsno_i\"]"));
            //Call click on label prior to use
            IWebElement nhsNumberTextBox = driver.FindElement(By.XPath("//*[@id=\"cw_nhsno_i\"]"));
            return nhsNumberTextBox;
        }

        //Method to enter text into the NHS Number field

        private static void EnterTextIntoNHSNumberField(IWebDriver driver, string nhsNumber)
        {
            //Will fail unless a click into the field via label occurs
            //private method - not to be called in main script
            IWebElement nhsNumberTextBox = LocateTextBoxNHSNumber(driver);
            nhsNumberTextBox.SendKeys(nhsNumber + Keys.Enter);
        }

        //Method to clear any values from the Date Moved In field

        private static void ClearTextBoxDateMovedIn(IWebDriver driver)
        {
            IWebElement dateMovedInTextBox = LocateTextBoxDateMovedIn(driver);
            dateMovedInTextBox.Clear();
        }

        //Method to locate the Surgery/Practice label

        private static IWebElement LocateLabelSurgeryPractice(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_surgerypracticeid_cl\"]"));
            IWebElement labelSurgeryPractice = driver.FindElement(By.XPath("//*[@id=\"cw_surgerypracticeid_cl\"]"));
            return labelSurgeryPractice;
        }

        //Method to click the Surgery/Practice label

        private static void ClickLabelSurgeryPractice(IWebDriver driver)
        {
            IWebElement labelSurgeryPractice = LocateLabelSurgeryPractice(driver);
            labelSurgeryPractice.Click();
        }

        //Method to locate the Surgery/Practice text box

        private static IWebElement LocateTextBoxSurgeryPractice(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_surgerypracticeid_ledit\"]"));
            IWebElement textBoxSurgeryPractice = driver.FindElement(By.XPath("//*[@id=\"cw_surgerypracticeid_ledit\"]"));
            return textBoxSurgeryPractice;
        }

        //Method to click the lookup button next to the Surgery/Practice field

        private static void ClickLookupButtonSurgeryPractice(IWebDriver driver)
        {
            LocateLabelSurgeryPractice(driver).Click();
            IWebElement lookupSurgeryPractice = driver.FindElement(By.XPath("//*[@id=\"cw_surgerypracticeid_lookupSearch\"]"));
            lookupSurgeryPractice.Click();
        }

        //Method to select a Surgery/Practice from the lookup menu

        private static void ClickSurgeryPracticeUsingLookup(IWebDriver driver, string surgeryPractice)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_surgerypracticeid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + surgeryPractice + "')]]")).Click();
        }

        //Method to enter text into the Surgery/Practice field

        private static void EnterTextIntoSurgeryPracticeField(IWebDriver driver, string surgeryPractice)
        {
            IWebElement textBoxSurgeryPractice = LocateTextBoxSurgeryPractice(driver);
            textBoxSurgeryPractice.SendKeys(surgeryPractice);
        }

        //Method to locate the GP Start Date label

        private static IWebElement LocateLabelGPStartDate(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_gpstartdate\"]/div[1]"));
            IWebElement labelGPStartDate = driver.FindElement(By.XPath("//*[@id=\"cw_gpstartdate\"]/div[1]"));
            return labelGPStartDate;
        }

        //Method to click the GP Start Date label

        private static void ClickLabelGPStartDate(IWebDriver driver)
        {
            IWebElement labelGPStartDate = LocateLabelGPStartDate(driver);
            labelGPStartDate.Click();
        }

        //Method to locate GP Start Date

        private static IWebElement LocateTextBoxGPStartDate(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_gpstartdate_iDateInput\"]"));
            IWebElement textBoxPreferredLanguage = driver.FindElement(By.XPath("//*[@id=\"cw_gpstartdate_iDateInput\"]"));
            return textBoxPreferredLanguage;
        }

        //Method to enter text into the GP Start Date field

        private static void EnterTextIntoTextBoxGPStartDate(IWebDriver driver, string startDate)
        {
            IWebElement textBoxGPStartDate = LocateTextBoxGPStartDate(driver);
            textBoxGPStartDate.SendKeys(startDate);
        }

        //Method to locate the GP Name label

        private static IWebElement LocateLabelGPName(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_gpid_cl\"]"));
            IWebElement labelGPName = driver.FindElement(By.XPath("//*[@id=\"cw_gpid_cl\"]"));
            return labelGPName;
        }

        //Method to click the GP Name label

        private static void ClickLabelGPName(IWebDriver driver)
        {
            IWebElement labelGPName = LocateLabelGPName(driver);
            labelGPName.Click();
        }

        //Method to click the lookup button next to the GP Name field

        private static void ClickLookupButtonGPName(IWebDriver driver)
        {
            IWebElement lookupGPName = driver.FindElement(By.XPath("//*[@id=\"cw_gpid_i\"]"));
            lookupGPName.Click();
        }

        //Method to select a Surgery/Practice from the lookup menu

        private static void ClickGPNameUsingLookup(IWebDriver driver, string name)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_gpid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + name + "')]]")).Click();
        }

        //Method to enter text into the GP Name field

        private static void EnterTextIntoGPNameField(IWebDriver driver, string name)
        {
            IWebElement textBoxSurgeryPractice = LocateTextBoxGPNameField(driver);
            textBoxSurgeryPractice.SendKeys(name);
        }

        //Method to locate GP Name text box

        private static IWebElement LocateTextBoxGPNameField(IWebDriver driver)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_gpid_ledit\"]"));
            IWebElement textBoxGPName = driver.FindElement(By.XPath("//*[@id=\"cw_gpid_ledit\"]"));
            return textBoxGPName;
        }


    }
}