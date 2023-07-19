using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Net;
using System.Reflection.Emit;
using System.Security.Policy;
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

        //return value in gender field
        public static string GetGender(IWebDriver driver)
        {
            string gender = GetGenderValue(driver);
            return gender;
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

        // Method for finding value in the Date of Birth field

        public static String GetDOBValue(IWebDriver driver)
        {
            string dobField = driver.FindElement(By.Id("birthdate")).Text;
            return dobField;
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

        //Get the NHS number within a record, unformatted (without spaces)
        public static string GetUnformattedNHS(IWebDriver driver)
        {
            //find NHS Number
            string NHSField = GetNHSNumber(driver);
            //remove any spaces within NHS number
            NHSField = NHSField.Replace(" ", "");
            // return the unformatted NHS number
            return NHSField;
        }

        //This method will click the Label and then type into the First Name Text Box

        public static void EnterFirstName(IWebDriver driver, string firstName)
        {
            ClickLabelFirstName(driver);
            EnterTextIntoFirstNameField(driver, firstName);
        }

        // Method for finding value in the First Name field

        public static String GetFirstNameValue(IWebDriver driver)
        {
            string firstNameField = driver.FindElement(By.Id("firstname")).Text;
            return firstNameField;
        }

        //This method will click the Label and then type into the Last Name Text Box

        public static void EnterLastName(IWebDriver driver, string lastName)
        {
            ClickLabelLastName(driver);
            EnterTextIntoLastNameField(driver, lastName);
        }

        // Method for finding value in the Last Name field

        public static String GetLastNameValue(IWebDriver driver)
        {
            string lastNameField = driver.FindElement(By.Id("lastname")).Text;
            return lastNameField;
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

        // Method for finding value in the First Line of Address field

        public static String GetStreetValue(IWebDriver driver)
        {
            string StreetField = driver.FindElement(By.Id("address1_line1")).Text;
            return StreetField;
        }

        // Method for finding value in the Second Line of Address field

        public static String GetOtherDesignationValue(IWebDriver driver)
        {
            string OtherDesField = driver.FindElement(By.Id("address1_line2")).Text;
            return OtherDesField;
        }

        //Method for entering text into Town/City field

        public static void EnterTownCity(IWebDriver driver, string townCity)
        {

            ClickLabelTownCity(driver);
            EnterTextIntoTownCity(driver, townCity);
        }

        // Method for finding value in the City/Town Line of Address field

        public static String GetCityValue(IWebDriver driver)
        {
            string CityField = driver.FindElement(By.Id("address1_city")).Text;
            return CityField;
        }

        //Method for entering text into the County field

        public static void EnterCounty(IWebDriver driver, string county)
        {
            ClickLabelCounty(driver);
            EnterTextIntoTextBoxCounty(driver, county);
        }

        // Method for finding value in the City/Town Line of Address field

        public static String GetCountyValue(IWebDriver driver)
        {
            string CountyField = driver.FindElement(By.Id("address1_stateorprovince")).Text;
            return CountyField;
        }

        //A method for entering text into the Post Code field

        public static void EnterPostCode(IWebDriver driver, string postCode)
        {
            ClickLabelPostCode(driver);
            EnterTextIntoTextBoxPostCode(driver, postCode);
        }

        // Method for finding value in the post code Line of Address field

        public static String GetPostCodeValue(IWebDriver driver)
        {
            string PostCodeField = driver.FindElement(By.Id("address1_postalcode")).Text;
            return PostCodeField;
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
                //Perform a check to see if the GP Start Date field has been populated, if it has then the order of field entry may be wrong, print a meaningful message to console
                bool isGPStartDatePopulated = IsGPStartDatePopulated(driver);

                if (isGPStartDatePopulated)
                {
                    Console.WriteLine("GP Start date was populated when you filled in the GP on the client, if your test is failing check that you are entering GP details before entering the start date.");
                }
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
                //Perform a check to see if the GP Start Date field has been populated, if it has then the order of field entry may be wrong, print a meaningful message to console
                bool isGPStartDatePopulated = IsGPStartDatePopulated(driver);

                if (isGPStartDatePopulated)
                {
                    Console.WriteLine("GP Start date was populated when you filled in the GP on the client, if your test is failing check that you are entering GP details before entering the start date.");
                }
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
            if (isUsingDatePicker)
            {
                throw new NotImplementedException();
                //LocateDMIPickerButton
                //SelectUsingDMIPicker
            }

            if (!isUsingDatePicker)
            {
                //Note: If we enter a value into the GP Name field, the GP Start date will automatically become active, so no need to click the label
                EnterTextIntoTextBoxGPStartDate(driver, startDate);
            }
        }


        //---------------------------------------------------------------------------------------------------------

        ///Private methods below - not to be called directly in tests

        //---------------------------------------------------------------------------------------------------------

        //Method to locate the County label

        private static IWebElement LocateLabelCounty(IWebDriver driver)
        {

            string labelCountyLocation = "//*[@id=\"address1_stateorprovince_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelCountyLocation));
            IWebElement countyLabel = driver.FindElement(By.XPath(labelCountyLocation));
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
            string textBoxCountyLocation = "//*[@id=\"address1_stateorprovince_i\"]";
            driver.WaitUntilVisible(By.XPath(textBoxCountyLocation));
            IWebElement countyTextBox = driver.FindElement(By.XPath(textBoxCountyLocation));
            return countyTextBox;
        }

        //Method to enter text into the County text box

        private static void EnterTextIntoTextBoxCounty(IWebDriver driver, string county)
        {
            LocateLabelCounty(driver).Click();
            IWebElement countyTextBox = LocateTextBoxCounty(driver);
            countyTextBox.SendKeys(county);
        }

        //Method to locate the Post Code label

        private static IWebElement LocateLabelPostCode(IWebDriver driver)
        {
            string labelPostCodeLocation = "//*[@id=\"address1_postalcode_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelPostCodeLocation));
            IWebElement postCodeLabel = driver.FindElement(By.XPath(labelPostCodeLocation));
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
            string textBoxPostCodeLocation = "//*[@id=\"address1_postalcode_i\"]";
            driver.WaitUntilVisible(By.XPath(textBoxPostCodeLocation));
            IWebElement postCodeTextBox = driver.FindElement(By.XPath(textBoxPostCodeLocation));
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
            string labelTownCityLocation = "//*[@id=\"address1_city_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelTownCityLocation));
            IWebElement townCityLabel = driver.FindElement(By.XPath(labelTownCityLocation));
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
            string textBoxTownCityLocation = "//*[@id=\"address1_city_i\"]";
            driver.WaitUntilVisible(By.XPath(textBoxTownCityLocation));
            IWebElement townCityTextBox = driver.FindElement(By.XPath(textBoxTownCityLocation));
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
            string labelFirstLineOfAddressLocation = "//*[@id=\"address1_line1_cl_span\"]";
            driver.WaitUntilVisible(By.XPath(labelFirstLineOfAddressLocation));
            IWebElement firstLineOfAddressLabel = driver.FindElement(By.XPath(labelFirstLineOfAddressLocation));
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
            string textBoxFirstLineOfAddressLocation = "//*[@id=\"address1_line1_i\"]";
            driver.WaitUntilVisible(By.XPath(textBoxFirstLineOfAddressLocation));
            IWebElement firstLineOfAddressTextBox = driver.FindElement(By.XPath(textBoxFirstLineOfAddressLocation));
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
            string labelPropertyNumberLocation = "//*[@id=\"cw_propertyno_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelPropertyNumberLocation));
            IWebElement propertyNumberLabel = driver.FindElement(By.XPath(labelPropertyNumberLocation));
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
            string textBoxPropertyNumberLocation = "//*[@id=\"cw_propertyno_i\"]";
            driver.WaitUntilVisible(By.XPath(textBoxPropertyNumberLocation));
            IWebElement propertyNumberTextBox = driver.FindElement(By.XPath(textBoxPropertyNumberLocation));
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
            string textBoxDateMovedInLocation = "cw_datepersonmovedin_iDateInput";
            driver.WaitUntilVisible(By.Id(textBoxDateMovedInLocation));
            IWebElement textBoxDateMovedIn = driver.FindElement(By.Id(textBoxDateMovedInLocation));
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
            string divDateMovedInLocation = "cw_datepersonmovedin";
            driver.WaitUntilVisible(By.Id(divDateMovedInLocation));
            IWebElement dateMovedInLabel = driver.FindElement(By.Id(divDateMovedInLocation));
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
            string dropDownGenderLocation = "gendercode_i";
            driver.WaitUntilVisible(By.Id(dropDownGenderLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement genderDropDown = driver.FindElement(By.Id(dropDownGenderLocation));
            return genderDropDown;
        }

        //Method to locate Gender label

        private static IWebElement LocateLabelGender(IWebDriver driver)
        {
            string labelGenderLocation = "gendercode";
            driver.WaitUntilVisible(By.Id(labelGenderLocation));
            IWebElement genderLabel = driver.FindElement(By.Id(labelGenderLocation));
            return genderLabel;
        }

        //Method to locate value in Gender field
        private static string GetGenderValue(IWebDriver driver)
        {
            string gender = driver.FindElement(By.Id("gendercode")).Text;
            return gender;
        }

        //Method to click Preferred Language from lookup

        private static void ClickPreferredLanguageUsingLookup(IWebDriver driver, string preferredLanguage)
        {
            IWebElement preferredLanguageFromLookup = LocatePreferredLanguageFromLookup(driver, preferredLanguage);
            preferredLanguageFromLookup.Click();
        }

        //Method to locate Preferred Language from lookup

        private static IWebElement LocatePreferredLanguageFromLookup(IWebDriver driver, string preferredLanguage)
        {
            string preferredLanguageFromLookupLocation = "//a[@title='" + preferredLanguage + "']";
            //Note that if the ethnicity button is clicked more than once you will generate a new ID each time
            driver.WaitUntilVisible(By.XPath(preferredLanguageFromLookupLocation));
            IWebElement preferredLanguageFromMenu = driver.FindElement(By.XPath(preferredLanguageFromLookupLocation));
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
            string lookupButtonPreferredLanguageLocation = "cw_languageid_lookupSearch";
            driver.WaitUntilVisible(By.Id(lookupButtonPreferredLanguageLocation));
            IWebElement lookupButtonPreferredLanguage = driver.FindElement(By.Id(lookupButtonPreferredLanguageLocation));
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
            string textBoxPreferredLanguageLocation = "cw_languageid_ledit";
            driver.WaitUntilVisible(By.Id(textBoxPreferredLanguageLocation));
            IWebElement textBoxPreferredLanguage = driver.FindElement(By.Id(textBoxPreferredLanguageLocation));
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
            string labelPreferredLanguageLocation = "cw_languageid_cl";
            driver.WaitUntilVisible(By.Id(labelPreferredLanguageLocation));
            IWebElement prefLanguageLabel = driver.FindElement(By.Id(labelPreferredLanguageLocation));
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
            string textBoxDOBLocation = "//*[@id=\"birthdate_iDateInput\"]";
            //locate the date of birth field only
            //use this field to act on the field e.g. send text or assert content.
            driver.WaitUntilVisible(By.XPath(textBoxDOBLocation));
            IWebElement textBoxDOB = driver.FindElement(By.XPath(textBoxDOBLocation));
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
            string labelDOBLocation = "//*[@id=\"Date of Birth_label\"]";
            //Find label by ID and return it
            driver.WaitUntilVisible(By.XPath(labelDOBLocation));
            IWebElement label = driver.FindElement(By.XPath(labelDOBLocation));
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
            string labelEthnicityLocation = "cw_ethnicityid_cl_span";
            //Note that the clicked element here is different to those used for last name etc. 
            driver.WaitUntilVisible(By.Id(labelEthnicityLocation));
            IWebElement ethnicityLabel = driver.FindElement(By.Id(labelEthnicityLocation));
            return ethnicityLabel;
        }

        //Method to locate the Ethnicity text box

        private static IWebElement LocateEthnicityBox(IWebDriver driver)
        {
            string textBoxEthnicityLocation = "cw_ethnicityid_ledit";
            //Locate the ethnicity text box - this method does nothing with it
            driver.WaitUntilVisible(By.Id(textBoxEthnicityLocation));
            IWebElement ethnicityBox = driver.FindElement(By.Id(textBoxEthnicityLocation));
            return ethnicityBox;
        }

        //Method to locate the Ethnicity lookup button

        private static IWebElement LocateEthnicityLookupButton(IWebDriver driver)
        {
            string lookupButtonEthnicityLocation = "cw_ethnicityid_lookupSearch";
            driver.WaitUntilVisible(By.Id(lookupButtonEthnicityLocation));
            IWebElement ethnicityLookupButton = driver.FindElement(By.Id(lookupButtonEthnicityLocation));
            return ethnicityLookupButton;
        }

        //Method to locate Ethnicity from the menu

        private static IWebElement LocateEthnicityFromMenu(IWebDriver driver, string ethnicity)
        {
            string ethnicityFromMenuLocation = "//a[@title='" + ethnicity + "']";
            //Note that if the ethnicity button is clicked more than once you will generate a new ID each time
            driver.WaitUntilVisible(By.XPath(ethnicityFromMenuLocation));
            IWebElement ethnicityFromMenu = driver.FindElement(By.XPath(ethnicityFromMenuLocation));
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
            string textBoxLastNameLocation = "lastname_i";
            //Find the box only, do not do anything with it
            //Use this method if you are doing an action or check against the firstname input box
            //E.g. typing into it, asserting text inside it, etc.
            driver.WaitUntilVisible(By.Id(textBoxLastNameLocation));
            IWebElement textBoxLastName = driver.FindElement(By.Id(textBoxLastNameLocation));
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
            string labelLastNameLocation = "lastname_cl";
            driver.WaitUntilVisible(By.Id(labelLastNameLocation));
            //Enter field by clicking on the label
            // Use this locate method also if you wish to, for example, check the text of the label. 
            IWebElement labelLastName = driver.FindElement(By.Id(labelLastNameLocation));
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
            string textBoxFirstNameLocation = "firstname_i";
            driver.WaitUntilVisible(By.Id(textBoxFirstNameLocation));
            //Find the box only, do not do anything with it
            //Use this method if you are doing an action or check against the firstname input box
            //E.g. typing into it, asserting text inside it, etc.
            IWebElement textBoxFirstName = driver.FindElement(By.Id(textBoxFirstNameLocation));
            return textBoxFirstName;
        }

        //Method to locate FirstName label

        private static IWebElement LocateLabelFirstName(IWebDriver driver)
        {
            string labelFirstNameLocation = "firstname_cl";
            driver.WaitUntilVisible(By.Id(labelFirstNameLocation));
            //Enter field by clicking on the label
            // Use this locate method also if you wish to, for example, check the text of the label. 
            IWebElement divFirstName = driver.FindElement(By.Id(labelFirstNameLocation));
            return divFirstName;
        }

        //Method to locate NHS Number label

        private static IWebElement LocateLabelNHSNumber(IWebDriver driver)
        {
            string labelNHSNumberLocation = "//*[@id=\"cw_nhsno_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelNHSNumberLocation));
            //Call this method to interact with it (e.g. assert text, click)
            IWebElement nhsNumberLabel = driver.FindElement(By.XPath(labelNHSNumberLocation));
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
            string textBoxNHSNumberLocation = "//*[@id=\"cw_nhsno_i\"]";
            driver.WaitUntilVisible(By.XPath(textBoxNHSNumberLocation));
            //Call click on label prior to use
            IWebElement nhsNumberTextBox = driver.FindElement(By.XPath(textBoxNHSNumberLocation));
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

        // Get value in NHS field and return

        private static string GetNHSNumber(IWebDriver driver)
        {
            //Find the value in NHS Number field
            String NHSField = driver.FindElement(By.Id("cw_nhsno")).Text;
            // return the field
            return NHSField;
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
            string labelSurgeryPracticeLocation = "//*[@id=\"cw_surgerypracticeid_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelSurgeryPracticeLocation));
            IWebElement labelSurgeryPractice = driver.FindElement(By.XPath(labelSurgeryPracticeLocation));
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
            string textBoxSurgeryPracticeLocation = "//*[@id=\"cw_surgerypracticeid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(textBoxSurgeryPracticeLocation));
            IWebElement textBoxSurgeryPractice = driver.FindElement(By.XPath(textBoxSurgeryPracticeLocation));
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
            string labelGPStartDateLocation = "//*[@id=\"cw_gpstartdate\"]/div[1]";
            driver.WaitUntilVisible(By.XPath(labelGPStartDateLocation));
            IWebElement labelGPStartDate = driver.FindElement(By.XPath(labelGPStartDateLocation));
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
            string textBoxGPStartDateLocation = "//*[@id=\"cw_gpstartdate_iDateInput\"]";
            driver.WaitUntilVisible(By.XPath(textBoxGPStartDateLocation));
            IWebElement textBoxPreferredLanguage = driver.FindElement(By.XPath(textBoxGPStartDateLocation));
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
            string labelGPNameLocation = "//*[@id=\"cw_gpid_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelGPNameLocation));
            IWebElement labelGPName = driver.FindElement(By.XPath(labelGPNameLocation));
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
            string labelGPNameLocation = "//*[@id=\"cw_gpid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(labelGPNameLocation));
            IWebElement textBoxGPName = driver.FindElement(By.XPath(labelGPNameLocation));
            return textBoxGPName;
        }

        //Method to locate GP Name text box

        private static bool IsGPStartDatePopulated(IWebDriver driver)
        {
            LocateLabelGPStartDate(driver);
            ClickLabelGPStartDate(driver);

            IWebElement inputBox = driver.FindElement(By.XPath("//*[@id=\"cw_gpstartdate_iDateInput\"]"));
            string textInsideInputBox = inputBox.GetAttribute("value");

            // Check whether input field is blank
            if (textInsideInputBox == "")
            {
                return false;
            } else
            {
                return true;
            }

        }

    }
}