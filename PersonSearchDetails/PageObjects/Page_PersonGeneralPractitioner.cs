using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;

namespace WCCIS.Specs.PageObjects
{
    internal class Page_PersonGeneralPractitioner
    {
        //Public methods

        //Method for entering text into Surgery/Practice field 
        public static void SelectSurgeryPractice(IWebDriver driver, Browser xrmBrowser, string surgeryPractice, bool isUsingLookup = true)
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


        //Private methods

        //Method to locale the Surgery/Practice label

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
            driver.WaitUntilVisible(By.XPath("//*[@id=\"cw_surgerypracticeid_ledit\"]"));
            IWebElement textBoxSurgeryPractice = driver.FindElement(By.XPath("//*[@id=\"cw_surgerypracticeid_ledit\"]"));
            textBoxSurgeryPractice.SendKeys(surgeryPractice = Keys.Enter);

        }


    }
}
