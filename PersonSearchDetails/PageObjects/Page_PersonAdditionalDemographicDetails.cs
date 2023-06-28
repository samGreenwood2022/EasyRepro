using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WCCIS.Specs.PageObjects
{
    internal class Page_PersonAdditionalDemographicDetails
    {        
        //public

        //Method to open the Additional Demographic Details section

        public static void OpenAdditionalDemographicDetails(IWebDriver driver)
        {
            IWebElement additionalDemographicDetails = LocateButtonAdditionalDemographicDetails(driver);
            additionalDemographicDetails.Click();//Deal with this better
            additionalDemographicDetails.Click();
            //Accept the alert when displayed
            try
            {
                WebDriverWait Wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
                Wait.Until(ExpectedConditions.AlertIsPresent());
                AcceptAlert(driver);
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("The Alert has not been displayed");
            }
        }

        //Method to enter text into the Target Group field


        public static void EnterTargetGroup(IWebDriver driver, string targetGroup, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our value
                ClickLabelTargetGroup(driver);
                ClickLookupTargetGroup(driver);
                SelectTargetGroupUsingLookup(driver, targetGroup);

            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelTargetGroup(driver);
                EnterTargetGroup(driver, targetGroup);
            }
        }


        //Method to enter text into the Leaving Care field


        public static void EnterLeavingCare(IWebDriver driver, string leavingCare, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our value
                ClickLabelLeavingCare(driver);
                ClickLookupLeavingCare(driver);
                SelectLeavingCareUsingLookup(driver, leavingCare);

            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelLeavingCare(driver);
                EnterTextIntoLeavingCareField(driver, leavingCare);
            }
        }

        //Method to enter a enter a value into the Maiden Name field

        public static void EnterMaidenName(IWebDriver driver, string maidenName)
        {
            ClickLabelMaidenName(driver);
            EnterTextIntoMaidenNameField(driver, maidenName);
        }

        //Method to select a County of Origin from dropdown

        public static void EnterCountyOfOrigin(IWebDriver driver, string countryOfOrigin)
        {
            //This is the public method - as in other fields you must select it first
            //You do this by clicking into the field ClickCountryOfOrigin Label
            //This activates the field, so you can set the dropdown
            ClickLabelCountryOfOrigin(driver);
            SelectCountryOfOriginFromDropDown(driver, countryOfOrigin);
        }

        //Method to enter text into the Last Menstrual Period (LMP)

        public static void EnterLastMenstrualPeriod(IWebDriver driver, string lastMenstrualPeriodDate, bool isUsingDatePicker = false)
        {
            if (isUsingDatePicker)
            {
                throw new NotImplementedException();
                //LocateDMIPickerButton
                //SelectUsingDMIPicker
            }

            if (!isUsingDatePicker)
            {
                ClickLabelLastMenstrualPeriod(driver);
                EnterTextIntoFieldLastMenstrualPeriod(driver, lastMenstrualPeriodDate);
            }
        }

        //Method to enter a enter a value into the Weeks Gestation field

        public static void EnterWeeksGestation(IWebDriver driver, string weeksGestation)
        {
            ClickLabelWeeksGestation(driver);
            EnterTextIntoFieldWeeksGestation(driver, weeksGestation);
        }


        //Method to select a Nationality from dropdown

        public static void EnterNationality(IWebDriver driver, string nationality)
        {
            ClickLabelNationality(driver);
            SelectNationalityFromDropDown(driver, nationality);
        }


        //Method to select a Sexual Orientation from dropdown

        public static void EnterSexualOrientation(IWebDriver driver, string sexualOrientation)
        {
            ClickLabelSexualOrientation(driver);
            SelectSexualOrientationFromDropDown(driver, sexualOrientation);
        }


        //Method to select an option from the Veteran dropdown

        public static void EnterVeteran(IWebDriver driver, string isVeteran)
        {
            ClickLabelVeteran(driver);
            SelectIsVeteranFromDropDown(driver, isVeteran);
        }


        //Method to select an option from the Interpreter Required dropdown

        public static void EnterInterpreterRequired(IWebDriver driver, string isInterpreterRequired)
        {
            ClickLabelInterpreterRequired(driver);
            SelectIsInterpreterRequiredFromDropDown(driver, isInterpreterRequired);
        }


        //Method to enter a enter a value into the NHS Card Location field

        public static void EnterNHSCardLocation(IWebDriver driver, string nhsCardLocation)
        {
            ClickLabelNHSCardLocation(driver);
            EnterTextIntoFieldNHSCardLocation(driver, nhsCardLocation);
        }


        //Method to enter text into the Immigration Status field

        public static void EnterImmigrationStatus(IWebDriver driver, string immigrationStatus, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our value
                ClickLabelImmigrationStatus(driver);
                ClickLookupImmigrationStatus(driver);
                SelectImmigrationStatusUsingLookup(driver, immigrationStatus);

            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelImmigrationStatus(driver);
                EnterImmigrationStatus(driver, immigrationStatus);
            }
        }


        //Method a enter a value into the Place of Birth field

        public static void EnterPlaceOfBirth(IWebDriver driver, string placeOfBirth)
        {
            ClickLabelPlaceOfBirth(driver);
            EnterTextIntoFieldPlaceOfBirth(driver, placeOfBirth);
        }


        //Method to select an option from the Lives Alone dropdown

        public static void EnterLivesAlone(IWebDriver driver, string livesAlone)
        {
            ClickLabelLivesAlone(driver);
            SelectLivesAloneOptionFromDropDown(driver, livesAlone);
        }


        //Method a enter a value into the Date Of Birth (Pre 1900) field

        public static void EnterDOBPre1900(IWebDriver driver, string dob)
        {
            ClickLabelDOBPre1900(driver);
            EnterTextIntoFieldDOBPre1900(driver, dob);
        }


        //Method to enter text into the LMP Confirmed By field


        public static void EnterLMPConfirmedBy(IWebDriver driver, string lmpConfirmedBy, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our value
                ClickLabelLMPConfirmedBy(driver);
                ClickLookupLMPConfirmedBy(driver);
                SelectLMPConfirmedByUsingLookup(driver, lmpConfirmedBy);

            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelLMPConfirmedBy(driver);
                EnterTextIntoLMPConfirmedByField(driver, lmpConfirmedBy);
            }
        }




        //private

        //Method to accept an alert

        private static void AcceptAlert(IWebDriver driver)
        {
            //Accept the alert thats displayed
            driver.SwitchTo().Alert().Accept();

        }

        //Method to locate the Additional Demographic Details button

        private static IWebElement LocateButtonAdditionalDemographicDetails(IWebDriver driver)
        {
            string buttonAdditionalDemographicDetails = "//*[@id=\"AdditionalInfoButton\"]";
            driver.WaitUntilVisible(By.XPath(buttonAdditionalDemographicDetails));
            IWebElement buttonLocation = driver.FindElement(By.XPath(buttonAdditionalDemographicDetails));
            return buttonLocation;

        }

        //Method to click the click the Target Group label

        private static void ClickLabelTargetGroup(IWebDriver driver)
        {
            string labelTargetGroup = "//*[@id=\"cw_targetgroupreferenceid_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelTargetGroup));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelTargetGroup));
            labelLocation.Click();
        }

        //Method to enter text into the Target Group field

        private static void EnterTextIntoTargetGroupField(IWebDriver driver, string targetGroup)
        {
            string textFieldTargetGroup = "//*[@id=\"cw_targetgroupreferenceid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(textFieldTargetGroup));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldTargetGroup));
            inputField.SendKeys(targetGroup);
        }

        //Method to click the lookup button next to the Target Group field

        private static void ClickLookupTargetGroup(IWebDriver driver)
        {
            IWebElement lookupTargetGroup = driver.FindElement(By.XPath("//*[@id=\"cw_targetgroupreferenceid_i\"]"));
            lookupTargetGroup.Click();
        }


        //Method to select a Target Group from the lookup menu

        private static void SelectTargetGroupUsingLookup(IWebDriver driver, string targetGroup)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_targetgroupreferenceid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + targetGroup + "')]]")).Click();
        }


        //Method to click the click the Leaving Care label

        private static void ClickLabelLeavingCare(IWebDriver driver)
        {
            string labelLeavingCare = "//*[@id=\"cw_leavingcareeligibilityid_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelLeavingCare));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelLeavingCare));
            labelLocation.Click();
        }


        //Method to click the lookup button next to the Leaving Care field

        private static void ClickLookupLeavingCare(IWebDriver driver)
        {
            IWebElement lookupTargetGroup = driver.FindElement(By.XPath("//*[@id=\"cw_leavingcareeligibilityid_i\"]"));
            lookupTargetGroup.Click();
        }


        //Method to select a Leaving Care from the lookup menu

        private static void SelectLeavingCareUsingLookup(IWebDriver driver, string leavingCare)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_leavingcareeligibilityid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + leavingCare + "')]]")).Click();
        }


        //Method to enter text into the Leaving Care field

        private static void EnterTextIntoLeavingCareField(IWebDriver driver, string leavingCare)
        {
            string textFieldLeavingCare = "//*[@id=\"cw_leavingcareeligibilityid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(textFieldLeavingCare));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldLeavingCare));
            inputField.SendKeys(leavingCare);
        }


        //Method to click the click the Maiden Name label

        private static void ClickLabelMaidenName(IWebDriver driver)
        {
            string labelMaidenName = "//*[@id=\"cw_maidenname_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelMaidenName));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelMaidenName));
            labelLocation.Click();
        }


        //Method to enter text into the Maiden Name field

        private static void EnterTextIntoMaidenNameField(IWebDriver driver, string leavingCare)
        {
            string textFieldMaidenName = "//*[@id=\"cw_maidenname_i\"]";
            driver.WaitUntilVisible(By.XPath(textFieldMaidenName));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldMaidenName));
            inputField.SendKeys(leavingCare);
        }


        //Method to click the click the Country of Origin label

        private static void ClickLabelCountryOfOrigin(IWebDriver driver)
        {
            string labelCountryOfOrigin = "//*[@id=\"cw_countryoforigin_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelCountryOfOrigin));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelCountryOfOrigin));
            labelLocation.Click();
        }


        //Method to select a Country of Origin from the dropdown

        private static void SelectCountryOfOriginFromDropDown(IWebDriver driver, string countryOfOrigin)
        {
            IWebElement countryOfOriginDropDown = LocateDropDownCountryOfOrigin(driver);
            var selectElementCountryOfOrigin = new SelectElement(countryOfOriginDropDown);
            selectElementCountryOfOrigin.SelectByText(countryOfOrigin);
        }

        //Method to locate Country of Origin from the dropdown

        private static IWebElement LocateDropDownCountryOfOrigin(IWebDriver driver)
        {
            string dropDownCountryOfOriginLocation = "cw_countryoforigin_i";
            driver.WaitUntilVisible(By.Id(dropDownCountryOfOriginLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement countryOfOriginDropDown = driver.FindElement(By.Id(dropDownCountryOfOriginLocation));
            return countryOfOriginDropDown;
        }

        //Method to click the click the Religion label

        private static void ClickLabelReligion(IWebDriver driver)
        {
            string labelReligion = "//*[@id=\"cw_religion_cl_span\"]";
            driver.WaitUntilVisible(By.XPath(labelReligion));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelReligion));
            labelLocation.Click();
        }


        //Method to select a Religion from the dropdown

        private static void SelectReligionFromDropDown(IWebDriver driver, string religion)
        {
            IWebElement religionDropDown = LocateDropDownReligion(driver);
            var selectElementReligion = new SelectElement(religionDropDown);
            selectElementReligion.SelectByText(religion);
        }

        //Method to locate Religion from the dropdown

        private static IWebElement LocateDropDownReligion(IWebDriver driver)
        {
            string dropDownReligionLocation = "cw_religion_i";
            driver.WaitUntilVisible(By.Id(dropDownReligionLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement religionDropDown = driver.FindElement(By.Id(dropDownReligionLocation));
            return religionDropDown;
        }

        //Method to click the click the Last Menstrual Period label

        private static void ClickLabelLastMenstrualPeriod(IWebDriver driver)
        {
            string labelLastMenstrualPeriod = "//*[@id=\"cw_lastmenstrualperiod\"]";
            driver.WaitUntilVisible(By.XPath(labelLastMenstrualPeriod));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelLastMenstrualPeriod));
            labelLocation.Click();
        }

        //Method to enter text into the Last Menstrual Period field

        private static void EnterTextIntoFieldLastMenstrualPeriod(IWebDriver driver, string lastMenstrualPeriodDate)
        {
            string textFieldLastMenstrualPeriod = "//*[@id=\"cw_lastmenstrualperiod_iDateInput\"]";
            driver.WaitUntilVisible(By.XPath(textFieldLastMenstrualPeriod));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldLastMenstrualPeriod));
            inputField.SendKeys(lastMenstrualPeriodDate);
        }

        //Method to click the click the Weeks Gestation label

        private static void ClickLabelWeeksGestation(IWebDriver driver)
        {
            string labelWeeksGestation = "//*[@id=\"cw_weeksgestation_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelWeeksGestation));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelWeeksGestation));
            labelLocation.Click();
        }

        //Method to enter text into the Weeks Gestation field

        private static void EnterTextIntoFieldWeeksGestation(IWebDriver driver, string weeksGestation)
        {
            string textFieldWeeksGestation = "//*[@id=\"cw_weeksgestation_i\"]";
            driver.WaitUntilVisible(By.XPath(textFieldWeeksGestation));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldWeeksGestation));
            inputField.SendKeys(weeksGestation);
        }

        //Method to click the click the Nationality label

        private static void ClickLabelNationality(IWebDriver driver)
        {
            string labelNationality = "//*[@id=\"cw_nationality_cl_span\"]";
            driver.WaitUntilVisible(By.XPath(labelNationality));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelNationality));
            labelLocation.Click();
        }


        //Method to select a Nationality from the dropdown

        private static void SelectNationalityFromDropDown(IWebDriver driver, string nationality)
        {
            IWebElement dropDownNationality = LocateDropDownNationality(driver);
            var selectNationality = new SelectElement(dropDownNationality);
            selectNationality.SelectByText(nationality);
        }

        //Method to locate Nationality from the dropdown

        private static IWebElement LocateDropDownNationality(IWebDriver driver)
        {
            string dropDownNationalityLocation = "cw_nationality_i";
            driver.WaitUntilVisible(By.Id(dropDownNationalityLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement nationalityDropDown = driver.FindElement(By.Id(dropDownNationalityLocation));
            return nationalityDropDown;
        }


        //Method to click the click the Sexual Orientation label

        private static void ClickLabelSexualOrientation(IWebDriver driver)
        {
            string labelSexualOrientation = "//*[@id=\"cw_sexualorientation_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelSexualOrientation));
            IWebElement labeSexualOrientation = driver.FindElement(By.XPath(labelSexualOrientation));
            labeSexualOrientation.Click();
        }


        //Method to select a Sexual Orientation from the dropdown

        private static void SelectSexualOrientationFromDropDown(IWebDriver driver, string sexualOrientation)
        {
            IWebElement dropDownSexualOrientation = LocateDropDownSexualOrientation(driver);
            var selectSexualOrientation = new SelectElement(dropDownSexualOrientation);
            selectSexualOrientation.SelectByText(sexualOrientation);
        }

        //Method to locate Sexual Orientation from the dropdown

        private static IWebElement LocateDropDownSexualOrientation(IWebDriver driver)
        {
            string dropDownSexualOrientationLocation = "cw_sexualorientation_i";
            driver.WaitUntilVisible(By.Id(dropDownSexualOrientationLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement sexualOrientationDropDown = driver.FindElement(By.Id(dropDownSexualOrientationLocation));
            return sexualOrientationDropDown;
        }


        //Method to click the click the Veteran label

        private static void ClickLabelVeteran(IWebDriver driver)
        {
            string labelVeteranLocation = "//*[@id=\"cw_veteran_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelVeteranLocation));
            IWebElement labeVeteran = driver.FindElement(By.XPath(labelVeteranLocation));
            labeVeteran.Click();
        }


        //Method to select a Veteran from the dropdown

        private static void SelectIsVeteranFromDropDown(IWebDriver driver, string isVeteran)
        {
            IWebElement dropDownVeteran = LocateDropDownVeteran(driver);
            var selectVeteran = new SelectElement(dropDownVeteran);
            selectVeteran.SelectByValue(isVeteran);
        }

        //Method to locate Veteran from the dropdown

        private static IWebElement LocateDropDownVeteran(IWebDriver driver)
        {
            string dropDownVeteranLocation = "cw_veteran_i";
            driver.WaitUntilVisible(By.Id(dropDownVeteranLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement veteranDropDown = driver.FindElement(By.Id(dropDownVeteranLocation));
            return veteranDropDown;
        }


        //Method to click the click the Interpreter Required label

        private static void ClickLabelInterpreterRequired(IWebDriver driver)
        {
            string labelInterpreterRequiredLocation = "//*[@id=\"cw_interpreterrequired_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelInterpreterRequiredLocation));
            IWebElement labeInterpreterRequired = driver.FindElement(By.XPath(labelInterpreterRequiredLocation));
            labeInterpreterRequired.Click();
        }


        //Method to select an option for Interpreter Required from the dropdown

        private static void SelectIsInterpreterRequiredFromDropDown(IWebDriver driver, string isInterpreterRequired)
        {
            IWebElement dropDownInterpreterRequired = LocateDropDownInterpreterRequired(driver);
            var selectInterpreterRequired = new SelectElement(dropDownInterpreterRequired);
            selectInterpreterRequired.SelectByValue(isInterpreterRequired);
        }

        //Method to locate an Interpreter Required option from the dropdown

        private static IWebElement LocateDropDownInterpreterRequired(IWebDriver driver)
        {
            string dropDownInterpreterLocation = "cw_interpreterrequired_i";
            driver.WaitUntilVisible(By.Id(dropDownInterpreterLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement interpreterRequiredDropDown = driver.FindElement(By.Id(dropDownInterpreterLocation));
            return interpreterRequiredDropDown;
        }


        //Method to click the click the NHS Card Location label

        private static void ClickLabelNHSCardLocation(IWebDriver driver)
        {
            string labelNHSCardLocation = "//*[@id=\"cw_nhscardlocation_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelNHSCardLocation));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelNHSCardLocation));
            labelLocation.Click();
        }

        //Method to enter text into the NHS Card Location field

        private static void EnterTextIntoFieldNHSCardLocation(IWebDriver driver, string nhsCardLocation)
        {
            string textFieldNHSCardLocation = "//*[@id=\"cw_nhscardlocation_i\"]";
            driver.WaitUntilVisible(By.XPath(textFieldNHSCardLocation));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldNHSCardLocation));
            inputField.SendKeys(nhsCardLocation);
        }


        //Method to click the click the Immigration Status label

        private static void ClickLabelImmigrationStatus(IWebDriver driver)
        {
            string labelImmigrationStatus = "//*[@id=\"cw_immigrationstatusreferenceid_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelImmigrationStatus));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelImmigrationStatus));
            labelLocation.Click();
        }


        //Method to click the lookup button next to the Immigration Status field

        private static void ClickLookupImmigrationStatus(IWebDriver driver)
        {
            IWebElement lookupImmigrationStatus = driver.FindElement(By.XPath("//*[@id=\"cw_immigrationstatusreferenceid_i\"]"));
            lookupImmigrationStatus.Click();
        }


        //Method to select a Immigration Status from the lookup menu

        private static void SelectImmigrationStatusUsingLookup(IWebDriver driver, string immigrationStatus)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_immigrationstatusreferenceid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + immigrationStatus + "')]]")).Click();
        }


        //Method to enter text into the Immigration Status field

        private static void EnterTextIntoImmigrationStatusField(IWebDriver driver, string immigrationStatus)
        {
            string textFieldImmigrationStatus = "//*[@id=\"cw_immigrationstatusreferenceid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(textFieldImmigrationStatus));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldImmigrationStatus));
            inputField.SendKeys(immigrationStatus);
        }


        //Method to click the click the Place Of Birth label

        private static void ClickLabelPlaceOfBirth(IWebDriver driver)
        {
            string labelPlaceOfBirth = "//*[@id=\"cw_placeofbirth_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelPlaceOfBirth));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelPlaceOfBirth));
            labelLocation.Click();
        }


        //Method to enter text into the Place Of Birth field

        private static void EnterTextIntoFieldPlaceOfBirth(IWebDriver driver, string placeOfBirth)
        {
            string textFieldPlaceOfBirth = "//*[@id=\"cw_placeofbirth_i\"]";
            driver.WaitUntilVisible(By.XPath(textFieldPlaceOfBirth));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldPlaceOfBirth));
            inputField.SendKeys(placeOfBirth);
        }


        //Method to click the click the Lives Alone label

        private static void ClickLabelLivesAlone(IWebDriver driver)
        {
            string labelLivesAloneLocation = "//*[@id=\"cw_livesalone_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelLivesAloneLocation));
            IWebElement labeLivesAlone = driver.FindElement(By.XPath(labelLivesAloneLocation));
            labeLivesAlone.Click();
        }


        //Method to select an option for Lives Alone from the dropdown

        private static void SelectLivesAloneOptionFromDropDown(IWebDriver driver, string livesAlone)
        {
            IWebElement dropDownLivesAlone = LocateDropDownLivesAlone(driver);
            var selectLivesAlone = new SelectElement(dropDownLivesAlone);
            selectLivesAlone.SelectByValue(livesAlone);
        }

        //Method to locate an Lives Alone option from the dropdown

        private static IWebElement LocateDropDownLivesAlone(IWebDriver driver)
        {
            string dropDownLivesAloneLocation = "cw_livesalone_i";
            driver.WaitUntilVisible(By.Id(dropDownLivesAloneLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement livesAloneDropDown = driver.FindElement(By.Id(dropDownLivesAloneLocation));
            return livesAloneDropDown;
        }


        //Method to click the click the Date Of Birth (Pre 1900) label

        private static void ClickLabelDOBPre1900(IWebDriver driver)
        {
            string labelDateOfBirthPre1900 = "//*[@id=\"cw_placeofbirth_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelDateOfBirthPre1900));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelDateOfBirthPre1900));
            labelLocation.Click();
        }


        //Method to enter text into the Date Of Birth (Pre 1900) field

        private static void EnterTextIntoFieldDOBPre1900(IWebDriver driver, string dateOfBirth)
        {
            string textFieldDateOfBirth = "//*[@id=\"cw_placeofbirth_i\"]";
            driver.WaitUntilVisible(By.XPath(textFieldDateOfBirth));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldDateOfBirth));
            inputField.SendKeys(dateOfBirth);
        }


        //Method to click the click the LMP Confirmed By label

        private static void ClickLabelLMPConfirmedBy(IWebDriver driver)
        {
            string labelLMPConfirmedBy = "//*[@id=\"cw_lmpconfirmedby_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelLMPConfirmedBy));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelLMPConfirmedBy));
            labelLocation.Click();
        }


        //Method to click the lookup button next to the LMP Confirmed By field

        private static void ClickLookupLMPConfirmedBy(IWebDriver driver)
        {
            IWebElement lookupLMPConfirmedBy = driver.FindElement(By.XPath("//*[@id=\"cw_lmpconfirmedby_i\"]"));
            lookupLMPConfirmedBy.Click();
        }


        //Method to select a LMP Confirmed By from the lookup menu

        private static void SelectLMPConfirmedByUsingLookup(IWebDriver driver, string lmpConfirmedBy)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_lmpconfirmedby_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + lmpConfirmedBy + "')]]")).Click();
        }


        //Method to enter text into the LMP Confirmed By field

        private static void EnterTextIntoLMPConfirmedByField(IWebDriver driver, string lmpConfirmedBy)
        {
            string textFieldLMGConfirmedBy = "//*[@id=\"cw_immigrationstatusreferenceid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(textFieldLMGConfirmedBy));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldLMGConfirmedBy));
            inputField.SendKeys(lmpConfirmedBy);
        }

    }
}
