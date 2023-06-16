using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace WCCIS.Specs.PageObjects
{
    internal class Page_PersonGeneralPractitioner
    {
        //Public methods

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

        //Method to enter a date into the GP Start Date field

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
                ClickLabelGPStartDate(driver);
                EnterTextIntoTextBoxGPStartDate(driver, startDate);
            }
        }


        //Private methods

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
            IWebElement lookupSurgeryPractice = driver.FindElement(By.XPath("//*[@id=\"cw_surgerypracticeid_i\"]"));
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
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_gpstartdate_cl\"]"));
            IWebElement labelGPStartDate = driver.FindElement(By.XPath("//*[@id=\"cw_gpstartdate_cl\"]"));
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


    }
}
