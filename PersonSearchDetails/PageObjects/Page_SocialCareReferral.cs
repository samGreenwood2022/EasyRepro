using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WCCIS.Specs.PageObjects
{
    internal class Page_SocialCareReferral
    {
        //Public

        //Method to enter a value into the Referal Reason field


        public static void EnterReferralReason(IWebDriver driver, string referralReason, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our value
                ClickLabelReferralReason(driver);
                ClickLookupReferralReason(driver);
                SelectReferralReasonUsingLookup(driver, referralReason);

            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelReferralReason(driver);
                EnterTextIntoReferralReasonField(driver, referralReason);
            }
        }


        //Method to enter a value into the Reason Text field

        public static void EnterReasonText(IWebDriver driver, string reasonText)
        {
            ClickLabelReasonText(driver);
            EnterTextIntoFieldReasonText(driver, reasonText);
        }


        //Method to enter text into the Referral Date/Time field

        public static void EnterLastReferralDateTime(IWebDriver driver, string referralDate, string referralTime, bool isUsingDatePicker = false)
        {
            if (isUsingDatePicker)
            {
                throw new NotImplementedException();
                //LocateDMIPickerButton
                //SelectUsingDMIPicker
            }

            if (!isUsingDatePicker)
            {
                ClickLabelReferralDateTime(driver);
                EnterTextIntoFieldReferralDateTime(driver, referralDate, referralTime);
            }
        }


        //Method to enter a value into the Priority field


        public static void EnterPriority(IWebDriver driver, string priority, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our value
                ClickLabelPriority(driver);
                ClickLookupPriority(driver);
                SelectPriorityUsingLookup(driver, priority);

            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelPriority(driver);
                EnterTextIntoPriorityField(driver, priority);
            }
        }


        //Method to select an option from the Is the person/carer aware of the referral dropdown

        public static void EnterIsPersonCarerAwareOfReferral(IWebDriver driver, string isPersonCarerAwareOfReferral)
        {
            ClickLabelIsPersonCarerAwareOfReferral(driver);
            SelectIsPersonCarerAwareOfReferralFromDropDown(driver, isPersonCarerAwareOfReferral);
        }


        //Method to enter a value into the CINCode field


        public static void EnterCINCode(IWebDriver driver, string cinCode, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our value
                ClickLabelCINCode(driver);
                ClickLookupCINCode(driver);
                SelectCINCodeLookup(driver, cinCode);

            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelCINCode(driver);
                EnterTextIntoCINCodeField(driver, cinCode);
            }
        }


        //Method to enter a value into the Source Organisation field


        public static void EnterSourceOrganisation(IWebDriver driver, string sourceOrganisation, bool isUsingLookup = true)
        {
            if (isUsingLookup)
            {
                //Default pathway
                //Selects the lookup button
                //Then clicks the item from lookup menu that contains our value
                ClickLabelSourceOrganisation(driver);
                SelectLookupSourceOrganisation(driver);
                SelectLookupUsingSourceOrganisation(driver, sourceOrganisation);

            }

            if (!isUsingLookup)
            {
                //The old method
                //still valid, but enters text only
                ClickLabelSourceOrganisation(driver);
                EnterTextIntoSourceOrganisationField(driver, sourceOrganisation);
            }
        }


        //Method to select an option from the Referral Origin dropdown

        public static void EnterReferralOrigin(IWebDriver driver, string referralOrigin)
        {
            ClickLabelReferralOrigin(driver);
            SelectReferralOriginFromDropDown(driver, referralOrigin);
        }





        //Private


        //Method to click the click the Referral Reason label

        private static void ClickLabelReferralReason(IWebDriver driver)
        {
            string labelReferralReason = "//*[@id=\"cw_referralreasonid_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelReferralReason));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelReferralReason));
            labelLocation.Click();
        }

        //Method to enter text into the Referral Reason field

        private static void EnterTextIntoReferralReasonField(IWebDriver driver, string referralReason)
        {
            string textFieldReferralReason = "//*[@id=\"cw_referralreasonid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(textFieldReferralReason));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldReferralReason));
            inputField.SendKeys(referralReason);
        }

        //Method to click the lookup button next to the Referral Reason field

        private static void ClickLookupReferralReason(IWebDriver driver)
        {
            IWebElement lookupReferralReason = driver.FindElement(By.XPath("//*[@id=\"cw_referralreasonid_lookupSearch\"]"));
            lookupReferralReason.Click();
        }


        //Method to select a Referral Reason from the lookup menu

        private static void SelectReferralReasonUsingLookup(IWebDriver driver, string referralReason)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_referralreasonid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + referralReason + "')]]")).Click();
        }


        //Method to click the Reason Text label

        private static void ClickLabelReasonText(IWebDriver driver)
        {
            string labelReasonText = "//*[@id=\"cw_reasontext_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelReasonText));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelReasonText));
            labelLocation.Click();
        }


        //Method to enter text into the Reason Text field

        private static void EnterTextIntoFieldReasonText(IWebDriver driver, string reasonText)
        {
            string textFieldReasonText = "//*[@id=\"cw_reasontext_i\"]";
            driver.WaitUntilVisible(By.XPath(textFieldReasonText));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldReasonText));
            inputField.SendKeys(reasonText);
        }


        //Method to click the click the Referral Date Time label

        private static void ClickLabelReferralDateTime(IWebDriver driver)
        {
            string labelReferralDateTime = "//*[@id=\"cw_contactdatetime\"]";
            driver.WaitUntilVisible(By.XPath(labelReferralDateTime));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelReferralDateTime));
            labelLocation.Click();
        }

        //Method to enter text into the Referral Date & Time fields

        private static void EnterTextIntoFieldReferralDateTime(IWebDriver driver, string referralDate, string referralTime)
        {
            string textFieldReferralDate = "//*[@id=\"cw_contactdatetime_iDateInput\"]";
            driver.WaitUntilVisible(By.XPath(textFieldReferralDate));
            driver.FindElement(By.XPath(textFieldReferralDate)).Clear();
            IWebElement date = driver.FindElement(By.XPath(textFieldReferralDate));
            date.SendKeys(referralDate);

            string labelReferralDateTime = "//*[@id=\"cw_contactdatetime\"]/div[1]";
            driver.WaitUntilVisible(By.XPath(labelReferralDateTime));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelReferralDateTime));
            labelLocation.Click();

            string textFieldReferralTime = "//*[@id=\"cw_contactdatetime_iTimeInput\"]";
            driver.WaitUntilVisible(By.XPath(textFieldReferralTime));
            driver.FindElement(By.XPath(textFieldReferralTime)).Clear();
            IWebElement time = driver.FindElement(By.XPath(textFieldReferralTime));
            time.SendKeys(referralTime);

        }


        //Method to click the click the Priority label

        private static void ClickLabelPriority(IWebDriver driver)
        {
            string labelPriority = "//*[@id=\"cw_referralpriorityid_cl_span\"]";
            driver.WaitUntilVisible(By.XPath(labelPriority));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelPriority));
            labelLocation.Click();
        }

        //Method to enter text into the Priority field

        private static void EnterTextIntoPriorityField(IWebDriver driver, string priority)
        {
            string textFieldPriority = "//*[@id=\"cw_referralpriorityid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(textFieldPriority));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldPriority));
            inputField.SendKeys(priority);
        }

        //Method to click the lookup button next to the Priority field

        private static void ClickLookupPriority(IWebDriver driver)
        {
            IWebElement lookupPriority = driver.FindElement(By.XPath("//*[@id=\"cw_referralpriorityid_lookupSearch\"]"));
            lookupPriority.Click();
        }


        //Method to select a Priority from the lookup menu

        private static void SelectPriorityUsingLookup(IWebDriver driver, string priority)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_referralpriorityid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + priority + "')]]")).Click();
        }


        //Method to click the click the Is Person/Carer aware of the referral label

        private static void ClickLabelIsPersonCarerAwareOfReferral(IWebDriver driver)
        {
            string labelIsPersonCarerAwareOfReferralLocation = "//*[@id=\"cw_isthepersoncarerawareofthereferral_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelIsPersonCarerAwareOfReferralLocation));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelIsPersonCarerAwareOfReferralLocation));
            labelLocation.Click();
        }


        //Method to select a value from the Is Person/Carer aware of the referral dropdown

        private static void SelectIsPersonCarerAwareOfReferralFromDropDown(IWebDriver driver, string isPersonCarerAwareOfReferral)
        {
            int index;

            if(isPersonCarerAwareOfReferral == "Yes")
            {
                index = 1;
            }
            else
            {
                index = 0;
            }

            IWebElement dropDownisPersonCarerAwareOfReferral = LocateDropDownIsPersonCarerAwareOfReferral(driver);
            var selectIsPersonCarerAwareOfReferral = new SelectElement(dropDownisPersonCarerAwareOfReferral);
            selectIsPersonCarerAwareOfReferral.SelectByIndex(index);
        }

        //Method to locate a value from the Is Person or carer aware of the referral dropdown

        private static IWebElement LocateDropDownIsPersonCarerAwareOfReferral(IWebDriver driver)
        {
            string dropDownIsPersonCarerAwareOfReferralLocation = "cw_isthepersoncarerawareofthereferral_i";
            driver.WaitUntilVisible(By.Id(dropDownIsPersonCarerAwareOfReferralLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement isPersonCarerAwareOfReferralDropDown = driver.FindElement(By.Id(dropDownIsPersonCarerAwareOfReferralLocation));
            return isPersonCarerAwareOfReferralDropDown;
        }


        //Method to click the click the CINCode label

        private static void ClickLabelCINCode(IWebDriver driver)
        {
            string labelCINCode = "//*[@id=\"cw_cinrefid_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelCINCode));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelCINCode));
            labelLocation.Click();
        }

        //Method to enter text into the CIN Code field

        private static void EnterTextIntoCINCodeField(IWebDriver driver, string cinCode)
        {
            string textFieldCINCode = "//*[@id=\"cw_cinrefid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(textFieldCINCode));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldCINCode));
            inputField.SendKeys(cinCode);
        }

        //Method to click the lookup button next to the CIN Code field

        private static void ClickLookupCINCode(IWebDriver driver)
        {
            IWebElement lookupCINCode = driver.FindElement(By.XPath("//*[@id=\"cw_cinrefid_lookupSearch\"]"));
            lookupCINCode.Click();
        }

        //Method to select a CIN Code from the lookup menu

        private static void SelectCINCodeLookup(IWebDriver driver, string cinCode)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_cinrefid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + cinCode + "')]]")).Click();
        }


        //Method to select a Source Organisation from the lookup menu

        private static void SelectLookupSourceOrganisation(IWebDriver driver, string sourceOrganisation )
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_sourceorganizationid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + sourceOrganisation + "')]]")).Click();
        }


        //Method to click the click the Source Organisation label

        private static void ClickLabelSourceOrganisation(IWebDriver driver)
        {
            string labelSourceOrganisation = "//*[@id=\"cw_sourceorganizationid_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelSourceOrganisation));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelSourceOrganisation));
            labelLocation.Click();
        }

        //Method to enter text into the Source Organisation field

        private static void EnterTextIntoSourceOrganisationField(IWebDriver driver, string sourceOrganisation)
        {
            string textFieldSourceOrganisation = "//*[@id=\"cw_sourceorganizationid_ledit\"]";
            driver.WaitUntilVisible(By.XPath(textFieldSourceOrganisation));
            IWebElement inputField = driver.FindElement(By.XPath(textFieldSourceOrganisation));
            inputField.SendKeys(sourceOrganisation);
        }

        //Method to click the lookup button next to the Source Organisation field

        private static void SelectLookupSourceOrganisation(IWebDriver driver)
        {
            IWebElement lookupSourceOrganisation = driver.FindElement(By.XPath("//*[@id=\"cw_sourceorganizationid_lookupSearch\"]"));
            lookupSourceOrganisation.Click();
        }


        //Method to select a Source Organisation from the lookup menu

        private static void SelectLookupUsingSourceOrganisation(IWebDriver driver, string sourceOrganisation)
        {
            driver.WaitUntilVisible(By.XPath("//*[@id=\"Dialog_cw_sourceorganizationid_IMenu\"]"));
            driver.FindElement(By.XPath("//*[text()[contains(.,'" + sourceOrganisation + "')]]")).Click();
        }


        //Method to click the click the Referral Origin label

        private static void ClickLabelReferralOrigin(IWebDriver driver)
        {
            string labelReferralOriginLocation = "//*[@id=\"cw_isthepersoncarerawareofthereferral_cl\"]";
            driver.WaitUntilVisible(By.XPath(labelReferralOriginLocation));
            IWebElement labelLocation = driver.FindElement(By.XPath(labelReferralOriginLocation));
            labelLocation.Click();
        }


        //Method to select a value from the Referral Origin dropdown

        private static void SelectReferralOriginFromDropDown(IWebDriver driver, string referralOrigin)
        {
            IWebElement dropDownReferralOrigin = LocateDropDownReferralOrigin(driver);
            var selectReferralOrigin = new SelectElement(dropDownReferralOrigin);
            selectReferralOrigin.SelectByValue(referralOrigin);
        }

        //Method to locate a value from the Referral Origin dropdown

        private static IWebElement LocateDropDownReferralOrigin(IWebDriver driver)
        {
            string dropDownReferralOriginLocation = "caseorigincode_i";
            driver.WaitUntilVisible(By.Id(dropDownReferralOriginLocation));
            //Find the drop down only
            // act on the returned value to select items or check current value 
            IWebElement referralOriginDropDown = driver.FindElement(By.Id(dropDownReferralOriginLocation));
            return referralOriginDropDown;
        }



    }
}
