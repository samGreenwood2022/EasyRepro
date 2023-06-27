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

    }
}
