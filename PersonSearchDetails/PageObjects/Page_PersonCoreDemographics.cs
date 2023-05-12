using Microsoft.Dynamics365.UIAutomation.Api;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void EnterDateMovedIn()
        {
            throw new NotImplementedException();
        }

        public static void EnterGender()
        {
            throw new NotImplementedException();
        }
        internal static void EnterPreferredLanguage()
        {
            throw new NotImplementedException();
        }

        public static void EnterDateOfBirth()
        {
            throw new NotImplementedException();
        }

        public static void EnterEthnicity(IWebDriver driver, string ethnicity, bool usingLookup = true)
        {

            if (usingLookup)
            {
                //This method will use the lookup button instead
                IWebElement ethnicityLabel = LocateEthnicityLabel(driver);
                ethnicityLabel.Click();
                IWebElement ethnicityLookUpButton = LocateEthnicityLookupButton(driver);
                ethnicityLookUpButton.Click();
                IWebElement ethnicityFromMenu = LocateEthnicityFromMenu(driver, ethnicity);
                ethnicityFromMenu.Click();
            }

            if (!usingLookup)
            {
                //This method will click the Label and then type into the Ethnicity Text Box
                //If the text matches an ethnicity in the lookup, you will enter it into the field
                IWebElement ethnicityLabel = LocateEthnicityLabel(driver);
                ethnicityLabel.Click();
                EnterTextIntoEthnicityField(driver, ethnicity);
            }
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

        private static void EnterTextIntoEthnicityField(IWebDriver driver, string ethnicity)
        {
            //Locate the box and send text to it
            //Not to be called directly in isolation
            //Method will fail unless you are clicked into the box 
            IWebElement ethnicityTextbox = LocateEthnicityBox(driver);
            ethnicityTextbox.SendKeys(ethnicity);
        }

        private static IWebElement LocateEthnicityLabel(IWebDriver webDriver)
        {
            //Note that the clicked element here is different to those used for last name etc. 
            IWebElement ethnicityLabel = webDriver.FindElement(By.Id("cw_ethnicityid_cl_span"));
            return ethnicityLabel;
        }

        private static IWebElement LocateEthnicityBox(IWebDriver webDriver)
        {
            //Locate the ethnicity text box - this method does nothing with it
            IWebElement ethnicityBox = webDriver.FindElement(By.Id("cw_ethnicityid_ledit"));
            return ethnicityBox;
        }

        private static IWebElement LocateEthnicityLookupButton(IWebDriver webDriver)
        {
            //
            IWebElement ethnicityLookupButton = webDriver.FindElement(By.Id("cw_ethnicityid_lookupSearch"));
            return ethnicityLookupButton;
        }

        private static IWebElement LocateEthnicityFromMenu(IWebDriver webDriver, string ethnicity)
        {
            //Note that if the ethnicity button is clicked more than once you will generate a new ID each time
            IWebElement ethnicityFromMenu = webDriver.FindElement(By.XPath("//a[@title='" + ethnicity + "']"));
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
