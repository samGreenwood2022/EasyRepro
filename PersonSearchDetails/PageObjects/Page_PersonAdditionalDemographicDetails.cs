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

        public static void EnterWeeksGestation(IWebDriver driver, string maidenName)
        {
            ClickLabelWeeksGestation(driver);
            EnterTextIntoFieldWeeksGestation(driver, maidenName);
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


        //Method to click the lookup button next to the Target Group field

        private static void ClickLookupLeavingCare(IWebDriver driver)
        {
            IWebElement lookupTargetGroup = driver.FindElement(By.XPath("//*[@id=\"Dialog_cw_leavingcareeligibilityid_IMenu\"]"));
            lookupTargetGroup.Click();
        }


        //Method to select a Target Group from the lookup menu

        private static void SelectLeavingCareUsingLookup(IWebDriver driver, string leavingCare)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_targetgroupreferenceid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + leavingCare + "')]]")).Click();
        }


        //Method to enter text into the Leaving Care field

        private static void EnterTextIntoLeavingCareField(IWebDriver driver, string leavingCare)
        {
            string textFieldLeavingCare = "//*[@id=\"cw_targetgroupreferenceid_ledit\"]";
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

    }
}
